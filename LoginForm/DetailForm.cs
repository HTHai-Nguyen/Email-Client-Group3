﻿using System;
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
    public partial class DetailForm : Form
    {

        public DetailForm(Email email)
        {
            InitializeComponent();
            DisplayEmail(email);
            btnBack.Click += btnBack_Click;

            //Controls 
            this.Controls.AddRange(new Control[]
        {
            lblFrom, lblSubject, lblDate,
            txtContent, btnBack
        });
        }

        private void DisplayEmail(Email email)
        {
            lblFrom.Text = "From: " + email.From;
            lblSubject.Text = "Subject: " + email.Subject;
            lblDate.Text = "Date: " + email.Date.ToString("g");
            txtContent.Text = email.Content;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}