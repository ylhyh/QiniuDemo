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
            this.lstSource = new System.Windows.Forms.CheckedListBox();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.lstDest = new System.Windows.Forms.CheckedListBox();
            this.txtSourceAK = new System.Windows.Forms.TextBox();
            this.txtDestAK = new System.Windows.Forms.TextBox();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.btnFetchFile = new System.Windows.Forms.Button();
            this.btnStartMove = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // lstSource
            // 
            this.lstSource.FormattingEnabled = true;
            this.lstSource.Location = new System.Drawing.Point(12, 125);
            this.lstSource.Name = "lstSource";
            this.lstSource.Size = new System.Drawing.Size(390, 340);
            this.lstSource.TabIndex = 0;
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMoveRight.Location = new System.Drawing.Point(408, 310);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(90, 23);
            this.btnMoveRight.TabIndex = 1;
            this.btnMoveRight.Text = "-->>";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            // 
            // lstDest
            // 
            this.lstDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lstDest.FormattingEnabled = true;
            this.lstDest.Location = new System.Drawing.Point(504, 125);
            this.lstDest.Name = "lstDest";
            this.lstDest.Size = new System.Drawing.Size(411, 340);
            this.lstDest.TabIndex = 2;
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
            // btnMoveLeft
            // 
            this.btnMoveLeft.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMoveLeft.Location = new System.Drawing.Point(408, 351);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(90, 23);
            this.btnMoveLeft.TabIndex = 1;
            this.btnMoveLeft.Text = "<<--";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            // 
            // btnFetchFile
            // 
            this.btnFetchFile.Location = new System.Drawing.Point(408, 32);
            this.btnFetchFile.Name = "btnFetchFile";
            this.btnFetchFile.Size = new System.Drawing.Size(75, 23);
            this.btnFetchFile.TabIndex = 4;
            this.btnFetchFile.Text = "读取源文件";
            this.btnFetchFile.UseVisualStyleBackColor = true;
            this.btnFetchFile.Click += new System.EventHandler(this.btnFetchFile_Click);
            // 
            // btnStartMove
            // 
            this.btnStartMove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStartMove.Location = new System.Drawing.Point(410, 500);
            this.btnStartMove.Name = "btnStartMove";
            this.btnStartMove.Size = new System.Drawing.Size(87, 28);
            this.btnStartMove.TabIndex = 5;
            this.btnStartMove.Text = "开始移动";
            this.btnStartMove.UseVisualStyleBackColor = true;
            this.btnStartMove.Click += new System.EventHandler(this.btnStartMove_Click);
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
            // frmFileMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 578);
            this.Controls.Add(this.lblDestBucket);
            this.Controls.Add(this.lblSourceBucket);
            this.Controls.Add(this.lblDestSK);
            this.Controls.Add(this.lblSourceSK);
            this.Controls.Add(this.lblDestAK);
            this.Controls.Add(this.lblSourceAK);
            this.Controls.Add(this.btnStartMove);
            this.Controls.Add(this.btnFetchFile);
            this.Controls.Add(this.txtDestBacket);
            this.Controls.Add(this.txtDestSK);
            this.Controls.Add(this.txtDestAK);
            this.Controls.Add(this.txtSourceBucket);
            this.Controls.Add(this.txtSourceSK);
            this.Controls.Add(this.txtSourceAK);
            this.Controls.Add(this.lstDest);
            this.Controls.Add(this.btnMoveLeft);
            this.Controls.Add(this.btnMoveRight);
            this.Controls.Add(this.lstSource);
            this.Name = "frmFileMove";
            this.Text = "七牛文件迁移";
            this.Load += new System.EventHandler(this.frmFileMove_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstSource;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.CheckedListBox lstDest;
        private System.Windows.Forms.TextBox txtSourceAK;
        private System.Windows.Forms.TextBox txtDestAK;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Button btnFetchFile;
        private System.Windows.Forms.Button btnStartMove;
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
    }
}

