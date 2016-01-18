namespace QiniuFileTool
{
    partial class frmFileMove
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSourceAK = new System.Windows.Forms.TextBox();
            this.txtDestAK = new System.Windows.Forms.TextBox();
            this.btnCreateFetchFile = new System.Windows.Forms.Button();
            this.txtSourceSK = new System.Windows.Forms.TextBox();
            this.txtSourceBucket = new System.Windows.Forms.TextBox();
            this.lblSourceAK = new System.Windows.Forms.Label();
            this.lblSourceSK = new System.Windows.Forms.Label();
            this.lblSourceBucket = new System.Windows.Forms.Label();
            this.lblDestAK = new System.Windows.Forms.Label();
            this.lblDestSK = new System.Windows.Forms.Label();
            this.lblDestBucket = new System.Windows.Forms.Label();
            this.txtDestSK = new System.Windows.Forms.TextBox();
            this.txtDestBacket = new System.Windows.Forms.TextBox();
            this.lblSourceDomain = new System.Windows.Forms.Label();
            this.txtSourceDomain = new System.Windows.Forms.TextBox();
            this.chkPrivateBucket = new System.Windows.Forms.CheckBox();
            this.btnCreateFetchBatch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.lblDestDomain = new System.Windows.Forms.Label();
            this.txtDestDomain = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSourceAK
            // 
            this.txtSourceAK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSourceAK.Location = new System.Drawing.Point(155, 52);
            this.txtSourceAK.Name = "txtSourceAK";
            this.txtSourceAK.Size = new System.Drawing.Size(273, 21);
            this.txtSourceAK.TabIndex = 3;
            // 
            // txtDestAK
            // 
            this.txtDestAK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDestAK.Location = new System.Drawing.Point(155, 49);
            this.txtDestAK.Name = "txtDestAK";
            this.txtDestAK.Size = new System.Drawing.Size(273, 21);
            this.txtDestAK.TabIndex = 3;
            // 
            // btnCreateFetchFile
            // 
            this.btnCreateFetchFile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreateFetchFile.Location = new System.Drawing.Point(155, 182);
            this.btnCreateFetchFile.Name = "btnCreateFetchFile";
            this.btnCreateFetchFile.Size = new System.Drawing.Size(273, 23);
            this.btnCreateFetchFile.TabIndex = 4;
            this.btnCreateFetchFile.Text = "Generate Source File List";
            this.btnCreateFetchFile.UseVisualStyleBackColor = true;
            this.btnCreateFetchFile.Click += new System.EventHandler(this.btnCreateFetchFile_Click);
            // 
            // txtSourceSK
            // 
            this.txtSourceSK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSourceSK.Location = new System.Drawing.Point(155, 79);
            this.txtSourceSK.Name = "txtSourceSK";
            this.txtSourceSK.Size = new System.Drawing.Size(273, 21);
            this.txtSourceSK.TabIndex = 3;
            // 
            // txtSourceBucket
            // 
            this.txtSourceBucket.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSourceBucket.Location = new System.Drawing.Point(155, 106);
            this.txtSourceBucket.Name = "txtSourceBucket";
            this.txtSourceBucket.Size = new System.Drawing.Size(273, 21);
            this.txtSourceBucket.TabIndex = 3;
            // 
            // lblSourceAK
            // 
            this.lblSourceAK.AutoSize = true;
            this.lblSourceAK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSourceAK.Location = new System.Drawing.Point(36, 55);
            this.lblSourceAK.Name = "lblSourceAK";
            this.lblSourceAK.Size = new System.Drawing.Size(113, 12);
            this.lblSourceAK.TabIndex = 6;
            this.lblSourceAK.Text = "Source Access Key:";
            // 
            // lblSourceSK
            // 
            this.lblSourceSK.AutoSize = true;
            this.lblSourceSK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSourceSK.Location = new System.Drawing.Point(36, 82);
            this.lblSourceSK.Name = "lblSourceSK";
            this.lblSourceSK.Size = new System.Drawing.Size(113, 12);
            this.lblSourceSK.TabIndex = 6;
            this.lblSourceSK.Text = "Source Secret Key:";
            // 
            // lblSourceBucket
            // 
            this.lblSourceBucket.AutoSize = true;
            this.lblSourceBucket.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSourceBucket.Location = new System.Drawing.Point(60, 109);
            this.lblSourceBucket.Name = "lblSourceBucket";
            this.lblSourceBucket.Size = new System.Drawing.Size(89, 12);
            this.lblSourceBucket.TabIndex = 6;
            this.lblSourceBucket.Text = "Source Bucket:";
            // 
            // lblDestAK
            // 
            this.lblDestAK.AutoSize = true;
            this.lblDestAK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDestAK.Location = new System.Drawing.Point(6, 49);
            this.lblDestAK.Name = "lblDestAK";
            this.lblDestAK.Size = new System.Drawing.Size(143, 12);
            this.lblDestAK.TabIndex = 6;
            this.lblDestAK.Text = "Destination Access Key:";
            // 
            // lblDestSK
            // 
            this.lblDestSK.AutoSize = true;
            this.lblDestSK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDestSK.Location = new System.Drawing.Point(6, 80);
            this.lblDestSK.Name = "lblDestSK";
            this.lblDestSK.Size = new System.Drawing.Size(143, 12);
            this.lblDestSK.TabIndex = 6;
            this.lblDestSK.Text = "Destination Secret Key:";
            // 
            // lblDestBucket
            // 
            this.lblDestBucket.AutoSize = true;
            this.lblDestBucket.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDestBucket.Location = new System.Drawing.Point(30, 106);
            this.lblDestBucket.Name = "lblDestBucket";
            this.lblDestBucket.Size = new System.Drawing.Size(119, 12);
            this.lblDestBucket.TabIndex = 6;
            this.lblDestBucket.Text = "Destination Bucket:";
            // 
            // txtDestSK
            // 
            this.txtDestSK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDestSK.Location = new System.Drawing.Point(155, 76);
            this.txtDestSK.Name = "txtDestSK";
            this.txtDestSK.Size = new System.Drawing.Size(273, 21);
            this.txtDestSK.TabIndex = 3;
            // 
            // txtDestBacket
            // 
            this.txtDestBacket.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDestBacket.Location = new System.Drawing.Point(155, 103);
            this.txtDestBacket.Name = "txtDestBacket";
            this.txtDestBacket.Size = new System.Drawing.Size(273, 21);
            this.txtDestBacket.TabIndex = 3;
            // 
            // lblSourceDomain
            // 
            this.lblSourceDomain.AutoSize = true;
            this.lblSourceDomain.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSourceDomain.Location = new System.Drawing.Point(60, 136);
            this.lblSourceDomain.Name = "lblSourceDomain";
            this.lblSourceDomain.Size = new System.Drawing.Size(89, 12);
            this.lblSourceDomain.TabIndex = 6;
            this.lblSourceDomain.Text = "Source Domain:";
            // 
            // txtSourceDomain
            // 
            this.txtSourceDomain.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSourceDomain.Location = new System.Drawing.Point(155, 133);
            this.txtSourceDomain.Name = "txtSourceDomain";
            this.txtSourceDomain.Size = new System.Drawing.Size(273, 21);
            this.txtSourceDomain.TabIndex = 3;
            // 
            // chkPrivateBucket
            // 
            this.chkPrivateBucket.AutoSize = true;
            this.chkPrivateBucket.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPrivateBucket.Location = new System.Drawing.Point(155, 160);
            this.chkPrivateBucket.Name = "chkPrivateBucket";
            this.chkPrivateBucket.Size = new System.Drawing.Size(162, 16);
            this.chkPrivateBucket.TabIndex = 7;
            this.chkPrivateBucket.Text = "Is it a private Bucket?";
            this.chkPrivateBucket.UseVisualStyleBackColor = true;
            // 
            // btnCreateFetchBatch
            // 
            this.btnCreateFetchBatch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreateFetchBatch.Location = new System.Drawing.Point(155, 157);
            this.btnCreateFetchBatch.Name = "btnCreateFetchBatch";
            this.btnCreateFetchBatch.Size = new System.Drawing.Size(273, 23);
            this.btnCreateFetchBatch.TabIndex = 4;
            this.btnCreateFetchBatch.Text = "Generate Fetch Batch File";
            this.btnCreateFetchBatch.UseVisualStyleBackColor = true;
            this.btnCreateFetchBatch.Click += new System.EventHandler(this.btnCreateFetchBatch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSourceAK);
            this.groupBox1.Controls.Add(this.txtSourceAK);
            this.groupBox1.Controls.Add(this.chkPrivateBucket);
            this.groupBox1.Controls.Add(this.txtSourceSK);
            this.groupBox1.Controls.Add(this.txtSourceBucket);
            this.groupBox1.Controls.Add(this.lblSourceDomain);
            this.groupBox1.Controls.Add(this.txtSourceDomain);
            this.groupBox1.Controls.Add(this.lblSourceBucket);
            this.groupBox1.Controls.Add(this.btnCreateFetchFile);
            this.groupBox1.Controls.Add(this.lblSourceSK);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 215);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDestDomain);
            this.groupBox2.Controls.Add(this.txtDestDomain);
            this.groupBox2.Controls.Add(this.lblDestAK);
            this.groupBox2.Controls.Add(this.txtDestAK);
            this.groupBox2.Controls.Add(this.txtDestSK);
            this.groupBox2.Controls.Add(this.lblDestBucket);
            this.groupBox2.Controls.Add(this.txtDestBacket);
            this.groupBox2.Controls.Add(this.lblDestSK);
            this.groupBox2.Controls.Add(this.btnCreateFetchBatch);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 191);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step 2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblStep3);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(11, 430);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(438, 112);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Step 3";
            // 
            // lblStep3
            // 
            this.lblStep3.AutoSize = true;
            this.lblStep3.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStep3.Location = new System.Drawing.Point(8, 53);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(418, 27);
            this.lblStep3.TabIndex = 0;
            this.lblStep3.Text = "Run the generated batch file.";
            // 
            // lblDestDomain
            // 
            this.lblDestDomain.AutoSize = true;
            this.lblDestDomain.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDestDomain.Location = new System.Drawing.Point(30, 133);
            this.lblDestDomain.Name = "lblDestDomain";
            this.lblDestDomain.Size = new System.Drawing.Size(119, 12);
            this.lblDestDomain.TabIndex = 8;
            this.lblDestDomain.Text = "Destination Domain:";
            // 
            // txtDestDomain
            // 
            this.txtDestDomain.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDestDomain.Location = new System.Drawing.Point(155, 130);
            this.txtDestDomain.Name = "txtDestDomain";
            this.txtDestDomain.Size = new System.Drawing.Size(273, 21);
            this.txtDestDomain.TabIndex = 7;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 550);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(461, 22);
            this.statusStrip.TabIndex = 12;
            // 
            // frmFileMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 572);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFileMove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qiniu File Mover";
            this.Load += new System.EventHandler(this.frmFileMove_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSourceAK;
        private System.Windows.Forms.TextBox txtDestAK;
        private System.Windows.Forms.Button btnCreateFetchFile;
        private System.Windows.Forms.TextBox txtSourceSK;
        private System.Windows.Forms.TextBox txtSourceBucket;
        private System.Windows.Forms.Label lblSourceAK;
        private System.Windows.Forms.Label lblSourceSK;
        private System.Windows.Forms.Label lblSourceBucket;
        private System.Windows.Forms.Label lblDestAK;
        private System.Windows.Forms.Label lblDestSK;
        private System.Windows.Forms.Label lblDestBucket;
        private System.Windows.Forms.TextBox txtDestSK;
        private System.Windows.Forms.TextBox txtDestBacket;
        private System.Windows.Forms.Label lblSourceDomain;
        private System.Windows.Forms.TextBox txtSourceDomain;
        private System.Windows.Forms.CheckBox chkPrivateBucket;
        private System.Windows.Forms.Button btnCreateFetchBatch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Label lblDestDomain;
        private System.Windows.Forms.TextBox txtDestDomain;
        private System.Windows.Forms.StatusStrip statusStrip;
    }
}

