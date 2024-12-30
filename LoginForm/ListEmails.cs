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
using System.IO;
//using Server;

namespace LoginForm
{
    public partial class ListEmails : Form
    {
        private string email;
        private List<Email> emailList = new List<Email>();
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

        private void ListEmails_Load(object sender, EventArgs e)
        {
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
                    //Stream liên tục
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[8192];
                        int bytesRead;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, bytesRead);
                        }
                        string json = Encoding.UTF8.GetString(ms.ToArray());

                        // Deserialize JSON thành danh sách
                        emailList = JsonSerializer.Deserialize<List<Email>>(json);
                        // Hiển thị danh sách email trên giao diện
                        foreach (var email in emailList)
                        {
                            var listViewItem = new ListViewItem(new string[]
                            {
                                email.From,
                                email.To,
                                email.Subject,
                                email.SentTime.ToString("yyyy-MM-dd HH:mm:ss")
                            });

                            // Gán đối tượng email đầy đủ vào Tag
                            listViewItem.Tag = email;

                            // Thêm vào ListView
                            listEmail.Items.Add(listViewItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCompose_Click_1(object sender, EventArgs e)
        {
            new ComposeForm(email).Show();
        }

        private void listEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listEmail.SelectedItems.Count > 0)
            {
                // Lấy email được chọn
                var selectedItem = listEmail.SelectedItems[0];
                var email = (Email)selectedItem.Tag;

                // Mở form hiển thị nội dung email
                DetailEmail detailForm = new DetailEmail(email);
                detailForm.ShowDialog();
            }
        }
    }
}
