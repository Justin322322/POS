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
using Grocery_POS.Models;
using Grocery_POS.UI;

namespace Grocery_POS.Forms
{
    public partial class DashboardForm : Form
    {
        private User currentUser;
        private IconButton currentBtn;
        private Form? currentChildForm;

        public DashboardForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            lblUserName.Text = user.FullName;
            lblUserRole.Text = user.Role;
        }

        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                // Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.White;
                currentBtn.ForeColor = Color.Black;
                currentBtn.IconColor = Color.Black;
                currentBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(255, 204, 0);
                currentBtn.ForeColor = Color.Black;
                currentBtn.IconColor = Color.Black;
                currentBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            }
        }

        private void OpenChildForm(Form childForm)
        {
            // Close previous child form if exists
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
            }

            // Update title based on the form being opened
            lblTitle.Text = childForm.Text;

            // Configure child form for embedding
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Clear previous controls and add new form
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;

            // Ensure form is visible
            childForm.BringToFront();
            childForm.Show();

            // Force a refresh of the panel
            panelDesktop.Refresh();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new POSForm(currentUser));
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new ProductManagementForm());
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new TransactionHistoryForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new ReportsForm());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new SettingsForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Open POS form by default
            btnPOS_Click(btnPOS, EventArgs.Empty);
        }
    }
}
