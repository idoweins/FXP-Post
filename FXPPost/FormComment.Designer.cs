namespace FXPPost
{
    partial class FormComment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxForums = new System.Windows.Forms.ComboBox();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.comboBoxThreads = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.buttonPost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 16);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "פורום:";
            // 
            // comboBoxForums
            // 
            this.comboBoxForums.FormattingEnabled = true;
            this.comboBoxForums.Location = new System.Drawing.Point(78, 12);
            this.comboBoxForums.Name = "comboBoxForums";
            this.comboBoxForums.Size = new System.Drawing.Size(153, 21);
            this.comboBoxForums.TabIndex = 4;
            this.comboBoxForums.SelectedIndexChanged += new System.EventHandler(this.comboBoxForums_SelectedIndexChanged);
            // 
            // textBoxPage
            // 
            this.textBoxPage.Enabled = false;
            this.textBoxPage.Location = new System.Drawing.Point(12, 12);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(60, 20);
            this.textBoxPage.TabIndex = 6;
            this.textBoxPage.Text = "עמוד";
            this.textBoxPage.Click += new System.EventHandler(this.textBoxPage_Click);
            this.textBoxPage.TextChanged += new System.EventHandler(this.textBoxPage_TextChanged);
            // 
            // comboBoxThreads
            // 
            this.comboBoxThreads.Enabled = false;
            this.comboBoxThreads.FormattingEnabled = true;
            this.comboBoxThreads.Location = new System.Drawing.Point(12, 40);
            this.comboBoxThreads.Name = "comboBoxThreads";
            this.comboBoxThreads.Size = new System.Drawing.Size(218, 21);
            this.comboBoxThreads.TabIndex = 7;
            this.comboBoxThreads.SelectedIndexChanged += new System.EventHandler(this.comboBoxThreads_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 43);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "אשכול:";
            // 
            // textBoxContent
            // 
            this.textBoxContent.Enabled = false;
            this.textBoxContent.Location = new System.Drawing.Point(12, 69);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(256, 104);
            this.textBoxContent.TabIndex = 9;
            this.textBoxContent.TextChanged += new System.EventHandler(this.textBoxContent_TextChanged);
            // 
            // buttonPost
            // 
            this.buttonPost.Enabled = false;
            this.buttonPost.Location = new System.Drawing.Point(12, 179);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(256, 23);
            this.buttonPost.TabIndex = 10;
            this.buttonPost.Text = "פרסם";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // FormComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 214);
            this.Controls.Add(this.buttonPost);
            this.Controls.Add(this.textBoxContent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxThreads);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxForums);
            this.Name = "FormComment";
            this.Text = "FormComment";
            this.Load += new System.EventHandler(this.FormComment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxForums;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.ComboBox comboBoxThreads;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.Button buttonPost;
    }
}