using System;
using System.Windows.Forms;
using System.Net.Mail;

namespace E_mail_implements
{
    public partial class write_email : Form
    {
        public write_email()
        {
            InitializeComponent();
        }

        private void attach_btn_Click(object sender, EventArgs e)
        {
            MailMessage mmsg = new MailMessage();
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                mmsg.Attachments.Add(new Attachment(openFile.FileName));
            }
        }
    }
}
