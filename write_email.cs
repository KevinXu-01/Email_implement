using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace E_mail_implements
{
    public partial class write_email : Form
    {
        private String cmdData;
        private String CRLF = "\r\n";
        private String filename;
        private String filedata;
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

            cmdData = "From: " + MainWnd.accounts[MainWnd.current_index].email_address + CRLF;
            cmdData += "To: " + receiver.Text + CRLF;
            cmdData += "Subject: " + subject.Text + CRLF;
            cmdData += "Mime-Version: 1.0" + CRLF;
            cmdData += "Content-Type: multipart/mixed;\r\n";
            cmdData += " boundary=\"__=_Part_Boundary_001_011991.029871\"\r\n\r\n";
            cmdData += "--__=_Part_Boundary_001_011991.029871\r\n";
            cmdData += "Content-Type: text/plain;\r\n";
            cmdData += " charset=\"gb2312\"\r\n";
            cmdData += "Content-Transfer-Encoding:quoted-printable\r\n\r\n";
            cmdData += content_richtextbox.Text + "\r\n\r\n";
            cmdData += "--__=_Part_Boundary_001_011991.029871\r\n";
            cmdData += "Content-Type: application/octet-stream;\r\n";
            //上面的顶到
            cmdData += " name=" + filename + "\r\n"; //同理至少空一格 
            cmdData += "Content-Transfer-Encoding: base64\r\n\r\n";
            cmdData += filedata + "\r\n\r\n";
            cmdData += "--__=_Part_Boundary_001_011991.029871--\r\n";
            cmdData += CRLF + "." + CRLF;

            MessageBox.Show(MainWnd.SM.getStatus());
            MainWnd.SM.sendMessage(cmdData);

            Close();

        }
        public static string EncodeBase64(string code)
        {
            string encode = "";
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(code);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            return encode;
        }

        private void attach_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = dialog.FileName;
            }

            String tmp = File.ReadAllText(filename, System.Text.Encoding.GetEncoding("gb2312"));
            filedata = EncodeBase64(tmp);
        }
    }
}
