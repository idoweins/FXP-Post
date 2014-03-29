namespace FXPPost
{
    partial class FormThread
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
            this.comboBoxForums = new System.Windows.Forms.ComboBox();
            this.comboBoxPrefix = new System.Windows.Forms.ComboBox();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.buttonPost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxForums
            // 
            this.comboBoxForums.FormattingEnabled = true;
            this.comboBoxForums.Location = new System.Drawing.Point(12, 12);
            this.comboBoxForums.Name = "comboBoxForums";
            this.comboBoxForums.Size = new System.Drawing.Size(219, 21);
            this.comboBoxForums.TabIndex = 0;
            this.comboBoxForums.SelectedIndexChanged += new System.EventHandler(this.comboBoxForums_SelectedIndexChanged);
            // 
            // comboBoxPrefix
            // 
            this.comboBoxPrefix.Enabled = false;
            this.comboBoxPrefix.FormattingEnabled = true;
            this.comboBoxPrefix.Location = new System.Drawing.Point(176, 41);
            this.comboBoxPrefix.Name = "comboBoxPrefix";
            this.comboBoxPrefix.Size = new System.Drawing.Size(55, 21);
            this.comboBoxPrefix.TabIndex = 1;
            this.comboBoxPrefix.SelectedIndexChanged += new System.EventHandler(this.comboBoxPrefix_SelectedIndexChanged);
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Enabled = false;
            this.textBoxSubject.Location = new System.Drawing.Point(12, 41);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(156, 20);
            this.textBoxSubject.TabIndex = 2;
            this.textBoxSubject.TextChanged += new System.EventHandler(this.textBoxSubject_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 16);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "פורום:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 44);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "נושא:";
            // 
            // textBoxContent
            // 
            this.textBoxContent.Enabled = false;
            this.textBoxContent.Location = new System.Drawing.Point(12, 68);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(260, 155);
            this.textBoxContent.TabIndex = 5;
            this.textBoxContent.TextChanged += new System.EventHandler(this.textBoxContent_TextChanged);
            // 
            // buttonPost
            // 
            this.buttonPost.Enabled = false;
            this.buttonPost.Location = new System.Drawing.Point(12, 229);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(259, 23);
            this.buttonPost.TabIndex = 6;
            this.buttonPost.Text = "פרסם";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // FormPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 258);
            this.Controls.Add(this.buttonPost);
            this.Controls.Add(this.textBoxContent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.comboBoxPrefix);
            this.Controls.Add(this.comboBoxForums);
            this.Name = "FormPost";
            this.Text = "Post a thread";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxForums;
        private System.Windows.Forms.ComboBox comboBoxPrefix;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.Button buttonPost;

    }
}

