using System;
using System.IO;
using System.Windows.Forms;

namespace E_mail_implements
{
    public struct Account
    {
        public string email_address;
        public string password;
        public string pop3_server_address;
        public string smtp_server_address;
    }
    public partial class MainWnd : Form
    {
        public static MainWnd mainwnd = new MainWnd();//复制一个引用，以便调用
        public static Account[] accounts = new Account[10];//最多可容纳10个账户
        public static string hasAccount;//判断是否有账户
        public static int account_index;//始终为账户的数量减1
        public static bool isAutomaticLogin;//判断是否自动登录
        public static int current_index;//当前使用的账户的索引
        public static bool isLoggedIn;
        public MainWnd()
        {
            InitializeComponent();
        }

        private void MainWnd_Load(object sender, EventArgs e)
        {
            account_index = -1;
            
            //accounts.dat存储账户信息，如果该文件为空，说明没有账户信息，此时需要弹出登录窗口
            sign_in sign_in_wnd = new sign_in();
            FileStream file_temp = new FileStream(@"accounts.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader file_read_temp = new StreamReader(file_temp);
            hasAccount = file_read_temp.ReadLine();
            file_read_temp.Close();
            file_temp.Close();
            if (hasAccount == null)
            {
                Close();
                sign_in_wnd.ShowDialog();
                Show();
                isLoggedIn = true;
            }
            else
            {
                string info;
                FileStream file = new FileStream(@"accounts.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamReader file_read = new StreamReader(file);
                //读出控制信息
                isAutomaticLogin = (Convert.ToInt32(file_read.ReadLine()) == 1) ? true : false;
                current_index = Convert.ToInt32(file_read.ReadLine());

                info = file_read.ReadLine();
                int i = 0;//i是计次变量
                while (info != null)
                {
                    switch(i % 4)
                    {
                        case 0: accounts[i / 4].email_address = info; break;
                        case 1: accounts[i / 4].password = info; break;
                        case 2: accounts[i / 4].pop3_server_address = info; break;
                        case 3: accounts[i / 4].smtp_server_address = info; break;
                    }
                    i++;
                    info = file_read.ReadLine();
                }
                file_read.Close();
                file.Close();
                account_index = i / 4 - 1;//此时account_index为实际最后一个账户的索引数(从0开始)

                //如果isAutomaticLogin为false，说明不自动登录，也需要弹出登录窗口
                if (isAutomaticLogin == false)
                {
                    Hide();
                    sign_in_wnd.ShowDialog();
                    Show();
                    isLoggedIn = true;
                }
            }
        }

        private void MainWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(hasAccount != null)
            {
                File.Delete(@"accounts.dat");
                FileStream file = new FileStream(@"accounts.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter file_write = new StreamWriter(file);
                //先写入控制参数
                file_write.WriteLine(Convert.ToString(isAutomaticLogin == true ? 1 : 0));
                file_write.WriteLine(Convert.ToString(current_index));

                //再写入账户信息
                for (int i = 0; i <= account_index; i++)
                {
                    file_write.WriteLine(accounts[i].email_address);
                    file_write.WriteLine(accounts[i].password);
                    file_write.WriteLine(accounts[i].pop3_server_address);
                    file_write.WriteLine(accounts[i].smtp_server_address);
                }
                file_write.Close();
                file.Close();
            }
        }

        private void AddAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sign_in sign_in_wnd = new sign_in();
            sign_in_wnd.ShowDialog();
        }

        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sign_in sign_in_wnd = new sign_in();
            Hide();
            sign_in_wnd.ShowDialog();
            Show();
        }

        private void DisconnectAndDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sign_in sign_in_wnd = new sign_in();

            //删除账户
            for (int i = current_index; i <= account_index - 1; i++)
            {
                accounts[i] = accounts[i + 1];
            }
            accounts[account_index].email_address=null;
            accounts[account_index].password = null;
            accounts[account_index].pop3_server_address = null;
            accounts[account_index].smtp_server_address = null;
            account_index--;
            Hide();
            sign_in_wnd.ShowDialog();
            Show();
        }
    }
}
