using email_overview_display;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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
        public static bool isLoggedIn; //判断是否已经登录，用于区分登录前打开登录界面(登录窗体关闭时退出程序)和登录后
        public static NetworkStream StrmWtr;
        public static SmtpMail SM=new SmtpMail();
        public static StreamReader StrmRdr;//添加账户时打开登录界面(登录窗体关闭时不退出程序)
        public static int numberOfEmails;
        List<mail> mails;
        List<email_overview_display_bg> overviews;
        private String cmd;
        private const String CRLF = "\r\n";
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
                    mails = new List<mail>();

                    int count = numberOfEmails;
                    while (count > 0)
                    {
                        String cmdData;
                        byte[] szData;
                        string szTemp;
                        StringBuilder str = new StringBuilder();
                        const String CRLF = "\r\n";
                        cmdData = "RETR " + count + CRLF;
                        szData = Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                        StrmWtr.Write(szData, 0, szData.Length);
                        szTemp = getSatus(StrmRdr);

                        if (szTemp[0] != '-')
                        {
                            while (szTemp != ".")
                            {
                                str.Append(szTemp + "\r\n");
                                szTemp = StrmRdr.ReadLine();
                            }
                        }

                        String a = str.ToString();
                        mail mail = new mail(a);
                        mails.Add(mail);
                        count--;
                    }
                }
                else 
                {
                    //添加socket连接部分的代码
                    TcpClient Server;
                    NetworkStream StrmWtr;
                    StreamReader StrmRdr;
                    byte[] szData;
                    String cmdData;
                    const String CRLF = "\r\n";
                    Server = new TcpClient(accounts[current_index].pop3_server_address, 110);
                    try
                    {
                        StrmWtr = Server.GetStream();
                        StrmRdr = new StreamReader(Server.GetStream());

                        cmdData = "USER " + accounts[current_index].email_address + CRLF;
                        szData = Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                        StrmWtr.Write(szData, 0, szData.Length);
                        StrmRdr.ReadLine();
                        cmdData = "PASS " + accounts[current_index].password + CRLF;
                        szData = Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                        StrmWtr.Write(szData, 0, szData.Length);
                        StrmRdr.ReadLine();
                        cmdData = "STAT" + CRLF;
                        szData = Encoding.ASCII.GetBytes(cmdData.ToCharArray());
                        StrmWtr.Write(szData, 0, szData.Length);
                        string s = StrmRdr.ReadLine();
                        Console.WriteLine(s);
                        if (s[0] == '-')
                        {
                            MessageBox.Show("POP3连接时出错，请检查您的账户和授权码");
                            return;
                        }


                        MainWnd.StrmWtr = StrmWtr;
                        MainWnd.StrmRdr = StrmRdr;
                        numberOfEmails = getNum(StrmRdr.ReadLine());
                    }
                    catch (InvalidOperationException err)
                    {
                        Console.WriteLine("ERROR: " + err.Message.ToString());
                    }


                    //SMTP
                    SM.Connect(accounts[current_index].smtp_server_address);
                    cmd = "HELO " + accounts[current_index].smtp_server_address + CRLF;
                    SM.sendMessage(cmd);
                    cmd = "AUTH LOGIN" + CRLF;
                    SM.sendMessage(cmd);
                    cmd = Convert.ToBase64String(Encoding.ASCII.GetBytes(accounts[current_index].email_address)) + CRLF;
                    SM.sendMessage(cmd);
                    cmd = Convert.ToBase64String(Encoding.ASCII.GetBytes(accounts[current_index].password)) + CRLF;
                    SM.sendMessage(cmd);



                    mails = new List<mail>();
                    int count = numberOfEmails;
                    while (count > 0)
                    {
                        string cmdData_1;
                        byte[] szData_1;
                        string szTemp;
                        StringBuilder str = new StringBuilder();
                        const String CRLF_1 = "\r\n";
                        cmdData_1 = "RETR " + count + CRLF_1;
                        szData_1 = Encoding.ASCII.GetBytes(cmdData_1.ToCharArray());
                        MainWnd.StrmWtr.Write(szData_1, 0, szData_1.Length);
                        szTemp = getSatus(MainWnd.StrmRdr);

                        if (szTemp[0] != '-')
                        {
                            while (szTemp != ".")
                            {
                                str.Append(szTemp + "\r\n");
                                szTemp = MainWnd.StrmRdr.ReadLine();
                            }
                        }

                        String a = str.ToString();
                        mail mail = new mail(a);
                        mails.Add(mail);
                        count--;
                    }
                }
            }
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
        private void MainWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            string cmdData = "quit" + "\r\n";
            byte[] szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            StrmWtr.Write(szData, 0, szData.Length);
            Console.WriteLine(StrmRdr.ReadLine());
            if (hasAccount != null)
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
            overviews = new List<email_overview_display_bg>();
            for(int i = 0; i < numberOfEmails; i++)
            {
                Point point = new Point(0, 68 * i);
                 
                email_overview_display_bg email_overview = new email_overview_display_bg();
                email_overview.Name = Convert.ToString(i);//i从0开始
                email_overview.sender_email.Text = mails[i].sender;
                email_overview.subject.Text = mails[i].subject;
                if (mails[i].content.Length > 5)
                {
                    email_overview.content.Text = mails[i].content.Substring(0, 5);
                }
                else
                {
                    email_overview.content.Text = mails[i].content;
                }
                email_overview.Location = point;
                email_overview.Click += new EventHandler(email_overview_display_Click);
                //overview是panel，overviews是list
                overviews.Add(email_overview);
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
            delete_btn.MouseLeave += new EventHandler(delete_btn_MouseLeave);
            details.Controls.Add(delete_btn);

            if (mails[index].hasFile == true)
            {
                List<Mail_file> files = mails[index].files;//附件列表
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

                    //
                    // attachments
                    //
                    attachments.AutoSize = true;
                    attachments.Text = Convert.ToString(files[i].Name);
                    attachments.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
                    attachments.Location = new Point(14, attachment_notice.Location.Y + attachment_notice.Size.Height + i * 20);
                    attachments.Name = Convert.ToString(index) + "-" + Convert.ToString(i);
                    attachments.Size = new Size(0, 20);
                    attachments.Click += new EventHandler(linkLabel_LinkClicked);
                    details.Controls.Add(attachments);
                }
            }

        }
        private void delete_btn_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            int index = Convert.ToInt32(temp.Name);
            email_overview_display_bg tmp = new email_overview_display_bg();

            string cmdData = "dele "+(numberOfEmails-index).ToString() + "\r\n";
            byte[] szData = System.Text.Encoding.ASCII.GetBytes(cmdData.ToCharArray());
            StrmWtr.Write(szData, 0, szData.Length);
            if (StrmRdr.ReadLine()[0] == '+')
            {
                tmp.Name = overviews[index].Name;
                tmp.Location = overviews[index].Location;
                //重新排列自定义控件
                for (int i = Convert.ToInt32(temp.Name); i < numberOfEmails - 1; i++)
                {
                    email_overview_display_bg tmp_1 = new email_overview_display_bg();
                    tmp_1.Name = overviews[i + 1].Name;
                    tmp_1.Location = overviews[i + 1].Location;
                    overviews[i + 1].Name = tmp.Name;
                    overviews[i + 1].Location = tmp.Location;
                    tmp.Name = tmp_1.Name;
                    tmp.Location = tmp_1.Location;
                }

                //删除index处的自定义控件
                overviews.RemoveAt(index);

                //删除邮件
                mails.RemoveAt(index);

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

                //刷新自定义控件
                overview.Controls.Clear();
                for (int i = 0; i < overviews.Count(); i++)
                    overview.Controls.Add(overviews[i]);
                MessageBox.Show("已添加删除标记，客户端关闭后即可删除");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
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


        private void linkLabel_LinkClicked(object sender, EventArgs e)
        {
            LinkLabel temp = (LinkLabel)sender;
            int indexOfEmail, indexOfFile;
            indexOfEmail = Convert.ToInt32(temp.Name.Split('-')[0]);
            indexOfFile =Convert.ToInt32(temp.Name.Split('-')[1]);
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = mails[indexOfEmail].files[indexOfFile].Name;
            saveFile.Filter = "所有文件(*.*)|*.*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                //创建一个文件流对象，用于写文件
                FileStream file = new FileStream(saveFile.FileName, FileMode.Create);
                //创建一个与文件流对象相对应的二进制写入流对象
                BinaryWriter binaryWriter = new BinaryWriter(file);
                binaryWriter.Write(Convert.FromBase64String(mails[indexOfEmail].files[indexOfFile].BaseCode));
                //关闭所有文件流对象
                binaryWriter.Close();
                file.Close();
            }
        }
    }
}