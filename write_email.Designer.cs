namespace E_mail_implements
{
    partial class write_email
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
            this.content_richtextbox = new System.Windows.Forms.RichTextBox();
            this.receiver_notice = new System.Windows.Forms.Label();
            this.receiver = new System.Windows.Forms.TextBox();
            this.subject_notice = new System.Windows.Forms.Label();
            this.subject = new System.Windows.Forms.TextBox();
            this.content_notice = new System.Windows.Forms.Label();
            this.attach_btn = new System.Windows.Forms.Button();
            this.send_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // content_richtextbox
            // 
            this.content_richtextbox.Location = new System.Drawing.Point(70, 124);
            this.content_richtextbox.Name = "content_richtextbox";
            this.content_richtextbox.Size = new System.Drawing.Size(1186, 504);
            this.content_richtextbox.TabIndex = 6;
            this.content_richtextbox.Text = "";
            // 
            // receiver_notice
            // 
            this.receiver_notice.AutoSize = true;
            this.receiver_notice.Location = new System.Drawing.Point(13, 13);
            this.receiver_notice.Name = "receiver_notice";
            this.receiver_notice.Size = new System.Drawing.Size(51, 20);
            this.receiver_notice.TabIndex = 0;
            this.receiver_notice.Text = "收件人";
            // 
            // receiver
            // 
            this.receiver.Location = new System.Drawing.Point(70, 10);
            this.receiver.Name = "receiver";
            this.receiver.Size = new System.Drawing.Size(1186, 26);
            this.receiver.TabIndex = 1;
            // 
            // subject_notice
            // 
            this.subject_notice.AutoSize = true;
            this.subject_notice.Location = new System.Drawing.Point(13, 53);
            this.subject_notice.Name = "subject_notice";
            this.subject_notice.Size = new System.Drawing.Size(49, 20);
            this.subject_notice.TabIndex = 2;
            this.subject_notice.Text = "主   题";
            // 
            // subject
            // 
            this.subject.Location = new System.Drawing.Point(70, 51);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(1186, 26);
            this.subject.TabIndex = 3;
            // 
            // content_notice
            // 
            this.content_notice.AutoSize = true;
            this.content_notice.Location = new System.Drawing.Point(13, 124);
            this.content_notice.Name = "content_notice";
            this.content_notice.Size = new System.Drawing.Size(49, 20);
            this.content_notice.TabIndex = 5;
            this.content_notice.Text = "正   文";
            // 
            // attach_btn
            // 
            this.attach_btn.Location = new System.Drawing.Point(70, 83);
            this.attach_btn.Name = "attach_btn";
            this.attach_btn.Size = new System.Drawing.Size(80, 35);
            this.attach_btn.TabIndex = 4;
            this.attach_btn.Text = "添加附件";
            this.attach_btn.UseVisualStyleBackColor = true;
            // 
            // send_btn
            // 
            this.send_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.send_btn.Location = new System.Drawing.Point(17, 634);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(69, 28);
            this.send_btn.TabIndex = 7;
            this.send_btn.Text = "发送";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // write_email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1268, 685);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.attach_btn);
            this.Controls.Add(this.content_notice);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.subject_notice);
            this.Controls.Add(this.receiver);
            this.Controls.Add(this.receiver_notice);
            this.Controls.Add(this.content_richtextbox);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "write_email";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "写邮件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox content_richtextbox;
        private System.Windows.Forms.Label receiver_notice;
        private System.Windows.Forms.TextBox receiver;
        private System.Windows.Forms.Label subject_notice;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.Label content_notice;
        private System.Windows.Forms.Button attach_btn;
        private System.Windows.Forms.Button send_btn;
    }
}