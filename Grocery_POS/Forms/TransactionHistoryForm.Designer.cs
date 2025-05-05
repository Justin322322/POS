using Grocery_POS.UI;
using FontAwesome.Sharp;

namespace Grocery_POS.Forms
{
    partial class TransactionHistoryForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelTransactions = new NeoBrutalistPanel();
            dgvTransactions = new DataGridView();
            panelFilter = new NeoBrutalistPanel();
            btnFilter = new NeoBrutalistButton();
            dtpEndDate = new DateTimePicker();
            label3 = new Label();
            dtpStartDate = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            panelTransactionItems = new NeoBrutalistPanel();
            dgvTransactionItems = new DataGridView();
            label4 = new Label();
            panelSummary = new NeoBrutalistPanel();
            lblTotalSales = new Label();
            label5 = new Label();
            lblTitle = new Label();
            panelTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            panelFilter.SuspendLayout();
            panelTransactionItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactionItems).BeginInit();
            panelSummary.SuspendLayout();
            SuspendLayout();
            // 
            // panelTransactions
            // 
            panelTransactions.BackColor = Color.White;
            panelTransactions.BorderColor = Color.Black;
            panelTransactions.Controls.Add(dgvTransactions);
            panelTransactions.Location = new Point(12, 140);
            panelTransactions.Name = "panelTransactions";
            panelTransactions.Padding = new Padding(10);
            panelTransactions.ShadowColor = Color.Black;
            panelTransactions.ShadowSize = 3;
            panelTransactions.Size = new Size(796, 587);
            panelTransactions.TabIndex = 0;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.BackgroundColor = Color.White;
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransactions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTransactions.ColumnHeadersHeight = 45;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(5, 0, 5, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 204, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTransactions.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.Location = new Point(13, 20);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.RowTemplate.Height = 35;
            dgvTransactions.Size = new Size(770, 554);
            dgvTransactions.TabIndex = 0;
            dgvTransactions.CellClick += dgvTransactions_CellClick;
            // 
            // panelFilter
            // 
            panelFilter.BackColor = Color.White;
            panelFilter.BorderColor = Color.Black;
            panelFilter.Controls.Add(btnFilter);
            panelFilter.Controls.Add(dtpEndDate);
            panelFilter.Controls.Add(label3);
            panelFilter.Controls.Add(dtpStartDate);
            panelFilter.Controls.Add(label2);
            panelFilter.Controls.Add(label1);
            panelFilter.Location = new Point(12, 70);
            panelFilter.Name = "panelFilter";
            panelFilter.Padding = new Padding(10);
            panelFilter.ShadowColor = Color.Black;
            panelFilter.ShadowSize = 3;
            panelFilter.Size = new Size(796, 64);
            panelFilter.TabIndex = 1;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(50, 50, 50);
            btnFilter.BorderColor = Color.Black;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.HoverBorderColor = Color.Black;
            btnFilter.Location = new Point(526, 15);
            btnFilter.Name = "btnFilter";
            btnFilter.OffsetX = 3;
            btnFilter.OffsetY = 3;
            btnFilter.Padding = new Padding(0, 0, 3, 3);
            btnFilter.ShadowColor = Color.Black;
            btnFilter.ShadowSize = 3;
            btnFilter.Size = new Size(100, 35);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "FILTER";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Font = new Font("Segoe UI", 9.75F);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(400, 19);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(120, 25);
            dtpEndDate.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Black;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.Yellow;
            label3.Location = new Point(330, 24);
            label3.Name = "label3";
            label3.Size = new Size(64, 17);
            label3.TabIndex = 3;
            label3.Text = "End Date";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new Font("Segoe UI", 9.75F);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(204, 20);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(120, 25);
            dtpStartDate.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.Yellow;
            label2.Location = new Point(128, 25);
            label2.Name = "label2";
            label2.Size = new Size(70, 17);
            label2.TabIndex = 1;
            label2.Text = "Start Date";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(15, 20);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 0;
            label1.Text = "Filter by:";
            // 
            // panelTransactionItems
            // 
            panelTransactionItems.BackColor = Color.White;
            panelTransactionItems.BorderColor = Color.Black;
            panelTransactionItems.Controls.Add(dgvTransactionItems);
            panelTransactionItems.Controls.Add(label4);
            panelTransactionItems.Location = new Point(819, 140);
            panelTransactionItems.Name = "panelTransactionItems";
            panelTransactionItems.Padding = new Padding(10);
            panelTransactionItems.ShadowColor = Color.Black;
            panelTransactionItems.ShadowSize = 3;
            panelTransactionItems.Size = new Size(373, 587);
            panelTransactionItems.TabIndex = 2;
            // 
            // dgvTransactionItems
            // 
            dgvTransactionItems.AllowUserToAddRows = false;
            dgvTransactionItems.AllowUserToDeleteRows = false;
            dgvTransactionItems.BackgroundColor = Color.White;
            dgvTransactionItems.BorderStyle = BorderStyle.None;
            dgvTransactionItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransactionItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvTransactionItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTransactionItems.ColumnHeadersHeight = 40;
            dgvTransactionItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new Padding(5, 0, 5, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 204, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvTransactionItems.DefaultCellStyle = dataGridViewCellStyle4;
            dgvTransactionItems.EnableHeadersVisualStyles = false;
            dgvTransactionItems.Location = new Point(13, 43);
            dgvTransactionItems.Name = "dgvTransactionItems";
            dgvTransactionItems.RowHeadersVisible = false;
            dgvTransactionItems.RowTemplate.Height = 35;
            dgvTransactionItems.Size = new Size(347, 530);
            dgvTransactionItems.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label4.Location = new Point(13, 18);
            label4.Name = "label4";
            label4.Size = new Size(179, 25);
            label4.TabIndex = 0;
            label4.Text = "Transaction Details";
            // 
            // panelSummary
            // 
            panelSummary.BackColor = Color.White;
            panelSummary.BorderColor = Color.Black;
            panelSummary.Controls.Add(lblTotalSales);
            panelSummary.Controls.Add(label5);
            panelSummary.Location = new Point(819, 70);
            panelSummary.Name = "panelSummary";
            panelSummary.Padding = new Padding(15);
            panelSummary.ShadowColor = Color.Black;
            panelSummary.ShadowSize = 3;
            panelSummary.Size = new Size(373, 64);
            panelSummary.TabIndex = 3;
            // 
            // lblTotalSales
            // 
            lblTotalSales.AutoSize = true;
            lblTotalSales.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalSales.ForeColor = Color.FromArgb(50, 50, 50);
            lblTotalSales.Location = new Point(120, 15);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(89, 37);
            lblTotalSales.TabIndex = 1;
            lblTotalSales.Text = "₱0.00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(50, 50, 50);
            label5.Location = new Point(15, 15);
            label5.Name = "label5";
            label5.Size = new Size(128, 30);
            label5.TabIndex = 0;
            label5.Text = "Total Sales:";
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.TabIndex = 0;
            // 
            // TransactionHistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 204, 0);
            ClientSize = new Size(1211, 784);
            Controls.Add(panelSummary);
            Controls.Add(panelTransactionItems);
            Controls.Add(panelFilter);
            Controls.Add(panelTransactions);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TransactionHistoryForm";
            Text = "Transaction History";
            Load += TransactionHistoryForm_Load;
            panelTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelTransactionItems.ResumeLayout(false);
            panelTransactionItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactionItems).EndInit();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            ResumeLayout(false);

        }

        private void AddTitle()
        {
            // Add title label
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 45);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Transaction History";
            this.Controls.Add(this.lblTitle);
        }

        #endregion

        private NeoBrutalistPanel panelTransactions;
        private DataGridView dgvTransactions;
        private NeoBrutalistPanel panelFilter;
        private Label label1;
        private DateTimePicker dtpStartDate;
        private Label label2;
        private DateTimePicker dtpEndDate;
        private Label label3;
        private NeoBrutalistButton btnFilter;
        private NeoBrutalistPanel panelTransactionItems;
        private DataGridView dgvTransactionItems;
        private Label label4;
        private NeoBrutalistPanel panelSummary;
        private Label label5;
        private Label lblTotalSales;
        private Label lblTitle;
    }
}
