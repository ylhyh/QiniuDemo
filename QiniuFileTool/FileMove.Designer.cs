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
            this.SuspendLayout();
            // 
            // txtSourceAK
            // 
            this.txtSourceAK.Location = new System.Drawing.Point(129, 31);
            this.txtSourceAK.Name = "txtSourceAK";
            this.txtSourceAK.Size = new System.Drawing.Size(273, 21);
            this.txtSourceAK.TabIndex = 3;
            // 
            // txtDestAK
            // 
            this.txtDestAK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestAK.Location = new System.Drawing.Point(651, 31);
            this.txtDestAK.Name = "txtDestAK";
            this.txtDestAK.Size = new System.Drawing.Size(264, 21);
            this.txtDestAK.TabIndex = 3;
            // 
            // btnCreateFetchFile
            // 
            this.btnCreateFetchFile.Location = new System.Drawing.Point(129, 162);
            this.btnCreateFetchFile.Name = "btnCreateFetchFile";
            this.btnCreateFetchFile.Size = new System.Drawing.Size(273, 23);
            this.btnCreateFetchFile.TabIndex = 4;
            this.btnCreateFetchFile.Text = "生成Fetch源文件";
            this.btnCreateFetchFile.UseVisualStyleBackColor = true;
            this.btnCreateFetchFile.Click += new System.EventHandler(this.btnCreateFetchFile_Click);
            // 
            // txtSourceSK
            // 
            this.txtSourceSK.Location = new System.Drawing.Point(129, 58);
            this.txtSourceSK.Name = "txtSourceSK";
            this.txtSourceSK.Size = new System.Drawing.Size(273, 21);
            this.txtSourceSK.TabIndex = 3;
            // 
            // txtSourceBucket
            // 
            this.txtSourceBucket.Location = new System.Drawing.Point(129, 85);
            this.txtSourceBucket.Name = "txtSourceBucket";
            this.txtSourceBucket.Size = new System.Drawing.Size(273, 21);
            this.txtSourceBucket.TabIndex = 3;
            // 
            // lblSourceAK
            // 
            this.lblSourceAK.AutoSize = true;
            this.lblSourceAK.Location = new System.Drawing.Point(10, 34);
            this.lblSourceAK.Name = "lblSourceAK";
            this.lblSourceAK.Size = new System.Drawing.Size(113, 12);
            this.lblSourceAK.TabIndex = 6;
            this.lblSourceAK.Text = "Source Access Key:";
            // 
            // lblSourceSK
            // 
            this.lblSourceSK.AutoSize = true;
            this.lblSourceSK.Location = new System.Drawing.Point(10, 61);
            this.lblSourceSK.Name = "lblSourceSK";
            this.lblSourceSK.Size = new System.Drawing.Size(113, 12);
            this.lblSourceSK.TabIndex = 6;
            this.lblSourceSK.Text = "Source Secret Key:";
            // 
            // lblSourceBucket
            // 
            this.lblSourceBucket.AutoSize = true;
            this.lblSourceBucket.Location = new System.Drawing.Point(34, 88);
            this.lblSourceBucket.Name = "lblSourceBucket";
            this.lblSourceBucket.Size = new System.Drawing.Size(89, 12);
            this.lblSourceBucket.TabIndex = 6;
            this.lblSourceBucket.Text = "Source Bucket:";
            // 
            // lblDestAK
            // 
            this.lblDestAK.AutoSize = true;
            this.lblDestAK.Location = new System.Drawing.Point(502, 35);
            this.lblDestAK.Name = "lblDestAK";
            this.lblDestAK.Size = new System.Drawing.Size(143, 12);
            this.lblDestAK.TabIndex = 6;
            this.lblDestAK.Text = "Destination Access Key:";
            // 
            // lblDestSK
            // 
            this.lblDestSK.AutoSize = true;
            this.lblDestSK.Location = new System.Drawing.Point(502, 62);
            this.lblDestSK.Name = "lblDestSK";
            this.lblDestSK.Size = new System.Drawing.Size(143, 12);
            this.lblDestSK.TabIndex = 6;
            this.lblDestSK.Text = "Destination Secret Key:";
            // 
            // lblDestBucket
            // 
            this.lblDestBucket.AutoSize = true;
            this.lblDestBucket.Location = new System.Drawing.Point(526, 88);
            this.lblDestBucket.Name = "lblDestBucket";
            this.lblDestBucket.Size = new System.Drawing.Size(119, 12);
            this.lblDestBucket.TabIndex = 6;
            this.lblDestBucket.Text = "Destination Bucket:";
            // 
            // txtDestSK
            // 
            this.txtDestSK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestSK.Location = new System.Drawing.Point(651, 58);
            this.txtDestSK.Name = "txtDestSK";
            this.txtDestSK.Size = new System.Drawing.Size(264, 21);
            this.txtDestSK.TabIndex = 3;
            // 
            // txtDestBacket
            // 
            this.txtDestBacket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestBacket.Location = new System.Drawing.Point(651, 85);
            this.txtDestBacket.Name = "txtDestBacket";
            this.txtDestBacket.Size = new System.Drawing.Size(264, 21);
            this.txtDestBacket.TabIndex = 3;
            // 
            // lblSourceDomain
            // 
            this.lblSourceDomain.AutoSize = true;
            this.lblSourceDomain.Location = new System.Drawing.Point(34, 115);
            this.lblSourceDomain.Name = "lblSourceDomain";
            this.lblSourceDomain.Size = new System.Drawing.Size(89, 12);
            this.lblSourceDomain.TabIndex = 6;
            this.lblSourceDomain.Text = "Source Domain:";
            // 
            // txtSourceDomain
            // 
            this.txtSourceDomain.Location = new System.Drawing.Point(129, 112);
            this.txtSourceDomain.Name = "txtSourceDomain";
            this.txtSourceDomain.Size = new System.Drawing.Size(273, 21);
            this.txtSourceDomain.TabIndex = 3;
            // 
            // chkPrivateBucket
            // 
            this.chkPrivateBucket.AutoSize = true;
            this.chkPrivateBucket.Location = new System.Drawing.Point(129, 140);
            this.chkPrivateBucket.Name = "chkPrivateBucket";
            this.chkPrivateBucket.Size = new System.Drawing.Size(156, 16);
            this.chkPrivateBucket.TabIndex = 7;
            this.chkPrivateBucket.Text = "It\'s a private Bucket?";
            this.chkPrivateBucket.UseVisualStyleBackColor = true;
            // 
            // btnCreateFetchBatch
            // 
            this.btnCreateFetchBatch.Location = new System.Drawing.Point(651, 162);
            this.btnCreateFetchBatch.Name = "btnCreateFetchBatch";
            this.btnCreateFetchBatch.Size = new System.Drawing.Size(273, 23);
            this.btnCreateFetchBatch.TabIndex = 4;
            this.btnCreateFetchBatch.Text = "生成Fetch批处理文件";
            this.btnCreateFetchBatch.UseVisualStyleBackColor = true;
            this.btnCreateFetchBatch.Click += new System.EventHandler(this.btnCreateFetchBatch_Click);
            // 
            // frmFileMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 196);
            this.Controls.Add(this.chkPrivateBucket);
            this.Controls.Add(this.lblDestBucket);
            this.Controls.Add(this.lblSourceDomain);
            this.Controls.Add(this.lblSourceBucket);
            this.Controls.Add(this.lblDestSK);
            this.Controls.Add(this.lblSourceSK);
            this.Controls.Add(this.lblDestAK);
            this.Controls.Add(this.lblSourceAK);
            this.Controls.Add(this.btnCreateFetchBatch);
            this.Controls.Add(this.btnCreateFetchFile);
            this.Controls.Add(this.txtDestBacket);
            this.Controls.Add(this.txtDestSK);
            this.Controls.Add(this.txtDestAK);
            this.Controls.Add(this.txtSourceDomain);
            this.Controls.Add(this.txtSourceBucket);
            this.Controls.Add(this.txtSourceSK);
            this.Controls.Add(this.txtSourceAK);
            this.Name = "frmFileMove";
            this.Text = "七牛文件迁移";
            this.Load += new System.EventHandler(this.frmFileMove_Load);
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
    }
}

