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
    public partial class FormComment : Form
    {
        Dictionary<string, int> threads;

        public FormComment()
        {
            InitializeComponent();
        }

        private void textBoxPage_TextChanged(object sender, EventArgs e)
        {
            int page = 1;
            if (this.textBoxPage.Text != string.Empty && !int.TryParse(this.textBoxPage.Text, out page))
            {
                MessageBox.Show("עליך להכניס לשדה זה מספר");
                this.comboBoxThreads.Enabled = false;
            }
            else
            {
                threads = Program.User.GetThreads(FxpUtility.Forums[this.comboBoxForums.SelectedItem.ToString()], page);
                this.comboBoxThreads.Items.Clear();

                foreach (var thread in threads)
                    this.comboBoxThreads.Items.Add(thread.Key);

                this.comboBoxThreads.Enabled = true;
            }
            this.textBoxContent.Enabled = false;
            this.buttonPost.Enabled = false;
        }

        private void comboBoxForums_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBoxPage.Enabled = true;
            this.comboBoxThreads.Enabled = false;
            this.textBoxContent.Enabled = false;
            this.buttonPost.Enabled = false;
        }

        private void FormComment_Load(object sender, EventArgs e)
        {
            foreach (var forum in FxpUtility.Forums)
                this.comboBoxForums.Items.Add(forum.Key);
        }

        private void comboBoxThreads_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBoxContent.Enabled = true;
            this.buttonPost.Enabled = false;
        }

        private void textBoxContent_TextChanged(object sender, EventArgs e)
        {
            this.buttonPost.Enabled = this.textBoxContent.Text.Length >= 2;
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            try
            {
                Program.User.PostComment(threads[this.comboBoxThreads.SelectedItem.ToString()], this.textBoxContent.Text);
                if (MessageBox.Show("האם ברצונך להיכנס לתגובה?", "התגובה פורסמה בהצלחה", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    System.Diagnostics.Process.Start("http://www.fxp.co.il/showthread.php?t=" + threads[this.comboBoxThreads.SelectedItem.ToString()] + "&goto=newpost");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBoxPage_Click(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "עמוד")
                this.textBoxPage.Text = string.Empty;
        }
    }
}
