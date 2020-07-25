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
            this.菜单.SuspendLayout();
            this.SuspendLayout();
            // 
            // 菜单
            // 
            this.菜单.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.菜单.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AccountStripMenuItem,
            this.AboutStripMenuItem});
            this.菜单.Location = new System.Drawing.Point(0, 0);
            this.菜单.Name = "菜单";
            this.菜单.Size = new System.Drawing.Size(1264, 25);
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
            this.AccountStripMenuItem.Size = new System.Drawing.Size(48, 21);
            this.AccountStripMenuItem.Text = "账户";
            this.AccountStripMenuItem.Click += new System.EventHandler(this.AccountStripMenuItem_Click);
            // 
            // AddAccountToolStripMenuItem
            // 
            this.AddAccountToolStripMenuItem.Name = "AddAccountToolStripMenuItem";
            this.AddAccountToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.AddAccountToolStripMenuItem.Text = "添加账户...";
            this.AddAccountToolStripMenuItem.Click += new System.EventHandler(this.AddAccountToolStripMenuItem_Click);
            // 
            // DisconnectToolStripMenuItem
            // 
            this.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem";
            this.DisconnectToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.DisconnectToolStripMenuItem.Text = "断开连接...";
            this.DisconnectToolStripMenuItem.Click += new System.EventHandler(this.DisconnectToolStripMenuItem_Click);
            // 
            // DisconnectAndDeleteToolStripMenuItem
            // 
            this.DisconnectAndDeleteToolStripMenuItem.Name = "DisconnectAndDeleteToolStripMenuItem";
            this.DisconnectAndDeleteToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.DisconnectAndDeleteToolStripMenuItem.Text = "断开连接并删除账户...";
            this.DisconnectAndDeleteToolStripMenuItem.Click += new System.EventHandler(this.DisconnectAndDeleteToolStripMenuItem_Click);
            // 
            // AboutStripMenuItem
            // 
            this.AboutStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.AboutStripMenuItem.Name = "AboutStripMenuItem";
            this.AboutStripMenuItem.Size = new System.Drawing.Size(48, 21);
            this.AboutStripMenuItem.Text = "关于";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
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
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.write_email_btn);
            this.Controls.Add(this.inbox_btn);
            this.Controls.Add(this.菜单);
            this.MainMenuStrip = this.菜单;
            this.Name = "MainWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-mail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWnd_FormClosing);
            this.Load += new System.EventHandler(this.MainWnd_Load);
            this.菜单.ResumeLayout(false);
            this.菜单.PerformLayout();
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
    }
}

