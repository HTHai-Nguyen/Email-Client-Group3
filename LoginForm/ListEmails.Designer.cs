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
            this.picPen = new System.Windows.Forms.PictureBox();
            this.btnCompose = new System.Windows.Forms.Button();
            this.lblListView = new System.Windows.Forms.Label();
            this.linklblLogout = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.listEmail = new System.Windows.Forms.ListView();
            this.From = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Subject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.picPen)).BeginInit();
            this.SuspendLayout();
            // 
            // picPen
            // 
            this.picPen.BackColor = System.Drawing.Color.Teal;
            this.picPen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picPen.Enabled = false;
            this.picPen.Location = new System.Drawing.Point(103, 143);
            this.picPen.Margin = new System.Windows.Forms.Padding(4);
            this.picPen.Name = "picPen";
            this.picPen.Size = new System.Drawing.Size(81, 59);
            this.picPen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPen.TabIndex = 30;
            this.picPen.TabStop = false;
            // 
            // btnCompose
            // 
            this.btnCompose.BackColor = System.Drawing.Color.Teal;
            this.btnCompose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompose.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompose.ForeColor = System.Drawing.Color.White;
            this.btnCompose.Location = new System.Drawing.Point(86, 132);
            this.btnCompose.Margin = new System.Windows.Forms.Padding(5);
            this.btnCompose.Name = "btnCompose";
            this.btnCompose.Size = new System.Drawing.Size(292, 81);
            this.btnCompose.TabIndex = 28;
            this.btnCompose.Text = "Compose";
            this.btnCompose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompose.UseVisualStyleBackColor = false;
            // 
            // lblListView
            // 
            this.lblListView.AutoSize = true;
            this.lblListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListView.ForeColor = System.Drawing.Color.Teal;
            this.lblListView.Location = new System.Drawing.Point(515, 31);
            this.lblListView.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblListView.Name = "lblListView";
            this.lblListView.Size = new System.Drawing.Size(334, 52);
            this.lblListView.TabIndex = 27;
            this.lblListView.Text = "List View EMail";
            // 
            // linklblLogout
            // 
            this.linklblLogout.AutoSize = true;
            this.linklblLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.70909F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblLogout.ForeColor = System.Drawing.Color.Teal;
            this.linklblLogout.LinkColor = System.Drawing.Color.Teal;
            this.linklblLogout.Location = new System.Drawing.Point(20, 14);
            this.linklblLogout.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.linklblLogout.Name = "linklblLogout";
            this.linklblLogout.Size = new System.Drawing.Size(97, 31);
            this.linklblLogout.TabIndex = 26;
            this.linklblLogout.TabStop = true;
            this.linklblLogout.Text = "Logout";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.29091F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Teal;
            this.btnClose.Location = new System.Drawing.Point(1352, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 85);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
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
            this.listEmail.Location = new System.Drawing.Point(86, 271);
            this.listEmail.Margin = new System.Windows.Forms.Padding(5);
            this.listEmail.Name = "listEmail";
            this.listEmail.Size = new System.Drawing.Size(1297, 552);
            this.listEmail.TabIndex = 29;
            this.listEmail.UseCompatibleStateImageBehavior = false;
            this.listEmail.View = System.Windows.Forms.View.Details;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 839);
            this.Controls.Add(this.picPen);
            this.Controls.Add(this.btnCompose);
            this.Controls.Add(this.lblListView);
            this.Controls.Add(this.linklblLogout);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.listEmail);
            this.Name = "ListEmails";
            this.Text = "ListEmail";
            ((System.ComponentModel.ISupportInitialize)(this.picPen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPen;
        private System.Windows.Forms.Button btnCompose;
        private System.Windows.Forms.Label lblListView;
        private System.Windows.Forms.LinkLabel linklblLogout;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView listEmail;
        private System.Windows.Forms.ColumnHeader From;
        private System.Windows.Forms.ColumnHeader Subject;
        private System.Windows.Forms.ColumnHeader Date;
    }
}