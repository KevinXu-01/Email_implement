using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static Account[] accounts = new Account[10];//最多可容纳10个账户
        public static string hasAccount;
        public static int account_index;
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
                this.Hide();
                sign_in_wnd.ShowDialog();
            }
            else
            {
                string info;
                FileStream file = new FileStream(@"accounts.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamReader file_read = new StreamReader(file);
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
            }
        }

        private void MainWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(hasAccount != null)
            {
                FileStream file = new FileStream(@"accounts.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter file_write = new StreamWriter(file);
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

        private void 添加账户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sign_in sign_in_wnd = new sign_in();
            sign_in_wnd.ShowDialog();
        }
    }
}
