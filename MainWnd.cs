using email_overview_display;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Windows.Forms;

namespace E_mail_implements
{
    public struct mail
    {
        public string sender;//发送方
        public string date;//日期
        public string subject;//主题
        public string content;//正文
        public bool hasFile;//是否有附件（还没写）
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
        public static int numberOfEmails = 20;
        public static mail[] mails = new mail[numberOfEmails];
        public MainWnd()
        {
            InitializeComponent();
        }

        private void MainWnd_Load(object sender, EventArgs e)
        {
            overview.AutoScroll = true;
            details.AutoScroll = true;
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
            //删除可能存在的控件
            //删除收件箱自定义控件
            for (int i = 0; i <= 10; i++)//1次循环无法清理干净，所以执行多次循环
            {
                foreach (Control control in Controls)
                {
                    if (control is email_overview_display_bg)
                        control.Dispose();
                }
            }
            //将右侧内容清空
            for (int i = 0; i <= 10; i++)//1次循环无法清理干净，所以执行多次循环
            {
                foreach (Control control in details.Controls)
                {
                    if (control is LinkLabel || (control is Label && control.Text == "附件列表：") || control is Button)
                        control.Dispose();
                }
            }
            subject.Text = null;
            sender_email.Text = null;
            Date.Text = null;
            content.Text = null;

            //添加删除信件编辑代码
            sign_in sign_in_wnd = new sign_in();
            sign_in_wnd.ShowDialog();
        }

        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isLoggedIn = false;
            //删除可能存在的控件
            //删除收件箱自定义控件
            for (int i = 0; i <= 10; i++)//1次循环无法清理干净，所以执行多次循环
            {
                foreach (Control control in overview.Controls)
                {
                    if (control is email_overview_display_bg)
                        control.Dispose();
                }
            }
            //将右侧内容清空
            for (int i = 0; i <= 10; i++)//1次循环无法清理干净，所以执行多次循环
            {
                foreach (Control control in details.Controls)
                {
                    if (control is LinkLabel || (control is Label && control.Text == "附件列表：") || control is Button)
                        control.Dispose();
                }
            }
            subject.Text = null;
            sender_email.Text = null;
            Date.Text = null;
            content.Text = null;

            //添加删除信件编辑代码


            sign_in sign_in_wnd = new sign_in();
            Hide();
            sign_in_wnd.ShowDialog();
            Show();
        }

        private void DisconnectAndDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isLoggedIn = false;
            //删除可能存在的控件
            //删除收件箱自定义控件
            for (int i = 0; i <= 10; i++)//1次循环无法清理干净，所以执行多次循环
            {
                foreach (Control control in overview.Controls)
                {
                    if (control is email_overview_display_bg)
                        control.Dispose();
                }
            }
            //将右侧内容清空
            for (int i = 0; i <= 10; i++)//1次循环无法清理干净，所以执行多次循环
            {
                foreach (Control control in details.Controls)
                {
                    if (control is LinkLabel || (control is Label && control.Text == "附件列表：") || control is Button)
                        control.Dispose();
                }
            }
            subject.Text = null;
            sender_email.Text = null;
            Date.Text = null;
            content.Text = null;


            //添加删除信件编辑部分控件的代码



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
            write_email_btn.BackColor = Color.LightGray;
        }

        private void write_email_btn_MouseLeave(object sender, EventArgs e)
        {
            write_email_btn.BackColor = Color.White;
        }

        private void inbox_btn_MouseEnter(object sender, EventArgs e)
        {
            inbox_btn.BackColor = Color.LightGray;
        }

        private void inbox_btn_MouseLeave(object sender, EventArgs e)
        {
            inbox_btn.BackColor = Color.White;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about_wnd about = new about_wnd();
            about.ShowDialog();
        }

        private void inbox_btn_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < numberOfEmails; i++)
            {
                Point point = new Point(0, 68 * i);
                
                /////
                mails[i].sender = "xqg2000@qq.com";
                mails[i].subject = "这是主题";
                mails[i].date = "2020.07.24 18:40 GMT+8";
                //for (int j = 0; j <= 40; j++)
                    mails[i].content += "这是正文" + Convert.ToString(i) + "\n";
                mails[i].hasFile = true;
                email_overview_display_bg email_overview = new email_overview_display_bg();
                email_overview.Name = Convert.ToString(i);//i从0开始
                email_overview.sender_email.Text = mails[i].sender;
                email_overview.subject.Text = mails[i].subject;
                email_overview.content.Text = mails[i].content.Substring(0, 5);
                email_overview.Location = point;
                email_overview.Click += new EventHandler(email_overview_display_Click);
                overview.Controls.Add(email_overview);
            }
        }

        private void email_overview_display_Click(object sender, EventArgs e)
        {
            email_overview_display_bg temp = (email_overview_display_bg)sender;
            int index = Convert.ToInt32(temp.Name);
            subject.Text = mails[index].subject;
            sender_email.Text = mails[index].sender;
            Date.Text = mails[index].date;
            content.Text = mails[index].content;
            for (int i = 0; i <= 10; i++)//1次循环无法清理干净，所以执行多次循环
            {
                foreach (Control control in details.Controls)
                {
                    if (control is LinkLabel || (control is Label && control.Text == "附件列表："))
                        control.Dispose();
                    if (control is Button && control.Text == "删除")
                        control.Enabled = false;
                }
            }
            Button delete_btn = new Button();
            // 
            // delete_btn
            // 
            delete_btn.BackColor = SystemColors.Window;
            delete_btn.Cursor = Cursors.Hand;
            delete_btn.FlatStyle = FlatStyle.Popup;
            delete_btn.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
            delete_btn.Location = new Point(800, 15);/////////////////
            delete_btn.Name = Convert.ToString(index);
            delete_btn.Size = new Size(60, 33);
            delete_btn.Text = "删除";
            delete_btn.UseVisualStyleBackColor = false;
            delete_btn.Click += new EventHandler(delete_btn_Click);
            delete_btn.MouseEnter += new EventHandler(delete_btn_MouseEnter);
            //delete_btn.MouseLeave += new EventHandler(delete_btn_MouseLeave);
            details.Controls.Add(delete_btn);

            if (mails[index].hasFile == true)
            {
                List<int> files = new List<int>();//附件列表
                files.Add(index);
                files.Add(index + 1);
                Label attachment_notice = new Label();

                //
                // attachment_notice
                //
                attachment_notice.AutoSize = true;
                attachment_notice.Font = new Font("微软雅黑", 14.5F, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
                attachment_notice.Location = new Point(14, content.Location.Y + content.Size.Height + 100);
                attachment_notice.Name = "attachments";
                attachment_notice.Size = new Size(0, 20);
                attachment_notice.Text = "附件列表：";

                details.Controls.Add(attachment_notice);



                for (int i = 0; i < files.Count; i++)
                {
                    LinkLabel attachments = new LinkLabel();

                    attachments.Text = Convert.ToString(files[i]);
                    //
                    // attachments
                    //
                    attachments.AutoSize = true;
                    attachments.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
                    attachments.Location = new Point(14, attachment_notice.Location.Y + attachment_notice.Size.Height + i * 20);
                    attachments.Name = "attachments";
                    attachments.Size = new Size(0, 20);

                    details.Controls.Add(attachments);
                }
            }

        }
        private void delete_btn_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            foreach(Control control in details.Controls)
            {
                if (control is Button && control.Name == temp.Name)
                    control.Dispose();
            }
            ////////////////////////////////////////////////////////////////////////BUGS!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //左侧重新排列
            for (int i = Convert.ToInt32(temp.Name) + 1; i < numberOfEmails; i++)
            {
                email_overview_display_bg temp_overview_0 = (email_overview_display_bg)overview.Controls.Find(Convert.ToString(i - 1), true)[0];
                email_overview_display_bg temp_overview_1 = (email_overview_display_bg)overview.Controls.Find(Convert.ToString(i), true)[0];
                temp_overview_1.sender_email.Text = temp_overview_0.sender_email.Text;
                temp_overview_1.subject.Text = temp_overview_0.subject.Text;
                temp_overview_1.content.Text = temp_overview_0.content.Text;
                temp_overview_1.Location = temp_overview_0.Location;
                temp_overview_1.Name = temp_overview_0.Name;
                overview.Controls.Remove((email_overview_display_bg)overview.Controls.Find(Convert.ToString(i - 1), true)[0]);
                overview.Controls.Add(temp_overview_1);
            }

            //删除邮件
            for (int i = Convert.ToInt32(temp.Name); i < numberOfEmails - 1; i++)
            {
                mails[i] = mails[i + 1];
            }
            mails[numberOfEmails - 1].sender = null;
            mails[numberOfEmails - 1].subject = null;
            mails[numberOfEmails - 1].date = null;
            mails[numberOfEmails - 1].content = null;
            mails[numberOfEmails - 1].hasFile = false;
            numberOfEmails--;



            //将右侧内容清空
            for (int i = 0; i <= 10; i++)//1次循环无法清理干净，所以执行多次循环
            {
                foreach (Control control in details.Controls)
                {
                    if (control is LinkLabel || (control is Label && control.Text == "附件列表："))
                        control.Dispose();
                }
            }
            subject.Text = null;
            sender_email.Text = null;
            Date.Text = null;
            content.Text = null;


            /*
            //删除自定义控件
            foreach (Control control in overview.Controls)
            {
                if (control is email_overview_display_bg && control.Name == temp.Name)
                    control.Dispose();
            }
            */

        }
        private void delete_btn_MouseEnter(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            temp.BackColor = Color.LightGray;
        }
        private void delete_btn_MouseLeave(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            temp.BackColor = Color.White;
        }

        private void write_email_btn_Click(object sender, EventArgs e)
        {
            //添加编写邮件界面的代码
            write_email write_email_wnd = new write_email();
            write_email_wnd.ShowDialog();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}