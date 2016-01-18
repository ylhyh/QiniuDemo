using System.Net;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using Qiniu.IO;
using Qiniu.RPC;
using Qiniu.RSF;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qiniu.RS;

namespace QiniuFileTool
{
    public partial class frmFileMove : Form
    {
        private void SetQiniuSourceKeies()
        {
            Qiniu.Conf.Config.ACCESS_KEY = txtSourceAK.Text.Trim();
            Qiniu.Conf.Config.SECRET_KEY = txtSourceSK.Text.Trim();
        }

        private void SetQiniuDestKeies()
        {
            Qiniu.Conf.Config.ACCESS_KEY = txtDestAK.Text.Trim();
            Qiniu.Conf.Config.SECRET_KEY = txtDestSK.Text.Trim();
        }

        public frmFileMove()
        {
            InitializeComponent();
        }

        private void frmFileMove_Load(object sender, EventArgs e)
        {
            //Qiniu.Conf.Config.ACCESS_KEY = "5XpBDEz38TW5Bpe8ntpNIYnvdrLLEp3_AR5c645V";
            //Qiniu.Conf.Config.SECRET_KEY = "TohP7pWKs6Acou3UKRLZTFBZv4k4xHEhcqSiLAXQ";
            //string fileUrl = "http://7xnf1r.media1.z0.glb.clouddn.com/test_no_domain.m3u8?pm3u8/0";
            //string downloadUrl = GetPolicy.MakeRequest(fileUrl, 43200);
            //;
        }

        private void btnCreateFetchFile_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSourceAK.Text) ||
                String.IsNullOrWhiteSpace(txtSourceSK.Text) ||
                String.IsNullOrWhiteSpace(txtSourceBucket.Text) ||
                String.IsNullOrWhiteSpace(txtSourceDomain.Text))
            {
                MessageBox.Show("Please fill-in source AK, SK, Bucket and Domain!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sourceFileName = txtSourceBucket.Text.Trim() + "_files.txt";
            string logFileName = txtSourceBucket.Text.Trim() + ".log";

            try
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                SetQiniuSourceKeies();
                RSFClient rsfClient = new RSFClient(txtSourceBucket.Text.Trim());

                using (FileStream file = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sourceFileName)))
                {
                    StreamWriter logFileStream = File.CreateText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logFileName));
                    List<DumpItem> items;

                    while ((items = rsfClient.Next()) != null)
                    {
                        items.ForEach((DumpItem item) =>
                        {
                            string fileUrl = GetPolicy.MakeBaseUrl(txtSourceDomain.Text.Trim(), item.Key);
                            string downloadUrl = chkPrivateBucket.Checked
                                ? GetPolicy.MakeRequest(fileUrl, 12 * 60 * 60)
                                : fileUrl;

                            if (item.Key.StartsWith("m3u8_") || item.Key.EndsWith(".m3u"))
                            {
                                /*
                                 * Special process for m3u8 files.
                                 * Replace domain.
                                 */
                                int m3uTryCount = 5;

                                while (m3uTryCount > 0)
                                {
                                    try
                                    {
                                        m3uTryCount--;
                                        var request = HttpWebRequest.Create(downloadUrl) as HttpWebRequest;
                                        request.Method = "GET";

                                        var response = request.GetResponse() as HttpWebResponse;
                                        string responseContent;

                                        using (Stream responseStream = response.GetResponseStream())
                                        {
                                            var streamReader = new StreamReader(responseStream);
                                            responseContent = streamReader.ReadToEnd();
                                            responseStream.Close();
                                            responseContent =
                                                responseContent.Replace("http://" + txtSourceDomain.Text.Trim(),
                                                    string.Empty);
                                        }

                                        MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(responseContent));
                                        SetQiniuDestKeies(); // Change Thread's Qiniu keies to Destination.

                                        var putPolicy = new PutPolicy(txtDestBacket.Text.Trim(), 12 * 60 * 60);
                                        string token = putPolicy.Token();
                                        var extra = new PutExtra();
                                        var ioClient = new IOClient();
                                        var putRet = ioClient.Put(token, item.Key, memoryStream, extra);
                                        memoryStream.Close();
                                        memoryStream.Dispose();

                                        if (putRet.StatusCode != HttpStatusCode.OK)
                                        {
                                            if (m3uTryCount > 0)
                                            {
                                                logFileStream.WriteLine(String.Format("Try process m3u8: {0}[{1}]", item.Key, m3uTryCount));
                                            }
                                            else
                                            {
                                                logFileStream.WriteLine("File upload failed:" + item.Key);
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }

                                SetQiniuSourceKeies(); // Change back Thread's Qiniu keys to Source.
                            }
                            else
                            {

                                byte[] fileKey =
                                    Encoding.UTF8.GetBytes(downloadUrl + "\t" + item.Key + Environment.NewLine);
                                file.Write(fileKey, 0, fileKey.Length);
                            }
                        });
                    }

                    logFileStream.Flush();
                    logFileStream.Close();
                    logFileStream.Dispose();

                    file.Flush();
                    file.Close();
                    file.Dispose();
                }
            }
            finally
            {
                MessageBox.Show(
                    "Source file [" + sourceFileName + "] created." +
                        Environment.NewLine + "\t1. Please look into the log file[" + logFileName + "] to check if all of the M3U8 files have been uploaded to destination bucket!" +
                        Environment.NewLine + "\t2. Please fill-in destination information and then to generate batch file!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Enabled = true;
                this.ResetCursor();
            }
        }

        private void btnCreateFetchBatch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtDestAK.Text) ||
                String.IsNullOrWhiteSpace(txtDestSK.Text) ||
                String.IsNullOrWhiteSpace(txtDestBacket.Text)/* ||
                String.IsNullOrWhiteSpace(txtDestDomain.Text)*/)
            {
                MessageBox.Show("Please fill-in destination AK, SK, Bucket and Domain!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sourceFileName = txtSourceBucket.Text.Trim() + "_files.txt";
            string batchFileName = txtSourceBucket.Text.Trim() + "_to_" + txtDestBacket.Text.Trim() + ".bat";

            try
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                using (FileStream file = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, batchFileName)))
                {
                    string strCommandLine = String.Format(".\\qfetch-v1.2\\{0} -ak=\"{1}\" -sk=\"{2}\" -bucket=\"{3}\" -file=\"%~dp0{4}\" -worker={5} -job=\"{6}\"",
                        Environment.Is64BitOperatingSystem ? "qfetch_windows_amd64.exe" : "qfetch_windows_386.exe",
                        txtDestAK.Text.Trim(),
                        txtDestSK.Text.Trim(),
                        txtDestBacket.Text.Trim(),
                        sourceFileName,
                        300,
                        "fetch_job" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff"));
                    byte[] commandLine = Encoding.UTF8.GetBytes(strCommandLine);

                    file.Write(commandLine, 0, commandLine.Length);

                    file.Flush();
                    file.Close();
                    file.Dispose();
                }
            }
            finally
            {
                MessageBox.Show("Batch file [" + batchFileName + "] created. Please run the batch to start fetch job!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Enabled = true;
                this.ResetCursor();
            }
        }
    }
}
