using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grocery_POS.Services;
using Grocery_POS.UI;

namespace Grocery_POS.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly DatabaseConnection dbConnection;

        public SettingsForm()
        {
            InitializeComponent();
            dbConnection = DatabaseConnection.Instance;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Load current connection settings
            txtServer.Texts = "localhost";
            txtDatabase.Texts = "grocery_pos";
            txtUsername.Texts = "root";
            txtPassword.Texts = "";
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                string server = txtServer.Texts.Trim();
                string database = txtDatabase.Texts.Trim();
                string username = txtUsername.Texts.Trim();
                string password = txtPassword.Texts.Trim();

                if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database) || string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update connection string
                dbConnection.SetConnectionString(server, database, username, password);
                MessageBox.Show("Settings saved successfully. Please restart the application for changes to take effect.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                string server = txtServer.Texts.Trim();
                string database = txtDatabase.Texts.Trim();
                string username = txtUsername.Texts.Trim();
                string password = txtPassword.Texts.Trim();

                if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database) || string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create temporary connection string
                string connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
                
                // Test connection
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
