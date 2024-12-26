using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class ReplyForm : Form
    {
        public ReplyForm(Email email)
        {
            InitializeComponent();
            //InitializeReplyData(originalEmail);
            DisplayEmail(email);
            btnBack.Click += btnBack_Click;

            //Control
            this.Controls.AddRange(new Control[]
        {
            lblTo, lblSubject,
            txtReply, btnBack
        });
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DisplayEmail(Email email)
        {
            lblTo.Text = "To: " + email.From;
            lblSubject.Text = "Re: " + email.Subject;
            txtReply.SelectionStart = 0;
            txtReply.SelectionLength = 0;
            txtReply.Focus();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo email mới từ dữ liệu reply
                Email replyEmail = new Email
                {
                    Subject = lblSubject.Text,
                    Content = txtReply.Text,
                    Date = DateTime.Now
                };

              

                MessageBox.Show("Email sent successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
