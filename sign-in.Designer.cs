namespace E_mail_implements
{
    partial class sign_in
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
            this.welcome_notice = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.email_address_notice = new System.Windows.Forms.Label();
            this.password_notice = new System.Windows.Forms.Label();
            this.pop3_server_notice = new System.Windows.Forms.Label();
            this.pop3_server_address = new System.Windows.Forms.TextBox();
            this.sign_in_button = new System.Windows.Forms.Button();
            this.smtp_server_address = new System.Windows.Forms.TextBox();
            this.smtp_server_notice = new System.Windows.Forms.Label();
            this.automatic_log_in = new System.Windows.Forms.CheckBox();
            this.sign_in_combobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // welcome_notice
            // 
            this.welcome_notice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.welcome_notice.AutoSize = true;
            this.welcome_notice.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.welcome_notice.Location = new System.Drawing.Point(48, 67);
            this.welcome_notice.Name = "welcome_notice";
            this.welcome_notice.Size = new System.Drawing.Size(269, 26);
            this.welcome_notice.TabIndex = 1;
            this.welcome_notice.Text = "欢迎使用E-mail implements";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.password.ForeColor = System.Drawing.SystemColors.WindowText;
            this.password.Location = new System.Drawing.Point(74, 216);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(212, 26);
            this.password.TabIndex = 3;
            // 
            // email_address_notice
            // 
            this.email_address_notice.AutoSize = true;
            this.email_address_notice.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.email_address_notice.Location = new System.Drawing.Point(70, 132);
            this.email_address_notice.Name = "email_address_notice";
            this.email_address_notice.Size = new System.Drawing.Size(121, 20);
            this.email_address_notice.TabIndex = 4;
            this.email_address_notice.Text = "请输入邮件地址：";
            // 
            // password_notice
            // 
            this.password_notice.AutoSize = true;
            this.password_notice.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.password_notice.Location = new System.Drawing.Point(70, 193);
            this.password_notice.Name = "password_notice";
            this.password_notice.Size = new System.Drawing.Size(205, 20);
            this.password_notice.TabIndex = 5;
            this.password_notice.Text = "请输入邮件服务商提供的口令：";
            // 
            // pop3_server_notice
            // 
            this.pop3_server_notice.AutoSize = true;
            this.pop3_server_notice.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pop3_server_notice.Location = new System.Drawing.Point(70, 254);
            this.pop3_server_notice.Name = "pop3_server_notice";
            this.pop3_server_notice.Size = new System.Drawing.Size(170, 20);
            this.pop3_server_notice.TabIndex = 6;
            this.pop3_server_notice.Text = "请输入pop3服务器地址：";
            // 
            // pop3_server_address
            // 
            this.pop3_server_address.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pop3_server_address.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pop3_server_address.Location = new System.Drawing.Point(74, 277);
            this.pop3_server_address.Name = "pop3_server_address";
            this.pop3_server_address.Size = new System.Drawing.Size(212, 26);
            this.pop3_server_address.TabIndex = 7;
            // 
            // sign_in_button
            // 
            this.sign_in_button.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sign_in_button.Location = new System.Drawing.Point(140, 433);
            this.sign_in_button.Name = "sign_in_button";
            this.sign_in_button.Size = new System.Drawing.Size(69, 28);
            this.sign_in_button.TabIndex = 10;
            this.sign_in_button.Text = "登录";
            this.sign_in_button.UseVisualStyleBackColor = true;
            this.sign_in_button.Click += new System.EventHandler(this.sign_in_button_Click);
            // 
            // smtp_server_address
            // 
            this.smtp_server_address.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.smtp_server_address.ForeColor = System.Drawing.SystemColors.WindowText;
            this.smtp_server_address.Location = new System.Drawing.Point(74, 342);
            this.smtp_server_address.Name = "smtp_server_address";
            this.smtp_server_address.Size = new System.Drawing.Size(212, 26);
            this.smtp_server_address.TabIndex = 8;
            // 
            // smtp_server_notice
            // 
            this.smtp_server_notice.AutoSize = true;
            this.smtp_server_notice.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.smtp_server_notice.Location = new System.Drawing.Point(70, 319);
            this.smtp_server_notice.Name = "smtp_server_notice";
            this.smtp_server_notice.Size = new System.Drawing.Size(168, 20);
            this.smtp_server_notice.TabIndex = 9;
            this.smtp_server_notice.Text = "请输入smtp服务器地址：";
            // 
            // automatic_log_in
            // 
            this.automatic_log_in.AutoSize = true;
            this.automatic_log_in.Checked = true;
            this.automatic_log_in.CheckState = System.Windows.Forms.CheckState.Checked;
            this.automatic_log_in.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.automatic_log_in.Location = new System.Drawing.Point(74, 374);
            this.automatic_log_in.Name = "automatic_log_in";
            this.automatic_log_in.Size = new System.Drawing.Size(112, 24);
            this.automatic_log_in.TabIndex = 11;
            this.automatic_log_in.Text = "下次自动登录";
            this.automatic_log_in.UseVisualStyleBackColor = true;
            // 
            // sign_in_combobox
            // 
            this.sign_in_combobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sign_in_combobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sign_in_combobox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sign_in_combobox.FormattingEnabled = true;
            this.sign_in_combobox.Location = new System.Drawing.Point(74, 155);
            this.sign_in_combobox.Name = "sign_in_combobox";
            this.sign_in_combobox.Size = new System.Drawing.Size(212, 28);
            this.sign_in_combobox.TabIndex = 12;
            this.sign_in_combobox.TextChanged += new System.EventHandler(this.sign_in_combobox_TextChanged);
            // 
            // sign_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(362, 512);
            this.Controls.Add(this.sign_in_combobox);
            this.Controls.Add(this.automatic_log_in);
            this.Controls.Add(this.smtp_server_address);
            this.Controls.Add(this.smtp_server_notice);
            this.Controls.Add(this.sign_in_button);
            this.Controls.Add(this.pop3_server_address);
            this.Controls.Add(this.pop3_server_notice);
            this.Controls.Add(this.password_notice);
            this.Controls.Add(this.email_address_notice);
            this.Controls.Add(this.password);
            this.Controls.Add(this.welcome_notice);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "sign_in";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录到您的账户";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.sign_in_FormClosing);
            this.Load += new System.EventHandler(this.sign_in_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label welcome_notice;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label email_address_notice;
        private System.Windows.Forms.Label password_notice;
        private System.Windows.Forms.Label pop3_server_notice;
        private System.Windows.Forms.TextBox pop3_server_address;
        private System.Windows.Forms.Button sign_in_button;
        private System.Windows.Forms.TextBox smtp_server_address;
        private System.Windows.Forms.Label smtp_server_notice;
        private System.Windows.Forms.CheckBox automatic_log_in;
        public System.Windows.Forms.ComboBox sign_in_combobox;
    }
}