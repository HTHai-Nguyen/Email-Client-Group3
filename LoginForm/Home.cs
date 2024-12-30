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

namespace LoginForm
{
    public partial class Home : Form
    {
        private string email;
        private int userId; // Thêm ID người dùng

        public Home(string email)
        {
            InitializeComponent();
            this.email = email;
            lbEmail.Text = email;

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

        private void chat_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void lschat_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Địa chỉ và cổng của TCPServer
                {
                    NetworkStream stream = client.GetStream();

                    // Tạo chuỗi thông tin lấy thông tin account ứng với email
                    string verifyAccountInfo = $"ACCOUNT_INFO:{email}";
                    byte[] data = Encoding.UTF8.GetBytes(verifyAccountInfo);
                    //lbTest.Text = data.Length.ToString();

                    // Gửi dữ liệu đến server
                    stream.Write(data, 0, data.Length);

                    // Nhận phản hồi từ server
                    byte[] responseData = new byte[256];
                    int bytes = stream.Read(responseData, 0, responseData.Length);
                    string responseMessage = Encoding.UTF8.GetString(responseData, 0, bytes);
                    //lbTest.Text = responseMessage;

                    if (responseData != null)
                    {
                        lbUsername.Text = responseMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCompose_Click(object sender, EventArgs e)
        {
            new ComposeForm(email).Show();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            new ListEmails(email).Show();
        }
    }
    
}
