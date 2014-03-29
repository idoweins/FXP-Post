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
    public partial class FormThread : Form
    {



        Dictionary<string, string> prefixes;
        public FormThread()
        {
            InitializeComponent();
            if (Program.User == null)
                throw new Exception("עליך להתחבר");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var forum in FxpUtility.Forums)
                this.comboBoxForums.Items.Add(forum.Key);
        }

        private void comboBoxForums_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            int forumId = FxpUtility.Forums[combobox.SelectedItem.ToString()];
            prefixes = Program.User.GetPrefixes(forumId);

            this.comboBoxPrefix.Items.Clear();
            foreach (var prefix in prefixes)
                this.comboBoxPrefix.Items.Add(prefix.Key);

            this.comboBoxPrefix.Enabled = true;
            this.textBoxSubject.Enabled = false;
            this.textBoxContent.Enabled = false;
            this.buttonPost.Enabled = false;

        }
        private void comboBoxPrefix_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBoxSubject.Enabled = true;
            this.textBoxContent.Enabled = this.textBoxSubject.Text.Length >= 2;
        }

        private void textBoxSubject_TextChanged(object sender, EventArgs e)
        {
            this.textBoxContent.Enabled = this.textBoxSubject.Text.Length >= 2;
            this.buttonPost.Enabled = this.textBoxSubject.Text.Length >= 2 && this.textBoxContent.Text.Length >= 2;
        }

        private void textBoxContent_TextChanged(object sender, EventArgs e)
        {
            this.buttonPost.Enabled = this.textBoxContent.Text.Length >= 2;
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Program.User.PostThread(FxpUtility.Forums[this.comboBoxForums.SelectedItem.ToString()], prefixes[this.comboBoxPrefix.SelectedItem.ToString()],
                    this.textBoxSubject.Text, this.textBoxContent.Text);
                if (MessageBox.Show("האם ברצונך להיכנס לאשכול?", "האשכול פורסם בהצלחה!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    System.Diagnostics.Process.Start("http://www.fxp.co.il/showthread.php?t=" + id);
            }
            catch
            {
                MessageBox.Show("שגיאה חלה בעת ניסיון פרסום האשכול");
            }
        }




    }
}
