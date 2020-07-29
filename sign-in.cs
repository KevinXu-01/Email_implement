using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace E_mail_implements
{
    public partial class sign_in : Form
    {
        private bool isMatch;
        private int index;
        private bool isLogInBtnPressed;
        private String cmd;
        private const String CRLF = "\r\n";

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

            //POP3_socket连接
            TcpClient Server;
            NetworkStream StrmWtr;
            StreamReader StrmRdr;
            byte[] szData;
            String cmdData;
            const String CRLF = "\r\n";
            Server = new TcpClient(pop3_server_address.Text, 110);
            try
            {
                StrmWtr = Server.GetStream();
                StrmRdr = new StreamReader(Server.GetStream());
                cmdData = "USER " + sign_in_combobox.Text + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                StrmWtr.Write(szData, 0, szData.Length);
                StrmRdr.ReadLine();
                cmdData = "PASS " + password.Text + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                StrmWtr.Write(szData, 0, szData.Length);
                StrmRdr.ReadLine();
                cmdData = "STAT" + CRLF;
                szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                StrmWtr.Write(szData, 0, szData.Length);
                string s = StrmRdr.ReadLine();
                //Console.WriteLine(s);
                if (s[0] == '-')
                {
                    MessageBox.Show("POP3连接时出错，请检查您的账户和授权码");
                    return;
                }
                MainWnd.StrmWtr = StrmWtr;
                MainWnd.StrmRdr = StrmRdr;
                MainWnd.numberOfEmails = getNum(StrmRdr.ReadLine());
            }
            //错误处理 
            catch (InvalidOperationException err)
            {
                Console.WriteLine("ERROR: " + err.Message.ToString());
            }

            //连接SMTP服务器
            MainWnd.SM.Connect(MainWnd.accounts[MainWnd.current_index].smtp_server_address);
            cmd = "HELO " + MainWnd.accounts[MainWnd.current_index].smtp_server_address + CRLF;
            MainWnd.SM.sendMessage(cmd);

            cmd = "AUTH LOGIN" + CRLF;
            MainWnd.SM.sendMessage(cmd);

            cmd = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(MainWnd.accounts[MainWnd.current_index].email_address)) + CRLF;
            MainWnd.SM.sendMessage(cmd);

            cmd = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(MainWnd.accounts[MainWnd.current_index].password)) + CRLF;
            MainWnd.SM.sendMessage(cmd);

            Close();
        }
        public int getNum(String Envelop)//获得主题
        {
            string reg = "(?<=( ))[.\\s\\S]*?(?=( ))";
            string a = GetSingle(Envelop, reg);
            return int.Parse(a);
        }
        private string GetSingle(string value, string regx)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            bool isMatch = Regex.IsMatch(value, regx);
            if (!isMatch)
            {
                return null;
            }
            MatchCollection matchCol = Regex.Matches(value, regx);

            string result = matchCol[0].Value;

            return result;
        }
        static String getSatus(StreamReader r)
        {
            String ret = r.ReadLine();
            return ret;
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