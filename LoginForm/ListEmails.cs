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
    public partial class ListEmails : Form
    {
        private string username;
        //private int userID;
        public ListEmails(string username)
        {
            this.username = username;
            InitializeComponent();
            LoadSampleEmails();
            lblName.Text = username;
        }

        public ListEmails()
        {
            InitializeComponent();
            LoadSampleEmails();
        }

        // // Hàm khởi tạo với ID người dùng
        // public Dashboard(string username, int userId)
        // {
        //     InitializeComponent();
        //     this.username = username;
        //     lblName.Text = username;
        //     this.userId = userId; // Gán ID người dùng
        // }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linklblLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listEmail.SelectedItems.Count > 0)
            {
                Email selectedEmail = (Email)listEmail.SelectedItems[0].Tag;

                // Tạo và hiển thị form chi tiết
                DetailForm detailForm = new DetailForm(selectedEmail);
                detailForm.ShowDialog(this); // Sử dụng ShowDialog để chặn form list
                
            }
           
        }

        private List<Email> emails;
        

        //Lấy tạm sample để test thử tính năng đọc email, sẽ xóa khi dùng với database
        private void LoadSampleEmails()
        {
            emails = new List<Email>
        {
            new Email
            {
                From = "john@example.com",
                Subject = "Meeting Tomorrow",
                Date = DateTime.Now,
                Content = "Hi,\n\nLet's meet tomorrow at 10 AM.\n\nBest regards,\nJohn"
            },
            new Email
            {
                From = "alice@example.com",
                Subject = "Project Update",
                Date = DateTime.Now.AddHours(-2),
                Content = "Hello,\n\nHere's the latest project update...\n\nRegards,\nAlice"
            }
        };

            foreach (var email in emails)
            {
                ListViewItem item = new ListViewItem(email.From);
                item.SubItems.Add(email.Subject);
                item.SubItems.Add(email.Date.ToString("g"));
                item.Tag = email;
                listEmail.Items.Add(item);
            }
        }
    }
}
