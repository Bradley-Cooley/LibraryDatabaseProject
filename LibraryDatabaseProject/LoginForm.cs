using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDatabaseProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int id;
            bool result = int.TryParse(userIdTextBox.Text, out id);

            if (userIdTextBox.Text != "" && result)
            {
                using(var context = new LibraryModel())
                {
                    var userId = (from user in context.users
                                 where user.user_id == id
                                 select user).FirstOrDefault();

                    if(userId != null)
                    {
                        showMainForm(false);
                    }
                    else
                    {
                        MessageBox.Show("No User Found with given User ID", "Library Database",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
            }else
            {
                MessageBox.Show("No User Found with given User ID", "Library Database",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            bool result = int.TryParse(userIdTextBox.Text, out id);

            if (userIdTextBox.Text != "" && result)
            {
                using (var context = new LibraryModel())
                {
                    var userId = (from user in context.adminusers
                                  where user.admin_id == id
                                  select user).FirstOrDefault();

                    if (userId != null)
                    {
                        showMainForm(true);
                    }
                    else
                    {
                        MessageBox.Show("No User Found with given User ID", "Library Database",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }

                }
            }
            else
            {
                MessageBox.Show("No User Found with given User ID", "Library Database",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void showMainForm(bool isAdmin)
        {
            this.Hide();
            Form1.isAdmin = isAdmin;
            Form1 form = new Form1();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
