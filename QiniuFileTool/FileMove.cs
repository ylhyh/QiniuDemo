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

        public frmFileMove()
        {
            InitializeComponent();
        }

        private void frmFileMove_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateFetchFile_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSourceAK.Text) ||
                String.IsNullOrWhiteSpace(txtSourceSK.Text) ||
                String.IsNullOrWhiteSpace(txtSourceBucket.Text) ||
                String.IsNullOrWhiteSpace(txtSourceDomain.Text))
            {
                MessageBox.Show("Please fill-in source AK,SK,Bucket and Domain!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                btnCreateFetchFile.Enabled = false;
                SetQiniuSourceKeies();
                RSFClient rsfClient = new RSFClient(txtSourceBucket.Text.Trim());
                using (FileStream file = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sourcefiles.txt")))
                {
                    List<DumpItem> items;
                    while ((items = rsfClient.Next()) != null)
                    {
                        items.ForEach((DumpItem item) =>
                        {
                            string fileUrl = GetPolicy.MakeBaseUrl(txtSourceDomain.Text.Trim(), item.Key);
                            string downloadUrl = chkPrivateBucket.Checked ? GetPolicy.MakeRequest(fileUrl) : fileUrl;
                            byte[] fileKey = Encoding.UTF8.GetBytes(downloadUrl + "\t" + item.Key + Environment.NewLine);
                            file.Write(fileKey, 0, fileKey.Length);
                        });
                    }

                    file.Flush();
                    file.Close();
                    file.Dispose();
                }
            }
            finally
            {
                MessageBox.Show("Source file [sourcefiles.txt] created. Please fill-in destination information and then to generate batch file!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCreateFetchFile.Enabled = true;
            }
        }

        private void btnCreateFetchBatch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtDestAK.Text) ||
                String.IsNullOrWhiteSpace(txtDestSK.Text) ||
                String.IsNullOrWhiteSpace(txtDestBacket.Text))
            {
                MessageBox.Show("Please fill-in destination AK,SK and Bucket!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                btnCreateFetchBatch.Enabled = false;
                using (FileStream file = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "startfetch.bat")))
                {
                    string strCommandLine = String.Format(".\\qfetch-v1.2\\{0} -ak=\"{1}\" -sk=\"{2}\" -bucket=\"{3}\" -file=\"%~dp0{4}\" -worker={5} -job=\"{6}\"",
                        Environment.Is64BitOperatingSystem ? "qfetch_windows_amd64.exe" : "qfetch_windows_386.exe",
                        txtDestAK.Text.Trim(),
                        txtDestSK.Text.Trim(),
                        txtDestBacket.Text.Trim(),
                        "sourcefiles.txt",
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
                MessageBox.Show("Batch file [startfetch.bat] created. Please run the batch to start fetch job!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCreateFetchBatch.Enabled = true;
            }
        }
    }
}
