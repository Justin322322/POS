using Grocery_POS.UI;
using FontAwesome.Sharp;

namespace Grocery_POS.Forms
{
    partial class LoginForm
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
            label2 = new Label();
            label3 = new Label();
            txtUsername = new NeoBrutalistTextBox();
            txtPassword = new NeoBrutalistTextBox();
            btnLogin = new NeoBrutalistButton();
            iconPictureBox2 = new IconPictureBox();
            iconPictureBox3 = new IconPictureBox();
            label1 = new Label();
            panel1 = new NeoBrutalistPanel();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(48, 147);
            label2.Name = "label2";
            label2.Size = new Size(87, 21);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(48, 217);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.BorderColor = Color.Black;
            txtUsername.BorderFocusColor = Color.FromArgb(255, 204, 0);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 14F);
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(48, 171);
            txtUsername.MinimumSize = new Size(0, 50);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderColor = Color.DarkGray;
            txtUsername.Size = new Size(304, 50);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderColor = Color.Black;
            txtPassword.BorderFocusColor = Color.FromArgb(255, 204, 0);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 14F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(48, 241);
            txtPassword.MinimumSize = new Size(0, 50);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderColor = Color.DarkGray;
            txtPassword.Size = new Size(304, 50);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.White;
            btnLogin.BorderColor = Color.Black;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnLogin.ForeColor = Color.Black;
            btnLogin.HoverBorderColor = Color.Black;
            btnLogin.Location = new Point(48, 307);
            btnLogin.Name = "btnLogin";
            btnLogin.Padding = new Padding(0, 0, 5, 5);
            btnLogin.ShadowColor = Color.Black;
            btnLogin.Size = new Size(304, 50);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.BackColor = Color.FromArgb(255, 204, 0);
            iconPictureBox2.ForeColor = Color.Black;
            iconPictureBox2.IconChar = IconChar.User;
            iconPictureBox2.IconColor = Color.Black;
            iconPictureBox2.IconFont = IconFont.Auto;
            iconPictureBox2.IconSize = 24;
            iconPictureBox2.Location = new Point(18, 186);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(24, 24);
            iconPictureBox2.TabIndex = 6;
            iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox3
            // 
            iconPictureBox3.BackColor = Color.FromArgb(255, 204, 0);
            iconPictureBox3.ForeColor = Color.Black;
            iconPictureBox3.IconChar = IconChar.Lock;
            iconPictureBox3.IconColor = Color.Black;
            iconPictureBox3.IconFont = IconFont.Auto;
            iconPictureBox3.IconSize = 24;
            iconPictureBox3.Location = new Point(18, 254);
            iconPictureBox3.Name = "iconPictureBox3";
            iconPictureBox3.Size = new Size(24, 24);
            iconPictureBox3.TabIndex = 7;
            iconPictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(83, 60);
            label1.Name = "label1";
            label1.Size = new Size(257, 32);
            label1.TabIndex = 1;
            label1.Text = "GROCERY POS LOGIN";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 204, 0);
            panel1.BorderColor = Color.Black;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-13, 1);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3);
            panel1.ShadowColor = Color.Black;
            panel1.Size = new Size(507, 112);
            panel1.TabIndex = 0;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 204, 0);
            ClientSize = new Size(400, 400);
            Controls.Add(iconPictureBox3);
            Controls.Add(iconPictureBox2);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Grocery POS - Login";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Label label2;
        private Label label3;
        private NeoBrutalistTextBox txtUsername;
        private NeoBrutalistTextBox txtPassword;
        private NeoBrutalistButton btnLogin;
        private IconPictureBox iconPictureBox2;
        private IconPictureBox iconPictureBox3;
        private Label label1;
        private NeoBrutalistPanel panel1;
    }
}
