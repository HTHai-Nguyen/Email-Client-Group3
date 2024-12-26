using System;
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
    public partial class EmailCompose : Form
    {
        private List<string> attachmentFiles = new List<string>();
        public EmailCompose()
        {
            InitializeComponent();
        }

        private void picAttachment_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                openFileDialog.Title = "Select a File";  

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    attachmentFiles.AddRange(openFileDialog.FileNames);
                    txtAttachments.Text = string.Join(", ", attachmentFiles);
                }
            }
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    attachmentFiles.AddRange(openFileDialog.FileNames);
                    txtAttachments.Text = string.Join(", ", attachmentFiles);
                }
            }
        }

        private void picSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtRecipient.Text) ||
                string.IsNullOrWhiteSpace(txtSubject.Text) || string.IsNullOrWhiteSpace(txtBody.Text))
            {
                MessageBox.Show("Please complete all fields.", "Compose Failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Email sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearAttachments_Click(object sender, EventArgs e)
        {
            attachmentFiles.Clear();
            txtAttachments.Clear();
        }
    }
}
