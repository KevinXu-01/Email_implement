using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_mail_implements
{
    public partial class write_email : Form
    {
        private String cmdData;
        private String CRLF = "\r\n";
        public write_email()
        {
            InitializeComponent();
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            //Send Email
            cmdData = "MAIL FROM: <" + MainWnd.accounts[MainWnd.current_index].email_address + ">" + CRLF;
           MainWnd.SM.sendMessage(cmdData);

            cmdData = "RCPT TO: <" + receiver.Text + ">" + CRLF;
            MainWnd.SM.sendMessage(cmdData);

            cmdData = "DATA" + CRLF;
            MainWnd.SM.sendMessage(cmdData);

            cmdData = "from: " + MainWnd.accounts[MainWnd.current_index].email_address + CRLF
                        + "to: " + receiver.Text + CRLF
                        + "Subject: " + subject.Text + CRLF + CRLF
                        + content_richtextbox.Text + CRLF + "." + CRLF;
            MessageBox.Show(MainWnd.SM.getStatus());
            MainWnd.SM.sendMessage(cmdData);

            Close();

        }
    }
}
