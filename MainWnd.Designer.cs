namespace E_mail_implements
{
    partial class MainWnd
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.菜单 = new System.Windows.Forms.MenuStrip();
            this.AccountStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisconnectAndDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inbox_btn = new System.Windows.Forms.Button();
            this.write_email_btn = new System.Windows.Forms.Button();
            this.overview = new System.Windows.Forms.Panel();
            this.details = new System.Windows.Forms.Panel();
            this.content = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.sender_email = new System.Windows.Forms.Label();
            this.subject = new System.Windows.Forms.Label();
            this.菜单.SuspendLayout();
            this.details.SuspendLayout();
            this.SuspendLayout();
            // 
            // 菜单
            // 
            this.菜单.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.菜单.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AccountStripMenuItem,
            this.AboutStripMenuItem});
            this.菜单.Location = new System.Drawing.Point(0, 0);
            this.菜单.Name = "菜单";
            this.菜单.Size = new System.Drawing.Size(1264, 28);
            this.菜单.TabIndex = 0;
            this.菜单.Text = "账户";
            // 
            // AccountStripMenuItem
            // 
            this.AccountStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddAccountToolStripMenuItem,
            this.DisconnectToolStripMenuItem,
            this.DisconnectAndDeleteToolStripMenuItem});
            this.AccountStripMenuItem.Name = "AccountStripMenuItem";
            this.AccountStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.AccountStripMenuItem.Text = "账户";
            // 
            // AddAccountToolStripMenuItem
            // 
            this.AddAccountToolStripMenuItem.Name = "AddAccountToolStripMenuItem";
            this.AddAccountToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.AddAccountToolStripMenuItem.Text = "添加账户...";
            this.AddAccountToolStripMenuItem.Click += new System.EventHandler(this.AddAccountToolStripMenuItem_Click);
            // 
            // DisconnectToolStripMenuItem
            // 
            this.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem";
            this.DisconnectToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.DisconnectToolStripMenuItem.Text = "断开连接...";
            this.DisconnectToolStripMenuItem.Click += new System.EventHandler(this.DisconnectToolStripMenuItem_Click);
            // 
            // DisconnectAndDeleteToolStripMenuItem
            // 
            this.DisconnectAndDeleteToolStripMenuItem.Name = "DisconnectAndDeleteToolStripMenuItem";
            this.DisconnectAndDeleteToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.DisconnectAndDeleteToolStripMenuItem.Text = "断开连接并删除账户...";
            this.DisconnectAndDeleteToolStripMenuItem.Click += new System.EventHandler(this.DisconnectAndDeleteToolStripMenuItem_Click);
            // 
            // AboutStripMenuItem
            // 
            this.AboutStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.AboutStripMenuItem.Name = "AboutStripMenuItem";
            this.AboutStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.AboutStripMenuItem.Text = "关于";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.aboutToolStripMenuItem.Text = "关于...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // inbox_btn
            // 
            this.inbox_btn.BackColor = System.Drawing.SystemColors.Window;
            this.inbox_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inbox_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.inbox_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inbox_btn.Location = new System.Drawing.Point(0, 70);
            this.inbox_btn.Name = "inbox_btn";
            this.inbox_btn.Size = new System.Drawing.Size(91, 33);
            this.inbox_btn.TabIndex = 2;
            this.inbox_btn.Text = "收件箱";
            this.inbox_btn.UseVisualStyleBackColor = false;
            this.inbox_btn.Click += new System.EventHandler(this.inbox_btn_Click);
            this.inbox_btn.MouseEnter += new System.EventHandler(this.inbox_btn_MouseEnter);
            this.inbox_btn.MouseLeave += new System.EventHandler(this.inbox_btn_MouseLeave);
            // 
            // write_email_btn
            // 
            this.write_email_btn.BackColor = System.Drawing.SystemColors.Window;
            this.write_email_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.write_email_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.write_email_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.write_email_btn.Location = new System.Drawing.Point(0, 31);
            this.write_email_btn.Name = "write_email_btn";
            this.write_email_btn.Size = new System.Drawing.Size(91, 33);
            this.write_email_btn.TabIndex = 3;
            this.write_email_btn.Text = "写邮件";
            this.write_email_btn.UseVisualStyleBackColor = false;
            this.write_email_btn.Click += new System.EventHandler(this.write_email_btn_Click);
            this.write_email_btn.MouseEnter += new System.EventHandler(this.write_email_btn_MouseEnter);
            this.write_email_btn.MouseLeave += new System.EventHandler(this.write_email_btn_MouseLeave);
            // 
            // overview
            // 
            this.overview.Location = new System.Drawing.Point(97, 31);
            this.overview.Name = "overview";
            this.overview.Size = new System.Drawing.Size(246, 650);
            this.overview.TabIndex = 4;
            // 
            // details
            // 
            this.details.Controls.Add(this.content);
            this.details.Controls.Add(this.Date);
            this.details.Controls.Add(this.sender_email);
            this.details.Controls.Add(this.subject);
            this.details.Location = new System.Drawing.Point(350, 31);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(914, 650);
            this.details.TabIndex = 5;
            // 
            // content
            // 
            this.content.AutoSize = true;
            this.content.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.content.Location = new System.Drawing.Point(14, 136);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(0, 20);
            this.content.TabIndex = 3;
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Date.Location = new System.Drawing.Point(14, 91);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(0, 20);
            this.Date.TabIndex = 2;
            // 
            // sender_email
            // 
            this.sender_email.AutoSize = true;
            this.sender_email.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sender_email.Location = new System.Drawing.Point(14, 71);
            this.sender_email.Name = "sender_email";
            this.sender_email.Size = new System.Drawing.Size(0, 20);
            this.sender_email.TabIndex = 1;
            // 
            // subject
            // 
            this.subject.AutoSize = true;
            this.subject.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.subject.Location = new System.Drawing.Point(13, 28);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(0, 26);
            this.subject.TabIndex = 0;
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.details);
            this.Controls.Add(this.overview);
            this.Controls.Add(this.write_email_btn);
            this.Controls.Add(this.inbox_btn);
            this.Controls.Add(this.菜单);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.菜单;
            this.MaximizeBox = false;
            this.Name = "MainWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-mail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWnd_FormClosing);
            this.Load += new System.EventHandler(this.MainWnd_Load);
            this.菜单.ResumeLayout(false);
            this.菜单.PerformLayout();
            this.details.ResumeLayout(false);
            this.details.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip 菜单;
        private System.Windows.Forms.ToolStripMenuItem AccountStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisconnectAndDeleteToolStripMenuItem;
        private System.Windows.Forms.Button inbox_btn;
        private System.Windows.Forms.Button write_email_btn;
        private System.Windows.Forms.Panel overview;
        private System.Windows.Forms.Panel details;
        private System.Windows.Forms.Label subject;
        private System.Windows.Forms.Label content;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label sender_email;
    }
}

