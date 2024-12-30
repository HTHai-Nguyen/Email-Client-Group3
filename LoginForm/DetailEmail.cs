using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LoginForm
{
    public partial class DetailEmail : Form
    {
        private Email email;
        public DetailEmail(Email email)
        {
            InitializeComponent();
            this.email = email;
            LoadEmailDetails();
        }
        private void LoadEmailDetails()
        {
            lbFrom.Text = email.From;
            lbTo.Text = email.To;
            lbSubject.Text = email.Subject;
            txtBody.Text = email.Body;
            //lblSentTime.Text = email.SentTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void btnReplyEmail_Click(object sender, EventArgs e)
        {
            new ComposeForm(email.To, email.From).Show();
        }
    }
}
