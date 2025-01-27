﻿//Truy vấn database
//SELECT TOP 100 * FROM Register;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.Json;

namespace Server
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection;
        private TcpListener tcpListener;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Thanh\[4.2]NETWORK-PROGRAMMING\DOAN\Email-Client-Group3\Server\Server\ServerDatabase.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                MessageBox.Show("Kết nối đến cơ sở dữ liệu thành công.");
                StartListening();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}");
            }
        }

        private void StartListening()
        {
            tcpListener = new TcpListener(IPAddress.Any, 5000);
            tcpListener.Start();
            Thread listenThread = new Thread(ListenForClients);
            listenThread.Start();
        }

        private void ListenForClients()
        {
            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            using (client)
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[256];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string clientInfo = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string[] details = clientInfo.Split(':');

                string action = details[0];

                switch (action)
                {
                    case "REGISTER":
                        HandleRegistration(details, stream);
                        break;

                    case "LOGIN":
                        HandleLogin(details, stream);
                        break;

                    case "VERIFY_ACCOUNT":
                        HandleVerifyAccount(details, stream);
                        break;
                    case "RESET":
                        HandleReset(details, stream);
                        break;
                    case "ACCOUNT_INFO":
                        HandleInfo(details, stream);
                        break;
                    case "SEND":
                        HandleSending(details, stream);
                        break;
                    case "RECEIVE":
                        HandleReceive(details, stream);
                        break;
                }
            }
        }
        private void HandleReceive(string[] details, NetworkStream stream)
        {
            string email = details[1];

            string query = "SELECT * FROM Emails WHERE FromEmail = @email OR ToEmail = @email";
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@email", email);

                List<EmailClass> emailList = new List<EmailClass>();
                //Thực hiện câu lệnh
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Kiểm tra và đọc dữ liệu
                    while (reader.Read())
                    {
                        // Lấy dữ liệu từ từng cột
                        emailList.Add(new EmailClass
                        {
                            From = reader["FromEmail"] == DBNull.Value ? string.Empty : reader["FromEmail"].ToString(),
                            To = reader["ToEmail"] == DBNull.Value ? string.Empty : reader["ToEmail"].ToString(),
                            Subject = reader["Subject"] == DBNull.Value ? string.Empty : reader["Subject"].ToString(),
                            Body = reader["Body"] == DBNull.Value ? string.Empty : reader["Body"].ToString(),
                            SentTime = reader["SentTime"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["SentTime"]
                        });

                    }
                    // Chuyển thành JSON một lần
                    string json = JsonSerializer.Serialize(emailList);
                    byte[] data = Encoding.UTF8.GetBytes(json);
                    stream.Write(data, 0, data.Length);  // Gửi toàn bộ danh sách JSON
                    stream.Flush();
                }
            }
        }
        private void HandleSending(string[] details, NetworkStream stream)
        {
            EmailClass email = new EmailClass
            {
                From = details[1],
                To = details[2],
                Subject = details[3],
                Body = details[4],
                SentTime = DateTime.Now
            };

            //Lưu email vào database
            string query = @"INSERT INTO Emails (FromEmail, ToEmail, Subject, Body, SentTime) VALUES (@FromEmail, @ToEmail, @Subject, @Body, @SentTime);";
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@FromEmail", email.From);
                cmd.Parameters.AddWithValue("@ToEmail", email.To);
                cmd.Parameters.AddWithValue("@Subject", email.Subject);
                cmd.Parameters.AddWithValue("@Body", email.Body);
                cmd.Parameters.AddWithValue("@SentTime", email.SentTime);

                int rowsAffected = cmd.ExecuteNonQuery();

                string responseMessage = rowsAffected > 0 ? "Success" : "Fail send email";
                byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
                stream.Write(responseData, 0, responseData.Length);
                stream.Flush();
            }
        }
        private void HandleInfo(string[] details, NetworkStream stream)
        {
            string email = details[1];

            string infoQuery = "SELECT (*) FROM Register WHERE email = @email";
            using (SqlCommand cmd = new SqlCommand(infoQuery, sqlConnection))
            {
                cmd.Parameters.AddWithValue("email", email);
                //Thực hiện câu lệnh
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Kiểm tra và đọc dữ liệu
                    while (reader.Read())
                    {
                        // Lấy dữ liệu từ từng cột
                        string username = reader["username"].ToString();

                        //int userCount = (int)cmd.ExecuteScalar();
                        string responseMessage =  username != null ? $"{username}" : "Invalid Username or Email";
                        byte[] responseData = Encoding.UTF8.GetBytes(username);
                    }
                }
            }
        }
        private void HandleVerifyAccount(string[] details, NetworkStream stream)
        {
            string username = details[1];
            string email = details[2];

            string resetQuery = "SELECT COUNT(*) FROM Register WHERE username = @username AND email = @email";
            using (SqlCommand cmd = new SqlCommand(resetQuery, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);

                int userCount = (int)cmd.ExecuteScalar();
                string responseMessage = userCount > 0 ? "Success" : "Invalid Username or Email";
                byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
                stream.Write(responseData, 0, responseData.Length);
                stream.Flush();

                // Log cho debug
                Console.WriteLine($"Reset attempt for user {username}: {responseMessage}");
            }
        }

        private void HandleReset (string[] details, NetworkStream stream)
        {
            string email = details[1];
            string password = details[2];

            //Đổi mật khẩu người dùng
            string resetPasswordQuery = "UPDATE Register SET password = @password WHERE email = @email";
            using (SqlCommand cmd = new SqlCommand(resetPasswordQuery, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                int rowsAffected = cmd.ExecuteNonQuery();

                string responseMessage = rowsAffected > 0 ? "Success" : "Fail reset password";
                byte[] responseData = Encoding.UTF8.GetBytes (responseMessage);
                stream.Write(responseData , 0, responseData.Length);
                stream.Flush();
            }
            // Cập nhật giao diện hiển thị
            Invoke(new Action(() =>
            {
                lstChat.Items.Add($"User {email} has changed password.");
            }));
        }
        private void HandleRegistration(string[] details, NetworkStream stream)
        {
            string username = details[1];
            string email = details[2];
            string password = details[3];

            // Kiểm tra username đã tồn tại
            string checkEmail = "SELECT COUNT(*) FROM Register WHERE email = @email";
            using (SqlCommand cmdCheck = new SqlCommand(checkEmail, sqlConnection))
            {
                cmdCheck.Parameters.AddWithValue("@email", email);
                int userCount = (int)cmdCheck.ExecuteScalar();
                if (userCount > 0)
                {
                    byte[] responseData = Encoding.UTF8.GetBytes("Email already exists");
                    stream.Write(responseData, 0, responseData.Length);
                    return;
                }
            }

            // Lưu thông tin người dùng
            string registerQuery = "INSERT INTO Register (username, email, password) VALUES (@username, @email, @password)";
            using (SqlCommand cmd = new SqlCommand(registerQuery, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery(); //Thực thi câu lệnh
            }

            // Cập nhật giao diện hiển thị
            Invoke(new Action(() =>
            {
                lstChat.Items.Add($"User {username} has signed up.");
            }));

            // Gửi phản hồi cho client
            byte[] response = Encoding.UTF8.GetBytes("Registration Successful");
            stream.Write(response, 0, response.Length);
        }

        private void HandleLogin(string[] details, NetworkStream stream)
        {
            string email = details[1];
            string password = PasswordHandler.HashPassword(details[2]);

            // Kiểm tra thông tin đăng nhập với cơ sở dữ liệu
            string loginQuery = "SELECT COUNT(*) FROM Register WHERE email = @email AND password = @password";
            using (SqlCommand cmd = new SqlCommand(loginQuery, sqlConnection))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                int userCount = (int)cmd.ExecuteScalar();

                // Gửi phản hồi về client
                string responseMessage = userCount > 0 ? "Success" : "Invalid Username or Password";
                byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
                stream.Write(responseData, 0, responseData.Length);

                // Cập nhật giao diện hiển thị
                Invoke(new Action(() =>
                {
                    if (userCount > 0)
                    {
                        lstChat.Items.Add($"User {email} has logged in.");
                    }
                    else
                    {
                        lstChat.Items.Add($"Failed login attempt for user {email}.");
                    }
                }));
            }
        }
        public static class PasswordHandler
        {
            public static string HashPassword(string password)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder builder = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        builder.Append(b.ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }

            if (tcpListener != null)
            {
                tcpListener.Stop();
            }
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstChat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
