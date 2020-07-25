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
            sign_in.SM.sendMessage(cmdData);

            cmdData = "RCPT TO: <" + receiver.Text + ">" + CRLF;
            sign_in.SM.sendMessage(cmdData);

            cmdData = "DATA" + CRLF;
            sign_in.SM.sendMessage(cmdData);

            cmdData = "from: " + MainWnd.accounts[MainWnd.current_index].email_address + CRLF
                        + "to: " + receiver.Text + CRLF
                        + "subject: " + subject.Text + CRLF + CRLF
                        + content_richtextbox.Text + CRLF + "." + CRLF;
            sign_in.SM.sendMessage(cmdData);

            Close();

        }
    }
}
