namespace LoginForm
{
    partial class DetailEmail
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
            this.txtBody = new System.Windows.Forms.TextBox();
            this.lbFrom = new System.Windows.Forms.Label();
            this.lbTo = new System.Windows.Forms.Label();
            this.lbSubject = new System.Windows.Forms.Label();
            this.btnReplyEmail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(29, 189);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(735, 219);
            this.txtBody.TabIndex = 0;
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(29, 51);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(44, 16);
            this.lbFrom.TabIndex = 1;
            this.lbFrom.Text = "label1";
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Location = new System.Drawing.Point(29, 89);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(44, 16);
            this.lbTo.TabIndex = 2;
            this.lbTo.Text = "label2";
            // 
            // lbSubject
            // 
            this.lbSubject.AutoSize = true;
            this.lbSubject.Location = new System.Drawing.Point(29, 132);
            this.lbSubject.Name = "lbSubject";
            this.lbSubject.Size = new System.Drawing.Size(44, 16);
            this.lbSubject.TabIndex = 3;
            this.lbSubject.Text = "label3";
            // 
            // btnReplyEmail
            // 
            this.btnReplyEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplyEmail.Location = new System.Drawing.Point(579, 132);
            this.btnReplyEmail.Name = "btnReplyEmail";
            this.btnReplyEmail.Size = new System.Drawing.Size(129, 35);
            this.btnReplyEmail.TabIndex = 4;
            this.btnReplyEmail.Text = "Reply";
            this.btnReplyEmail.UseVisualStyleBackColor = true;
            this.btnReplyEmail.Click += new System.EventHandler(this.btnReplyEmail_Click);
            // 
            // DetailEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReplyEmail);
            this.Controls.Add(this.lbSubject);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.lbFrom);
            this.Controls.Add(this.txtBody);
            this.Name = "DetailEmail";
            this.Text = "DetailEmail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.Label lbSubject;
        private System.Windows.Forms.Button btnReplyEmail;
    }
}