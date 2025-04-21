using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Grocery_POS.Services;
using Grocery_POS.UI;

namespace Grocery_POS.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserService userService;

        public LoginForm()
        {
            InitializeComponent();
            userService = new UserService();

            // Add form load event handler
            this.Load += LoginForm_Load;

            try
            {
                // Initialize database silently without showing popup
                DatabaseConnection.Instance.InitializeDatabase();

                // Pre-fill the username field with "admin"
                txtUsername.Text = "admin";

                // Ensure password field is using password masking
                txtPassword.PasswordChar = true;

                // Set focus to password field
                txtPassword.Focus();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (userService.Authenticate(username, password))
            {
                var user = userService.GetUserByUsername(username);
                if (user != null)
                {
                    // Open dashboard form
                    DashboardForm dashboardForm = new DashboardForm(user);
                    this.Hide();
                    dashboardForm.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Ensure password field is using password masking
            txtPassword.PasswordChar = true;
        }
    }
}
