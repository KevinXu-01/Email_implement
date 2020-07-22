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
    public partial class sign_in : Form
    {
        public sign_in()
        {
            InitializeComponent();
        }

        private void sign_in_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (email_address.Text != "" && password.Text != "" && pop3_server_address.Text != ""
                && smtp_server_address.Text != "" || MainWnd.hasAccount != null)
            {

            }
            else
            {
                Application.Exit();
            }
        }

        private void sign_in_Load(object sender, EventArgs e)
        {

        }

        private void sign_in_button_Click(object sender, EventArgs e)
        {
            if (automatic_log_in.CheckState == CheckState.Checked && email_address.Text != "" 
                && password.Text != "" && pop3_server_address.Text != "" && smtp_server_address.Text != "")
            {
                MainWnd.account_index++;
                MainWnd.accounts[MainWnd.account_index].email_address = email_address.Text;
                MainWnd.accounts[MainWnd.account_index].password = password.Text;
                MainWnd.accounts[MainWnd.account_index].pop3_server_address = pop3_server_address.Text;
                MainWnd.accounts[MainWnd.account_index].smtp_server_address = smtp_server_address.Text;
                MainWnd.hasAccount = " ";
            }
            else
            {
                MainWnd.accounts[MainWnd.account_index].email_address = null;
                MainWnd.accounts[MainWnd.account_index].password = null;
                MainWnd.accounts[MainWnd.account_index].pop3_server_address = null;
                MainWnd.accounts[MainWnd.account_index].smtp_server_address = null;
                MainWnd.hasAccount = null;
            }
            this.Hide();
        }
    }
}
