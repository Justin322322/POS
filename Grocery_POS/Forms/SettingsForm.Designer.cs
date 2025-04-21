namespace Grocery_POS.Forms
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServer = new Grocery_POS.UI.NeoBrutalistTextBox();
            this.txtDatabase = new Grocery_POS.UI.NeoBrutalistTextBox();
            this.txtUsername = new Grocery_POS.UI.NeoBrutalistTextBox();
            this.txtPassword = new Grocery_POS.UI.NeoBrutalistTextBox();
            this.btnSaveSettings = new Grocery_POS.UI.NeoBrutalistButton();
            this.btnTestConnection = new Grocery_POS.UI.NeoBrutalistButton();
            this.panelSettings = new Grocery_POS.UI.NeoBrutalistPanel();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Configuration";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(20, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server:";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(20, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Database:";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(20, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Username:";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(20, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password:";
            //
            // txtServer
            //
            this.txtServer.BackColor = System.Drawing.SystemColors.Window;
            this.txtServer.BorderColor = System.Drawing.Color.Black;
            this.txtServer.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.txtServer.BorderRadius = 0;
            this.txtServer.BorderSize = 3;
            this.txtServer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtServer.ForeColor = System.Drawing.Color.Black;
            this.txtServer.Location = new System.Drawing.Point(120, 75);
            this.txtServer.Margin = new System.Windows.Forms.Padding(4);
            this.txtServer.Multiline = false;
            this.txtServer.Name = "txtServer";
            this.txtServer.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtServer.PasswordChar = false;
            this.txtServer.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtServer.PlaceholderText = "localhost";
            this.txtServer.Size = new System.Drawing.Size(250, 36);
            this.txtServer.TabIndex = 5;
            this.txtServer.Texts = "";
            this.txtServer.UnderlinedStyle = false;
            //
            // txtDatabase
            //
            this.txtDatabase.BackColor = System.Drawing.SystemColors.Window;
            this.txtDatabase.BorderColor = System.Drawing.Color.Black;
            this.txtDatabase.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.txtDatabase.BorderRadius = 0;
            this.txtDatabase.BorderSize = 3;
            this.txtDatabase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDatabase.ForeColor = System.Drawing.Color.Black;
            this.txtDatabase.Location = new System.Drawing.Point(120, 125);
            this.txtDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.txtDatabase.Multiline = false;
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDatabase.PasswordChar = false;
            this.txtDatabase.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDatabase.PlaceholderText = "grocery_pos";
            this.txtDatabase.Size = new System.Drawing.Size(250, 36);
            this.txtDatabase.TabIndex = 6;
            this.txtDatabase.Texts = "";
            this.txtDatabase.UnderlinedStyle = false;
            //
            // txtUsername
            //
            this.txtUsername.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsername.BorderColor = System.Drawing.Color.Black;
            this.txtUsername.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.txtUsername.BorderRadius = 0;
            this.txtUsername.BorderSize = 3;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.Location = new System.Drawing.Point(120, 175);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUsername.PasswordChar = false;
            this.txtUsername.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUsername.PlaceholderText = "root";
            this.txtUsername.Size = new System.Drawing.Size(250, 36);
            this.txtUsername.TabIndex = 7;
            this.txtUsername.Texts = "";
            this.txtUsername.UnderlinedStyle = false;
            //
            // txtPassword
            //
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.BorderColor = System.Drawing.Color.Black;
            this.txtPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.txtPassword.BorderRadius = 0;
            this.txtPassword.BorderSize = 3;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(120, 225);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPassword.PasswordChar = true;
            this.txtPassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPassword.PlaceholderText = "password";
            this.txtPassword.Size = new System.Drawing.Size(250, 36);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Texts = "";
            this.txtPassword.UnderlinedStyle = false;
            //
            // btnSaveSettings
            //
            this.btnSaveSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnSaveSettings.BorderColor = System.Drawing.Color.Black;
            this.btnSaveSettings.BorderRadius = 0;
            this.btnSaveSettings.BorderSize = 3;
            this.btnSaveSettings.FlatAppearance.BorderSize = 0;
            this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveSettings.ForeColor = System.Drawing.Color.Black;
            this.btnSaveSettings.HoverBorderColor = System.Drawing.Color.Black;
            // this.btnSaveSettings.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSaveSettings.Location = new System.Drawing.Point(120, 285);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.ShadowColor = System.Drawing.Color.Black;
            this.btnSaveSettings.ShadowSize = 5;
            this.btnSaveSettings.Size = new System.Drawing.Size(120, 40);
            this.btnSaveSettings.TabIndex = 9;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            //
            // btnTestConnection
            //
            this.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnTestConnection.BorderColor = System.Drawing.Color.Black;
            this.btnTestConnection.BorderRadius = 0;
            this.btnTestConnection.BorderSize = 3;
            this.btnTestConnection.FlatAppearance.BorderSize = 0;
            this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTestConnection.ForeColor = System.Drawing.Color.Black;
            this.btnTestConnection.HoverBorderColor = System.Drawing.Color.Black;
            // this.btnTestConnection.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTestConnection.Location = new System.Drawing.Point(250, 285);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.ShadowColor = System.Drawing.Color.Black;
            this.btnTestConnection.ShadowSize = 5;
            this.btnTestConnection.Size = new System.Drawing.Size(120, 40);
            this.btnTestConnection.TabIndex = 10;
            this.btnTestConnection.Text = "Test";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            //
            // SettingsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1060, 640);

            // panelSettings
            this.panelSettings.BackColor = System.Drawing.Color.White;
            this.panelSettings.BorderColor = System.Drawing.Color.Black;
            this.panelSettings.BorderRadius = 0;
            this.panelSettings.BorderSize = 3;
            this.panelSettings.Controls.Add(this.btnTestConnection);
            this.panelSettings.Controls.Add(this.btnSaveSettings);
            this.panelSettings.Controls.Add(this.txtPassword);
            this.panelSettings.Controls.Add(this.txtUsername);
            this.panelSettings.Controls.Add(this.txtDatabase);
            this.panelSettings.Controls.Add(this.txtServer);
            this.panelSettings.Controls.Add(this.label5);
            this.panelSettings.Controls.Add(this.label4);
            this.panelSettings.Controls.Add(this.label3);
            this.panelSettings.Controls.Add(this.label2);
            this.panelSettings.Controls.Add(this.label1);
            this.panelSettings.Location = new System.Drawing.Point(50, 50);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.OffsetX = 5;
            this.panelSettings.OffsetY = 5;
            this.panelSettings.Padding = new System.Windows.Forms.Padding(20);
            this.panelSettings.ShadowColor = System.Drawing.Color.Black;
            this.panelSettings.ShadowSize = 5;
            this.panelSettings.Size = new System.Drawing.Size(500, 350);
            this.panelSettings.TabIndex = 0;

            this.Controls.Add(this.panelSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private UI.NeoBrutalistTextBox txtServer;
        private UI.NeoBrutalistTextBox txtDatabase;
        private UI.NeoBrutalistTextBox txtUsername;
        private UI.NeoBrutalistTextBox txtPassword;
        private UI.NeoBrutalistButton btnSaveSettings;
        private UI.NeoBrutalistButton btnTestConnection;
        private UI.NeoBrutalistPanel panelSettings;
    }
}
