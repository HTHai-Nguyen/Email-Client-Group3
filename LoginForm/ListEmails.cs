using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text.Json;
using LoginForm;
//using Server;

namespace LoginForm
{
    public partial class ListEmails : Form
    {
        private string email;
        //private int userID;
        public ListEmails(string email)
        {
            this.email = email;
            InitializeComponent();
            //LoadSampleEmails();
            //lblName.Text = username;
        }

        public ListEmails()
        {
            InitializeComponent();
            //LoadSampleEmails();
        }

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
            //if (listEmail.SelectedItems.Count > 0)
            //{
            //    Email selectedEmail = (Email)listEmail.SelectedItems[0].Tag;

            //    // Tạo và hiển thị form chi tiết
            //    DetailForm detailForm = new DetailForm(selectedEmail);
            //    detailForm.ShowDialog(this); // Sử dụng ShowDialog để chặn form list

            //}
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Địa chỉ và cổng của TCPServer
                {
                    NetworkStream stream = client.GetStream();

                    // Tạo chuỗi thông tin nhận
                    string info = $"RECEIVE:{email}";
                    byte[] data = Encoding.UTF8.GetBytes(info);
                    //lbTest.Text = data.Length.ToString();

                    // Gửi dữ liệu đến server
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[8192]; // Kích thước buffer
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Deserialize JSON thành danh sách
                    var emailList = JsonSerializer.Deserialize<List<Email>>(json);

                    // Hiển thị danh sách trên giao diện
                    foreach (var email in emailList)
                    {
                        listEmail.Items.Add(new ListViewItem(new string[]
                        {
                            email.From,
                            email.To,
                            email.Subject,
                            email.SentTime.ToString("yyyy-MM-dd HH:mm:ss")
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Email> emails;


        //Lấy tạm sample để test thử tính năng đọc email
        //private void LoadSampleEmails()
        //{
        //    emails = new List<Email>
        //{
        //    new Email
        //    {
        //        From = "hai1212@email.com",
        //        Subject = "New application",
        //        Date = DateTime.Now,
        //        Content = "Hi,\n\nThere is a Test for New app EMail Client.\n\nThank you"
        //    },
        //    new Email
        //    {
        //        From = "alice@email.com",
        //        Subject = "Project Update",
        //        Date = DateTime.Now.AddHours(-1),
        //        Content = "Hello,\n\nHere's the latest project update...\n\nRegards"
        //    },
        //    new Email
        //    {
        //        From = "ice799@email.com",
        //        Subject = "Project Fix",
        //        Date = DateTime.Now.AddHours(-1),
        //        Content = "Hello,\n\nFix bug...\n"
        //    },
        //    new Email
        //    {
        //        From = "ellonmusk@email.com",
        //        Subject = "Create newTesla ",
        //        Date = DateTime.Now.AddHours(-1),
        //        Content = "Hello,\n\nHere's The Tesla car \n\nRegards"
        //    },
        //    new Email
        //    {
        //        From = "hacker6969@email.com",
        //        Subject = "Your computer has Viruss",
        //        Date = DateTime.Now.AddHours(-1),
        //        Content = "Hello World,\n\nSay goodbye your computer =]]]]\n\n GOODBYE"
        //    }
        //};

        //    foreach (var email in emails)
        //    {
        //        ListViewItem item = new ListViewItem(email.From);
        //        item.SubItems.Add(email.Subject);
        //        item.SubItems.Add(email.Date.ToString("g"));
        //        item.Tag = email;
        //        listEmail.Items.Add(item);
        //    }
        //}

        private void btnCompose_Click(object sender, EventArgs e)
        {
            new ComposeForm(email).Show();
        }
    }
}
