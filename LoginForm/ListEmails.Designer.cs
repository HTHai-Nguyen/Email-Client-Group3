
namespace LoginForm
{
    partial class ListEmails
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
            this.btnCompose = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.linklblLogout = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.listEmail = new System.Windows.Forms.ListView();
            this.From = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Subject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnCompose
            // 
            this.btnCompose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCompose.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompose.Location = new System.Drawing.Point(62, 114);
            this.btnCompose.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompose.Name = "btnCompose";
            this.btnCompose.Size = new System.Drawing.Size(174, 66);
            this.btnCompose.TabIndex = 22;
            this.btnCompose.Text = "Compose";
            this.btnCompose.UseVisualStyleBackColor = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Teal;
            this.lblName.Location = new System.Drawing.Point(654, 23);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(32, 46);
            this.lblName.TabIndex = 20;
            this.lblName.Text = " ";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Teal;
            this.lblWelcome.Location = new System.Drawing.Point(226, 19);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(258, 46);
            this.lblWelcome.TabIndex = 21;
            this.lblWelcome.Text = "WELCOME! ";
            // 
            // linklblLogout
            // 
            this.linklblLogout.AutoSize = true;
            this.linklblLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.70909F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblLogout.ForeColor = System.Drawing.Color.Teal;
            this.linklblLogout.LinkColor = System.Drawing.Color.Teal;
            this.linklblLogout.Location = new System.Drawing.Point(23, 23);
            this.linklblLogout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linklblLogout.Name = "linklblLogout";
            this.linklblLogout.Size = new System.Drawing.Size(87, 29);
            this.linklblLogout.TabIndex = 19;
            this.linklblLogout.TabStop = true;
            this.linklblLogout.Text = "Logout";
            this.linklblLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblLogout_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.29091F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Teal;
            this.btnClose.Location = new System.Drawing.Point(1026, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 69);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // listEmail
            // 
            this.listEmail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.From,
            this.Subject,
            this.Date});
            this.listEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listEmail.FullRowSelect = true;
            this.listEmail.GridLines = true;
            this.listEmail.HideSelection = false;
            this.listEmail.Location = new System.Drawing.Point(62, 218);
            this.listEmail.Margin = new System.Windows.Forms.Padding(4);
            this.listEmail.Name = "listEmail";
            this.listEmail.Size = new System.Drawing.Size(974, 670);
            this.listEmail.TabIndex = 23;
            this.listEmail.UseCompatibleStateImageBehavior = false;
            this.listEmail.View = System.Windows.Forms.View.Details;
            this.listEmail.SelectedIndexChanged += new System.EventHandler(this.list_SelectedIndexChanged);
            // 
            // From
            // 
            this.From.Text = "From";
            this.From.Width = 300;
            // 
            // Subject
            // 
            this.Subject.Text = "Subject";
            this.Subject.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Subject.Width = 500;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Date.Width = 170;
            // 
            // ListEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 1150);
            this.Controls.Add(this.btnCompose);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.linklblLogout);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.listEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListEmails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListEmails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompose;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.LinkLabel linklblLogout;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView listEmail;
        private System.Windows.Forms.ColumnHeader From;
        private System.Windows.Forms.ColumnHeader Subject;
        private System.Windows.Forms.ColumnHeader Date;
    }
}