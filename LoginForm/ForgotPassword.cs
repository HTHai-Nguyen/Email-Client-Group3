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

namespace LoginForm
{
    public partial class ForgotPassword : Form
    {
        
        
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string username = txtResetUsername.Text;
            string email = txtResetEmail.Text;
            //if (username ==)
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Địa chỉ và cổng của TCPServer
                {
                    NetworkStream stream = client.GetStream();

                    // Tạo chuỗi thông tin reset
                    string verifyAccountInfo = $"VERIFY_ACCOUNT:{username}:{email}";
                    byte[] data = Encoding.UTF8.GetBytes(verifyAccountInfo);
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
                        new ResetPassword(email).Show();
                    }
                    else
                    {
                        MessageBox.Show(responseMessage, "Reset Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtResetEmail.Clear();
                        txtResetUsername.Clear();
                        txtResetUsername.Focus();
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
