using FontAwesome.Sharp;
using Grocery_POS.UI;
using System.Windows.Forms;

namespace Grocery_POS.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            panelMenu = new NeoBrutalistPanel();
            btnLogout = new IconButton();
            btnSettings = new IconButton();
            btnReports = new IconButton();
            btnTransactions = new IconButton();
            btnProducts = new IconButton();
            btnPOS = new IconButton();
            panelLogo = new Panel();
            lblUserRole = new Label();
            lblUserName = new Label();
            pictureBox1 = new PictureBox();
            panelTitleBar = new NeoBrutalistPanel();
            lblTitle = new Label();
            panelDesktop = new DottedBackgroundPanel();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.White;
            panelMenu.BorderColor = Color.Black;
            panelMenu.Controls.Add(btnLogout);
            panelMenu.Controls.Add(btnSettings);
            panelMenu.Controls.Add(btnReports);
            panelMenu.Controls.Add(btnTransactions);
            panelMenu.Controls.Add(btnProducts);
            panelMenu.Controls.Add(btnPOS);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Padding = new Padding(3);
            panelMenu.ShadowColor = Color.Black;
            panelMenu.Size = new Size(220, 880);
            panelMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(255, 204, 0);
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 2;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F);
            btnLogout.ForeColor = Color.Black;
            btnLogout.IconChar = IconChar.SignOutAlt;
            btnLogout.IconColor = Color.Black;
            btnLogout.IconFont = IconFont.Auto;
            btnLogout.IconSize = 32;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(3, 830);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(10, 0, 20, 0);
            btnLogout.Size = new Size(214, 47);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(255, 204, 0);
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 2;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 12F);
            btnSettings.ForeColor = Color.Black;
            btnSettings.IconChar = IconChar.Cog;
            btnSettings.IconColor = Color.Black;
            btnSettings.IconFont = IconFont.Auto;
            btnSettings.IconSize = 32;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(3, 347);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(10, 0, 20, 0);
            btnSettings.Size = new Size(214, 60);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(255, 204, 0);
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 2;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 12F);
            btnReports.ForeColor = Color.Black;
            btnReports.IconChar = IconChar.BarChart;
            btnReports.IconColor = Color.Black;
            btnReports.IconFont = IconFont.Auto;
            btnReports.IconSize = 32;
            btnReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnReports.Location = new Point(3, 287);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(10, 0, 20, 0);
            btnReports.Size = new Size(214, 60);
            btnReports.TabIndex = 4;
            btnReports.Text = "Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnTransactions
            // 
            btnTransactions.BackColor = Color.FromArgb(255, 204, 0);
            btnTransactions.Dock = DockStyle.Top;
            btnTransactions.FlatAppearance.BorderSize = 2;
            btnTransactions.FlatStyle = FlatStyle.Flat;
            btnTransactions.Font = new Font("Segoe UI", 12F);
            btnTransactions.ForeColor = Color.Black;
            btnTransactions.IconChar = IconChar.FileInvoiceDollar;
            btnTransactions.IconColor = Color.Black;
            btnTransactions.IconFont = IconFont.Auto;
            btnTransactions.IconSize = 32;
            btnTransactions.ImageAlign = ContentAlignment.MiddleLeft;
            btnTransactions.Location = new Point(3, 227);
            btnTransactions.Name = "btnTransactions";
            btnTransactions.Padding = new Padding(10, 0, 20, 0);
            btnTransactions.Size = new Size(214, 60);
            btnTransactions.TabIndex = 3;
            btnTransactions.Text = "Transactions";
            btnTransactions.TextAlign = ContentAlignment.MiddleLeft;
            btnTransactions.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTransactions.UseVisualStyleBackColor = true;
            btnTransactions.Click += btnTransactions_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(255, 204, 0);
            btnProducts.Dock = DockStyle.Top;
            btnProducts.FlatAppearance.BorderSize = 2;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 12F);
            btnProducts.ForeColor = Color.Black;
            btnProducts.IconChar = IconChar.BoxOpen;
            btnProducts.IconColor = Color.Black;
            btnProducts.IconFont = IconFont.Auto;
            btnProducts.IconSize = 32;
            btnProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnProducts.Location = new Point(3, 167);
            btnProducts.Name = "btnProducts";
            btnProducts.Padding = new Padding(10, 0, 20, 0);
            btnProducts.Size = new Size(214, 60);
            btnProducts.TabIndex = 2;
            btnProducts.Text = "Products";
            btnProducts.TextAlign = ContentAlignment.MiddleLeft;
            btnProducts.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnPOS
            // 
            btnPOS.BackColor = Color.FromArgb(255, 204, 0);
            btnPOS.Dock = DockStyle.Top;
            btnPOS.FlatAppearance.BorderSize = 2;
            btnPOS.FlatStyle = FlatStyle.Flat;
            btnPOS.Font = new Font("Segoe UI", 12F);
            btnPOS.ForeColor = Color.Black;
            btnPOS.IconChar = IconChar.CartShopping;
            btnPOS.IconColor = Color.Black;
            btnPOS.IconFont = IconFont.Auto;
            btnPOS.IconSize = 32;
            btnPOS.ImageAlign = ContentAlignment.MiddleLeft;
            btnPOS.Location = new Point(3, 107);
            btnPOS.Name = "btnPOS";
            btnPOS.Padding = new Padding(10, 0, 20, 0);
            btnPOS.Size = new Size(214, 60);
            btnPOS.TabIndex = 1;
            btnPOS.Text = "POS";
            btnPOS.TextAlign = ContentAlignment.MiddleLeft;
            btnPOS.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPOS.UseVisualStyleBackColor = true;
            btnPOS.Click += btnPOS_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(255, 204, 0);
            panelLogo.Controls.Add(lblUserRole);
            panelLogo.Controls.Add(lblUserName);
            panelLogo.Controls.Add(pictureBox1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(3, 3);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(214, 104);
            panelLogo.TabIndex = 0;
            // 
            // lblUserRole
            // 
            lblUserRole.AutoSize = true;
            lblUserRole.Font = new Font("Segoe UI", 9F);
            lblUserRole.ForeColor = Color.Black;
            lblUserRole.Location = new Point(76, 53);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(30, 15);
            lblUserRole.TabIndex = 2;
            lblUserRole.Text = "Role";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUserName.ForeColor = Color.Black;
            lblUserName.Location = new Point(76, 32);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(94, 21);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "User Name";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.White;
            panelTitleBar.BorderColor = Color.Black;
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(220, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Padding = new Padding(3);
            panelTitleBar.ShadowColor = Color.Black;
            panelTitleBar.Size = new Size(1060, 80);
            panelTitleBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Black;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Yellow;
            lblTitle.Location = new Point(22, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(60, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "POS";
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(255, 204, 0);
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.DotColor = Color.FromArgb(0, 120, 215);
            panelDesktop.Location = new Point(220, 80);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1060, 800);
            panelDesktop.TabIndex = 2;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 880);
            Controls.Add(panelDesktop);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Grocery POS - Dashboard";
            Load += DashboardForm_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private NeoBrutalistPanel panelMenu;
        private Panel panelLogo;
        private IconButton btnPOS;
        private IconButton btnLogout;
        private IconButton btnSettings;
        private IconButton btnReports;
        private IconButton btnTransactions;
        private IconButton btnProducts;
        private Label lblUserRole;
        private Label lblUserName;
        private PictureBox pictureBox1;
        private NeoBrutalistPanel panelTitleBar;
        private Label lblTitle;
        private DottedBackgroundPanel panelDesktop;
    }
}
