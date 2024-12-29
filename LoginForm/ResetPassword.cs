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
    public partial class ResetPassword : Form
    {
        private string email;
        public ResetPassword(string email)
        {
            InitializeComponent();
            this.email = email;
            lbTest.Text = email;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtResetPassword.Text != txtResetCfPassword.Text)
            {
                MessageBox.Show("Password does not match, Please try again.", "Register Failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResetPassword.Clear();
                txtResetCfPassword.Clear();
                txtResetPassword.Focus();
                return;
            }
            //Hash password
            string hashedPassword = PasswordHandler.HashPassword(txtResetPassword.Text);
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Địa chỉ và cổng của TCPServer
                {
                    NetworkStream stream = client.GetStream();

                    // Tạo chuỗi thông tin reset
                    string resetInfo = $"RESET:{email}:{hashedPassword}";
                    byte[] data = Encoding.UTF8.GetBytes(resetInfo);
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
                        new Login().Show();
                    }
                    else
                    {
                        MessageBox.Show(responseMessage, "Reset Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtResetPassword.Clear();
                        txtResetCfPassword.Clear();
                        txtResetPassword.Focus();
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
