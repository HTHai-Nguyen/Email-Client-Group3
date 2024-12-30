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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//using ClassEmail;

namespace LoginForm
{
    public partial class ComposeForm : Form
    {
        string fromEmail;
        public ComposeForm(string email)
        {
            InitializeComponent();
            fromEmail = email;
        }
        public ComposeForm(string FromEmail, string ToEmail)
        {
            InitializeComponent();
            fromEmail = FromEmail;
            txtTo.Text = ToEmail;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnSend_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Địa chỉ và cổng của TCPServer
                {
                    NetworkStream stream = client.GetStream();

                    // Tạo chuỗi thông tin gửi mail
                    string info = $"SEND:{fromEmail}:{txtTo.Text}:{TxtSubject.Text}:{txtBody.Text}";
                    byte[] data = Encoding.UTF8.GetBytes(info);
                    //lbTest.Text = data.Length.ToString();

                    // Gửi dữ liệu đến server
                    stream.Write(data, 0, data.Length);

                    // Nhận phản hồi từ server
                    byte[] responseData = new byte[256];
                    int bytes = stream.Read(responseData, 0, responseData.Length);
                    string responseMessage = Encoding.UTF8.GetString(responseData, 0, bytes);
                    //lbTest.Text = responseMessage;

                    if (responseMessage == "Success")
                    {
                        //Dashboard dashboard = new Dashboard(username); // Truyền username
                        this.Hide();
                        new ListEmails().Show();
                    }
                    else
                    {
                        MessageBox.Show(responseMessage, "Send Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //txtBody.Clear();
                        //txtTo.Clear();
                        //TxtSubject.Clear();
                        //txtTo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
