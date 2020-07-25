using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace E_mail_implements
{
    public partial class sign_in : Form
    {
        private bool isMatch;
        private int index;
        private bool isLogInBtnPressed;
        private String cmd;
        private String CRLF = "\r\n";

        public static SmtpMail SM = new SmtpMail();

        public sign_in()
        {
            InitializeComponent();
        }

        private void sign_in_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sign_in_combobox.Text != "" && password.Text != "" && pop3_server_address.Text != ""
                && smtp_server_address.Text != "" && isLogInBtnPressed || MainWnd.isLoggedIn)
            {

            }
            else
            {
                Application.Exit();
            }
        }

        private void sign_in_Load(object sender, EventArgs e)
        {
            isMatch = false;
            index = 0;
            isLogInBtnPressed = false;
            for (int i = 0; i <= MainWnd.account_index; i++)
                sign_in_combobox.Items.Add(MainWnd.accounts[i].email_address);
        }

        private void sign_in_button_Click(object sender, EventArgs e)
        {
            isLogInBtnPressed = true;
            if (automatic_log_in.CheckState == CheckState.Checked)
                MainWnd.isAutomaticLogin = true;
            else
                MainWnd.isAutomaticLogin = false;

            if (isMatch == true)
                MainWnd.current_index = index;
            else if (sign_in_combobox.Text != "" && password.Text != ""
                && pop3_server_address.Text != "" && smtp_server_address.Text != "")
            {
                MainWnd.account_index++;
                MainWnd.accounts[MainWnd.account_index].email_address = sign_in_combobox.Text;
                MainWnd.accounts[MainWnd.account_index].password = password.Text;
                MainWnd.accounts[MainWnd.account_index].pop3_server_address = pop3_server_address.Text;
                MainWnd.accounts[MainWnd.account_index].smtp_server_address = smtp_server_address.Text;
                MainWnd.hasAccount = " ";
                MainWnd.current_index = MainWnd.account_index;
            }
            else
            {
                MainWnd.accounts[MainWnd.account_index].email_address = null;
                MainWnd.accounts[MainWnd.account_index].password = null;
                MainWnd.accounts[MainWnd.account_index].pop3_server_address = null;
                MainWnd.accounts[MainWnd.account_index].smtp_server_address = null;
                MainWnd.hasAccount = null;
            }

            //添加socket连接部分的代码
            //连接SMTP服务器
            Cursor c = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor; //置鼠标状态为等待
            SM.Connect(MainWnd.accounts[MainWnd.current_index].smtp_server_address);

            cmd = "HELO " + MainWnd.accounts[MainWnd.current_index].smtp_server_address + CRLF;
            SM.sendMessage(cmd);
            

            cmd = "AUTH LOGIN" + CRLF;
            SM.sendMessage(cmd);

            cmd = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(MainWnd.accounts[MainWnd.current_index].email_address)) + CRLF;
            SM.sendMessage(cmd);

            cmd = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(MainWnd.accounts[MainWnd.current_index].password)) + CRLF;
            SM.sendMessage(cmd);

            Cursor.Current = c;

            Close();
        }

        private void sign_in_combobox_TextChanged(object sender, EventArgs e)
        {
            isMatch = false;
            for (int i = 0; i <= MainWnd.account_index; i++)
                if (MainWnd.accounts[i].email_address == sign_in_combobox.Text)
                {
                    isMatch = true;
                    index = i;
                }
            if (isMatch)
            {
                password.Text = MainWnd.accounts[index].password;
                pop3_server_address.Text = MainWnd.accounts[index].pop3_server_address;
                smtp_server_address.Text = MainWnd.accounts[index].smtp_server_address;
            }
            else
            {
                password.Text = "";
                pop3_server_address.Text = "";
                smtp_server_address.Text = "";
            }
        }
    }
}