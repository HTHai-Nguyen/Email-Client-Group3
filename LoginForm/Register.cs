using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Net.Sockets;

namespace LoginForm
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            txtUsername.Select();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                MessageBox.Show("Please enter information completely.", "Register Failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtConfirmPass.Clear();
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Password does not match, Please try again.", "Register Failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtConfirmPass.Clear();
                txtPassword.Focus();
                return;
            }

            // Mã hóa mật khẩu
            string hashedPassword = PasswordHandler.HashPassword(txtPassword.Text);

            // Gửi thông tin đăng ký đến server
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Địa chỉ và cổng của TCPServer
                {
                    NetworkStream stream = client.GetStream();
                    string registerInfo = $"REGISTER:{txtUsername.Text}:{txtEmail.Text}:{hashedPassword}"; // Gửi thông tin đăng ký
                    byte[] data = Encoding.UTF8.GetBytes(registerInfo);
                    stream.Write(data, 0, data.Length);

                    // Nhận phản hồi từ server
                    byte[] responseData = new byte[256];
                    int bytes = stream.Read(responseData, 0, responseData.Length);
                    string responseMessage = Encoding.UTF8.GetString(responseData, 0, bytes);
                    MessageBox.Show(responseMessage, "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (responseMessage == "Registration Successful")
                    {
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void ClearFields()
        {
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmPass.Clear();
            txtUsername.Focus();
        }

        private void linklblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
