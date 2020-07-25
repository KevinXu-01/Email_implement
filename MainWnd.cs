using email_overview_display;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace E_mail_implements
{
    struct  mail
    {
        public string sender;//发送方
        public string date;//日期
        public string subject;//主题
        public string content;//正文
    }
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
        public static bool isLoggedIn; //判断是否已经登录，用于区分登录前打开登录界面(登录窗体关闭时退出程序)和登录后
                                                       //添加账户时打开登录界面(登录窗体关闭时不退出程序)
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

        private void write_email_btn_MouseEnter(object sender, EventArgs e)
        {
            write_email_btn.BackColor = System.Drawing.Color.LightGray;
        }

        private void write_email_btn_MouseLeave(object sender, EventArgs e)
        {
            write_email_btn.BackColor = System.Drawing.Color.White;
        }

        private void inbox_btn_MouseEnter(object sender, EventArgs e)
        {
            inbox_btn.BackColor = System.Drawing.Color.LightGray;
        }

        private void inbox_btn_MouseLeave(object sender, EventArgs e)
        {
            inbox_btn.BackColor = System.Drawing.Color.White;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about_wnd about = new about_wnd();
            about.ShowDialog();
        }

        private void inbox_btn_Click(object sender, EventArgs e)
        {
            int numberOfEmails = 10;
            mail[] mails = new mail[numberOfEmails];
            for(int i = 0; i < numberOfEmails; i++)
            {
                Point point = new Point(98, 31 + 68 * (i - 1));
                mails[i].sender = "xqg2000@qq.com";
                mails[i].subject = "这是主题";
                mails[i].date = "2020.07.24 18:40 GMT+8";
                mails[i].content = "这是正文这是正文这是正文这是正文这是正文这是正文";
                email_overview_display.email_overview_display_bg email = new email_overview_display.email_overview_display_bg();
                email.sender_email.Text = mails[i].sender;
                email.subject.Text = mails[i].subject;
                email.content.Text = mails[i].content.Substring(0, 10);
                email.Location = point;
                this.Controls.Add(email);
            }
        }

        private void email_overview_display_Click(object sender, EventArgs e)
        {
            //添加显示邮件内容的代码
        }

        private void write_email_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 10; i++)//1次循环无法清理干净，所以执行多次循环
            {
                foreach (Control control in Controls)
                {
                    if (control is email_overview_display_bg)
                        control.Dispose();
                }
            }
        }

        private void AccountStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
