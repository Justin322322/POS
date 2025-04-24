using Grocery_POS.UI;

namespace Grocery_POS.Forms
{
    partial class PaymentForm
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                // Dispose of any fonts we created
                if (lblChange?.Font != null)
                {
                    lblChange.Font.Dispose();
                }

                // Remove event handlers
                this.KeyDown -= PaymentForm_KeyDown;
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new NeoBrutalistPanel();
            label1 = new Label();
            label2 = new Label();
            lblTotalAmount = new Label();
            panel2 = new NeoBrutalistPanel();
            rbCard = new RadioButton();
            rbCash = new RadioButton();
            label7 = new Label();
            btnConfirm = new NeoBrutalistButton();
            btnCancel = new NeoBrutalistButton();
            label8 = new Label();
            panelAmountPaid = new NeoBrutalistPanel();
            label4 = new Label();
            txtAmountPaid = new NeoBrutalistTextBox();
            lblChangeLabel = new Label();
            lblChange = new Label();
            panelQuickButtons = new NeoBrutalistPanel();
            btnExact = new NeoBrutalistButton();
            btnQuick500 = new NeoBrutalistButton();
            btnQuick1000 = new NeoBrutalistButton();
            btnQuick100 = new NeoBrutalistButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelAmountPaid.SuspendLayout();
            panelQuickButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderColor = Color.Black;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.ShadowColor = Color.Black;
            panel1.Size = new Size(460, 60);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(255, 204, 0);
            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Size = new Size(127, 32);
            label1.TabIndex = 0;
            label1.Text = "PAYMENT";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(20, 100);
            label2.Name = "label2";
            label2.Size = new Size(150, 30);
            label2.TabIndex = 1;
            label2.Text = "Total Amount:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.Black;
            lblTotalAmount.Location = new Point(180, 100);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(300, 30);
            lblTotalAmount.TabIndex = 2;
            lblTotalAmount.Text = "₱0.00";
            lblTotalAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.BorderColor = Color.Black;
            panel2.Controls.Add(rbCard);
            panel2.Controls.Add(rbCash);
            panel2.Controls.Add(label7);
            panel2.Location = new Point(89, 164);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(15);
            panel2.ShadowColor = Color.DarkGray;
            panel2.Size = new Size(328, 60);
            panel2.TabIndex = 7;
            // 
            // rbCard
            // 
            rbCard.AutoSize = true;
            rbCard.BackColor = Color.DarkGray;
            rbCard.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            rbCard.ForeColor = Color.Black;
            rbCard.Location = new Point(250, 16);
            rbCard.Name = "rbCard";
            rbCard.Size = new Size(63, 25);
            rbCard.TabIndex = 2;
            rbCard.Text = "Card";
            rbCard.UseVisualStyleBackColor = false;
            rbCard.CheckedChanged += rbCard_CheckedChanged;
            // 
            // rbCash
            // 
            rbCash.AutoSize = true;
            rbCash.BackColor = Color.DarkGray;
            rbCash.Checked = true;
            rbCash.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            rbCash.ForeColor = Color.Black;
            rbCash.Location = new Point(180, 16);
            rbCash.Name = "rbCash";
            rbCash.Size = new Size(64, 25);
            rbCash.TabIndex = 1;
            rbCash.TabStop = true;
            rbCash.Text = "Cash";
            rbCash.UseVisualStyleBackColor = false;
            rbCash.CheckedChanged += rbCash_CheckedChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.DarkGray;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(15, 20);
            label7.Name = "label7";
            label7.Size = new Size(146, 21);
            label7.TabIndex = 0;
            label7.Text = "Payment Method:";
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.Lime;
            btnConfirm.BorderColor = Color.Black;
            btnConfirm.Enabled = false;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.Black;
            btnConfirm.HoverBorderColor = Color.Black;
            btnConfirm.Location = new Point(20, 510);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Padding = new Padding(0, 0, 5, 5);
            btnConfirm.ShadowColor = Color.Black;
            btnConfirm.Size = new Size(220, 50);
            btnConfirm.TabIndex = 8;
            btnConfirm.Text = "CONFIRM";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.HoverBorderColor = Color.Black;
            btnCancel.Location = new Point(260, 510);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(0, 0, 5, 5);
            btnCancel.ShadowColor = Color.Black;
            btnCancel.Size = new Size(220, 50);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 8F);
            label8.Location = new Point(35, 572);
            label8.Name = "label8";
            label8.Size = new Size(431, 13);
            label8.TabIndex = 14;
            label8.Text = "Shortcuts: F1=Exact | F2=+100 | F3=+500 | F4=+1000 | Enter=Confirm | Esc=Cancel";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAmountPaid
            // 
            panelAmountPaid.BackColor = Color.Black;
            panelAmountPaid.BorderColor = Color.Black;
            panelAmountPaid.Controls.Add(label4);
            panelAmountPaid.Controls.Add(txtAmountPaid);
            panelAmountPaid.Controls.Add(lblChangeLabel);
            panelAmountPaid.Controls.Add(lblChange);
            panelAmountPaid.Location = new Point(20, 230);
            panelAmountPaid.Name = "panelAmountPaid";
            panelAmountPaid.Padding = new Padding(15);
            panelAmountPaid.ShadowColor = Color.Black;
            panelAmountPaid.Size = new Size(460, 140);
            panelAmountPaid.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(255, 204, 0);
            label4.Location = new Point(15, 15);
            label4.Name = "label4";
            label4.Size = new Size(114, 21);
            label4.TabIndex = 3;
            label4.Text = "Amount Paid:";
            // 
            // txtAmountPaid
            // 
            txtAmountPaid.BackColor = Color.White;
            txtAmountPaid.BorderColor = Color.Black;
            txtAmountPaid.BorderFocusColor = Color.FromArgb(255, 204, 0);
            txtAmountPaid.BorderStyle = BorderStyle.None;
            txtAmountPaid.Font = new Font("Segoe UI", 18F);
            txtAmountPaid.ForeColor = Color.Black;
            txtAmountPaid.Location = new Point(30, 50);
            txtAmountPaid.MinimumSize = new Size(0, 50);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.PlaceholderColor = Color.DarkGray;
            txtAmountPaid.Size = new Size(400, 50);
            txtAmountPaid.TabIndex = 4;
            txtAmountPaid.TextAlign = HorizontalAlignment.Right;
            txtAmountPaid.TextChanged += txtAmountPaid_TextChanged;
            // 
            // lblChangeLabel
            // 
            lblChangeLabel.AutoSize = true;
            lblChangeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChangeLabel.ForeColor = Color.FromArgb(255, 204, 0);
            lblChangeLabel.Location = new Point(172, 109);
            lblChangeLabel.Name = "lblChangeLabel";
            lblChangeLabel.Size = new Size(72, 21);
            lblChangeLabel.TabIndex = 5;
            lblChangeLabel.Text = "Change:";
            lblChangeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblChange
            // 
            lblChange.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblChange.ForeColor = Color.FromArgb(255, 204, 0);
            lblChange.Location = new Point(150, 100);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(280, 30);
            lblChange.TabIndex = 6;
            lblChange.Text = "₱0.00";
            lblChange.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelQuickButtons
            // 
            panelQuickButtons.BackColor = Color.Black;
            panelQuickButtons.BorderColor = Color.Black;
            panelQuickButtons.Controls.Add(btnExact);
            panelQuickButtons.Controls.Add(btnQuick500);
            panelQuickButtons.Controls.Add(btnQuick1000);
            panelQuickButtons.Controls.Add(btnQuick100);
            panelQuickButtons.Location = new Point(17, 388);
            panelQuickButtons.Name = "panelQuickButtons";
            panelQuickButtons.Padding = new Padding(10);
            panelQuickButtons.ShadowColor = Color.Black;
            panelQuickButtons.Size = new Size(460, 98);
            panelQuickButtons.TabIndex = 16;
            // 
            // btnExact
            // 
            btnExact.BackColor = Color.FromArgb(255, 204, 0);
            btnExact.BorderColor = Color.Black;
            btnExact.FlatAppearance.BorderSize = 0;
            btnExact.FlatStyle = FlatStyle.Flat;
            btnExact.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnExact.ForeColor = Color.Black;
            btnExact.HoverBorderColor = Color.Black;
            btnExact.Location = new Point(10, 10);
            btnExact.Name = "btnExact";
            btnExact.OffsetX = 3;
            btnExact.OffsetY = 3;
            btnExact.Padding = new Padding(0, 0, 3, 3);
            btnExact.ShadowColor = Color.Black;
            btnExact.ShadowSize = 3;
            btnExact.Size = new Size(215, 30);
            btnExact.TabIndex = 10;
            btnExact.Text = "EXACT";
            btnExact.UseVisualStyleBackColor = false;
            btnExact.Click += btnExact_Click;
            // 
            // btnQuick500
            // 
            btnQuick500.BackColor = Color.FromArgb(255, 204, 0);
            btnQuick500.BorderColor = Color.Black;
            btnQuick500.FlatAppearance.BorderSize = 0;
            btnQuick500.FlatStyle = FlatStyle.Flat;
            btnQuick500.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnQuick500.ForeColor = Color.Black;
            btnQuick500.HoverBorderColor = Color.Black;
            btnQuick500.Location = new Point(10, 50);
            btnQuick500.Name = "btnQuick500";
            btnQuick500.OffsetX = 3;
            btnQuick500.OffsetY = 3;
            btnQuick500.Padding = new Padding(0, 0, 3, 3);
            btnQuick500.ShadowColor = Color.FromArgb(128, 128, 128);
            btnQuick500.Size = new Size(215, 30);
            btnQuick500.TabIndex = 12;
            btnQuick500.Text = "+₱500";
            btnQuick500.UseVisualStyleBackColor = false;
            btnQuick500.Click += btnQuick500_Click;
            // 
            // btnQuick1000
            // 
            btnQuick1000.BackColor = Color.FromArgb(255, 204, 0);
            btnQuick1000.BorderColor = Color.Black;
            btnQuick1000.FlatAppearance.BorderSize = 0;
            btnQuick1000.FlatStyle = FlatStyle.Flat;
            btnQuick1000.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnQuick1000.ForeColor = Color.Black;
            btnQuick1000.HoverBorderColor = Color.Black;
            btnQuick1000.Location = new Point(235, 50);
            btnQuick1000.Name = "btnQuick1000";
            btnQuick1000.OffsetX = 3;
            btnQuick1000.OffsetY = 3;
            btnQuick1000.Padding = new Padding(0, 0, 3, 3);
            btnQuick1000.ShadowColor = Color.FromArgb(128, 128, 128);
            btnQuick1000.Size = new Size(215, 30);
            btnQuick1000.TabIndex = 13;
            btnQuick1000.Text = "+₱1000";
            btnQuick1000.UseVisualStyleBackColor = false;
            btnQuick1000.Click += btnQuick1000_Click;
            // 
            // btnQuick100
            // 
            btnQuick100.BackColor = Color.FromArgb(255, 204, 0);
            btnQuick100.BorderColor = Color.Black;
            btnQuick100.FlatAppearance.BorderSize = 0;
            btnQuick100.FlatStyle = FlatStyle.Flat;
            btnQuick100.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnQuick100.ForeColor = Color.Black;
            btnQuick100.HoverBorderColor = Color.Black;
            btnQuick100.Location = new Point(235, 10);
            btnQuick100.Name = "btnQuick100";
            btnQuick100.OffsetX = 3;
            btnQuick100.OffsetY = 3;
            btnQuick100.Padding = new Padding(0, 0, 3, 3);
            btnQuick100.ShadowColor = Color.FromArgb(128, 128, 128);
            btnQuick100.Size = new Size(215, 30);
            btnQuick100.TabIndex = 11;
            btnQuick100.Text = "+₱100";
            btnQuick100.UseVisualStyleBackColor = false;
            btnQuick100.Click += btnQuick100_Click;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 204, 0);
            ClientSize = new Size(500, 600);
            Controls.Add(panelQuickButtons);
            Controls.Add(label8);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(panelAmountPaid);
            Controls.Add(panel2);
            Controls.Add(lblTotalAmount);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentForm";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Payment";
            TopMost = true;
            Load += PaymentForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelAmountPaid.ResumeLayout(false);
            panelAmountPaid.PerformLayout();
            panelQuickButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private NeoBrutalistPanel panel1;
        private Label label1;
        private Label label2;
        private Label lblTotalAmount;
        private Label label4;
        private NeoBrutalistTextBox txtAmountPaid;
        private Label lblChangeLabel;
        private Label lblChange;

        private NeoBrutalistPanel panel2;
        private RadioButton rbCard;
        private RadioButton rbCash;
        private Label label7;
        private NeoBrutalistButton btnConfirm;
        private NeoBrutalistButton btnCancel;
        private NeoBrutalistButton btnQuick100;
        private NeoBrutalistButton btnQuick500;
        private NeoBrutalistButton btnQuick1000;
        private NeoBrutalistButton btnExact;
        private Label label8;
        private NeoBrutalistPanel panelAmountPaid;
        private NeoBrutalistPanel panelQuickButtons;
    }
}
