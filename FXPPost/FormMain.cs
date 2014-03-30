using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FXPPost
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        void User_LoggedOut(object sender, EventArgs e)
        {
            this.labelUsername.Text = string.Empty;
            this.labelUsername.Visible = false;
            MessageBox.Show("ההתנתקות התרחשה בהצלחה");
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
                new FormThread().Show();
            else
                MessageBox.Show("עליך להתחבר");
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (Program.User != null)
            {
                Program.User.Dispose();
                Program.User = null;
                User_LoggedOut(sender, e);
            }
            else
                MessageBox.Show("עליך להתחבר");
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.LoggedIn += login_LoggedIn;
            login.Show();
        }

        void login_LoggedIn(object sender, EventArgs e)
        {
            this.labelUsername.Text = Program.User.Name;
            this.labelUsername.Visible = true;
            MessageBox.Show("התחברת בהצלחה!");
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.User != null)
                Program.User.Dispose();
        }

        private void buttonComment_Click(object sender, EventArgs e)
        {

            if (Program.User != null)
                new FormComment().Show();
            else
                MessageBox.Show("עליך להתחבר");

        }
    }
}
