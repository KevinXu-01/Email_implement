namespace E_mail_implements
{
    partial class about_wnd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.about_notice = new System.Windows.Forms.Label();
            this.about = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // about_notice
            // 
            this.about_notice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.about_notice.AutoSize = true;
            this.about_notice.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.about_notice.Location = new System.Drawing.Point(122, 108);
            this.about_notice.Name = "about_notice";
            this.about_notice.Size = new System.Drawing.Size(62, 22);
            this.about_notice.TabIndex = 0;
            this.about_notice.Text = "关    于";
            // 
            // about
            // 
            this.about.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.about.AutoSize = true;
            this.about.Location = new System.Drawing.Point(30, 198);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(261, 100);
            this.about.TabIndex = 1;
            this.about.Text = "本软件系计算机网络课程设计软件设计。\r\n参与软件编写的有：\r\n林宇珂（学号：2018302060299），\r\n许静宇（学号：2018302060052），\r\n叶子" +
    "扬（学号：2018302120108）。";
            // 
            // about_wnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(326, 497);
            this.Controls.Add(this.about);
            this.Controls.Add(this.about_notice);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "about_wnd";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label about_notice;
        private System.Windows.Forms.Label about;
    }
}