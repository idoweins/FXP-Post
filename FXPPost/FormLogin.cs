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
    public partial class FormLogin : Form
    {
        public event EventHandler LoggedIn;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox.Text == "משתמש" || textbox.Text == "סיסמה")
                textbox.Text = string.Empty;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Program.User = new FxpUtility(textBoxUsername.Text, textBoxPassword.Text);
                if (LoggedIn != null)
                    LoggedIn.Invoke(this, new EventArgs());
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       


    }
}
