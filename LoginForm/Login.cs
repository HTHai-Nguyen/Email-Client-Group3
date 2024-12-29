using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace LoginForm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtEmail.Select();
        }
        private void linklblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Chuyển sang link đăng ký
        {
            new Register().Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter information completely.", "Login Failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email is not correct format.", "Register Failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            if (!IsValidPassword(txtPassword.Text))
            {
                MessageBox.Show("Password must be at least 8 characters, including uppercase letters, lowercase letters, numbers and special characters.", "Register Failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Gửi thông tin đăng nhập đến TCPServer
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Địa chỉ và cổng của TCPServer
                {
                    NetworkStream stream = client.GetStream();

                    // Tạo chuỗi thông tin đăng nhập
                    string loginInfo = $"LOGIN:{email}:{password}";
                    byte[] data = Encoding.UTF8.GetBytes(loginInfo);

                    // Gửi dữ liệu đến server
                    stream.Write(data, 0, data.Length);

                    // Nhận phản hồi từ server
                    byte[] responseData = new byte[256];
                    int bytes = stream.Read(responseData, 0, responseData.Length);
                    string responseMessage = Encoding.UTF8.GetString(responseData, 0, bytes);

                    if (responseMessage == "Success")
                    {
                        Dashboard dashboard = new Dashboard(email); // Truyền username
                        this.Hide();
                        dashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show(responseMessage, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtEmail.Clear();
                        txtPassword.Clear();
                        txtEmail.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void llbForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ForgotPassword().Show();
            this.Hide();
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool IsValidPassword(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            return password.Length >= 8 &&
                   hasNumber.IsMatch(password) &&
                   hasUpperChar.IsMatch(password) &&
                   hasLowerChar.IsMatch(password) &&
                   hasSymbols.IsMatch(password);
        }
    }

    
}
