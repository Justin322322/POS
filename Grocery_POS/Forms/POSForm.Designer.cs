using Grocery_POS.UI;
using FontAwesome.Sharp;

namespace Grocery_POS.Forms
{
    partial class POSForm
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelProducts = new NeoBrutalistPanel();
            btnCategoryManagement = new NeoBrutalistButton();
            dgvProducts = new DataGridView();
            label1 = new Label();
            txtSearch = new NeoBrutalistTextBox();
            btnAddToCart = new NeoBrutalistButton();
            panelCart = new NeoBrutalistPanel();
            btnPay = new NeoBrutalistButton();
            btnClearCart = new NeoBrutalistButton();
            btnRemoveFromCart = new NeoBrutalistButton();
            lblTotal = new Label();
            label3 = new Label();
            dgvCart = new DataGridView();
            label2 = new Label();
            panelBarcode = new NeoBrutalistPanel();
            iconPictureBox1 = new IconPictureBox();
            txtBarcode = new NeoBrutalistTextBox();
            label4 = new Label();
            panelProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panelCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            panelBarcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelProducts
            // 
            panelProducts.BackColor = Color.White;
            panelProducts.BorderColor = Color.Black;
            panelProducts.Controls.Add(btnCategoryManagement);
            panelProducts.Controls.Add(dgvProducts);
            panelProducts.Controls.Add(label1);
            panelProducts.Controls.Add(txtSearch);
            panelProducts.Location = new Point(12, 82);
            panelProducts.Name = "panelProducts";
            panelProducts.Padding = new Padding(3);
            panelProducts.ShadowColor = Color.Black;
            panelProducts.Size = new Size(612, 532);
            panelProducts.TabIndex = 0;
            // 
            // btnCategoryManagement
            // 
            btnCategoryManagement.BackColor = Color.White;
            btnCategoryManagement.BorderColor = Color.Black;
            btnCategoryManagement.FlatAppearance.BorderSize = 0;
            btnCategoryManagement.FlatStyle = FlatStyle.Flat;
            btnCategoryManagement.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnCategoryManagement.ForeColor = Color.Black;
            btnCategoryManagement.HoverBorderColor = Color.Black;
            btnCategoryManagement.Location = new Point(15, 440);
            btnCategoryManagement.Name = "btnCategoryManagement";
            btnCategoryManagement.OffsetX = 3;
            btnCategoryManagement.OffsetY = 3;
            btnCategoryManagement.Padding = new Padding(0, 0, 3, 3);
            btnCategoryManagement.ShadowColor = Color.Black;
            btnCategoryManagement.ShadowSize = 3;
            btnCategoryManagement.Size = new Size(581, 35);
            btnCategoryManagement.TabIndex = 3;
            btnCategoryManagement.Text = "CATEGORY MANAGEMENT";
            btnCategoryManagement.UseVisualStyleBackColor = false;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(15, 106);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            dgvProducts.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            dgvProducts.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 0);
            dgvProducts.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(581, 319);
            dgvProducts.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(15, 41);
            label1.Name = "label1";
            label1.Size = new Size(156, 25);
            label1.TabIndex = 1;
            label1.Text = "Search Products";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BorderColor = Color.Black;
            txtSearch.BorderFocusColor = Color.FromArgb(255, 128, 0);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.ForeColor = Color.Black;
            txtSearch.Location = new Point(177, 28);
            txtSearch.MinimumSize = new Size(0, 50);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderColor = Color.DarkGray;
            txtSearch.PlaceholderText = "Search by name or barcode...";
            txtSearch.Size = new Size(419, 50);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.White;
            btnAddToCart.BorderColor = Color.Black;
            btnAddToCart.FlatAppearance.BorderSize = 0;
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAddToCart.ForeColor = Color.Black;
            btnAddToCart.HoverBorderColor = Color.Black;
            btnAddToCart.Location = new Point(27, 563);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Padding = new Padding(0, 0, 5, 5);
            btnAddToCart.ShadowColor = Color.Black;
            btnAddToCart.Size = new Size(581, 40);
            btnAddToCart.TabIndex = 3;
            btnAddToCart.Text = "ADD TO CART";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // panelCart
            // 
            panelCart.BackColor = Color.White;
            panelCart.BorderColor = Color.DimGray;
            panelCart.Controls.Add(btnPay);
            panelCart.Controls.Add(btnClearCart);
            panelCart.Controls.Add(btnRemoveFromCart);
            panelCart.Controls.Add(lblTotal);
            panelCart.Controls.Add(label3);
            panelCart.Controls.Add(dgvCart);
            panelCart.Controls.Add(label2);
            panelCart.Location = new Point(630, 12);
            panelCart.Name = "panelCart";
            panelCart.Padding = new Padding(3);
            panelCart.ShadowColor = Color.Black;
            panelCart.Size = new Size(334, 602);
            panelCart.TabIndex = 1;
            // 
            // btnPay
            // 
            btnPay.BackColor = Color.White;
            btnPay.BorderColor = Color.Black;
            btnPay.FlatAppearance.BorderSize = 0;
            btnPay.FlatStyle = FlatStyle.Flat;
            btnPay.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnPay.ForeColor = Color.Black;
            btnPay.HoverBorderColor = Color.Black;
            btnPay.Location = new Point(15, 495);
            btnPay.Name = "btnPay";
            btnPay.Padding = new Padding(0, 0, 5, 5);
            btnPay.ShadowColor = Color.Black;
            btnPay.Size = new Size(304, 45);
            btnPay.TabIndex = 6;
            btnPay.Text = "PAY";
            btnPay.UseVisualStyleBackColor = false;
            btnPay.Click += btnPay_Click;
            // 
            // btnClearCart
            // 
            btnClearCart.BackColor = Color.White;
            btnClearCart.BorderColor = Color.Black;
            btnClearCart.FlatAppearance.BorderSize = 0;
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnClearCart.ForeColor = Color.Black;
            btnClearCart.HoverBorderColor = Color.Black;
            btnClearCart.Location = new Point(175, 370);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.OffsetX = 3;
            btnClearCart.OffsetY = 3;
            btnClearCart.Padding = new Padding(0, 0, 3, 3);
            btnClearCart.ShadowColor = Color.Black;
            btnClearCart.ShadowSize = 3;
            btnClearCart.Size = new Size(144, 35);
            btnClearCart.TabIndex = 5;
            btnClearCart.Text = "CLEAR CART";
            btnClearCart.UseVisualStyleBackColor = false;
            btnClearCart.Click += btnClearCart_Click;
            // 
            // btnRemoveFromCart
            // 
            btnRemoveFromCart.BackColor = Color.White;
            btnRemoveFromCart.BorderColor = Color.Black;
            btnRemoveFromCart.FlatAppearance.BorderSize = 0;
            btnRemoveFromCart.FlatStyle = FlatStyle.Flat;
            btnRemoveFromCart.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnRemoveFromCart.ForeColor = Color.Black;
            btnRemoveFromCart.HoverBorderColor = Color.Black;
            btnRemoveFromCart.Location = new Point(15, 370);
            btnRemoveFromCart.Name = "btnRemoveFromCart";
            btnRemoveFromCart.OffsetX = 3;
            btnRemoveFromCart.OffsetY = 3;
            btnRemoveFromCart.Padding = new Padding(0, 0, 3, 3);
            btnRemoveFromCart.ShadowColor = Color.Black;
            btnRemoveFromCart.ShadowSize = 3;
            btnRemoveFromCart.Size = new Size(144, 35);
            btnRemoveFromCart.TabIndex = 4;
            btnRemoveFromCart.Text = "REMOVE ITEM";
            btnRemoveFromCart.UseVisualStyleBackColor = false;
            btnRemoveFromCart.Click += btnRemoveFromCart_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Black;
            lblTotal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotal.ForeColor = Color.Yellow;
            lblTotal.Location = new Point(188, 429);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(77, 32);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "$0.00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Black;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label3.ForeColor = Color.Yellow;
            label3.Location = new Point(15, 435);
            label3.Name = "label3";
            label3.Size = new Size(158, 25);
            label3.TabIndex = 2;
            label3.Text = "TOTAL AMOUNT";
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(15, 50);
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            dgvCart.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            dgvCart.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 0);
            dgvCart.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(304, 300);
            dgvCart.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label2.Location = new Point(15, 25);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 0;
            label2.Text = "Cart";
            // 
            // panelBarcode
            // 
            panelBarcode.BackColor = Color.White;
            panelBarcode.BorderColor = Color.Black;
            panelBarcode.Controls.Add(label4);
            panelBarcode.Controls.Add(iconPictureBox1);
            panelBarcode.Controls.Add(txtBarcode);
            panelBarcode.Location = new Point(12, 12);
            panelBarcode.Name = "panelBarcode";
            panelBarcode.Padding = new Padding(3);
            panelBarcode.ShadowColor = Color.Black;
            panelBarcode.Size = new Size(612, 64);
            panelBarcode.TabIndex = 2;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.FromArgb(255, 204, 0);
            iconPictureBox1.ForeColor = Color.Black;
            iconPictureBox1.IconChar = IconChar.Barcode;
            iconPictureBox1.IconColor = Color.Black;
            iconPictureBox1.IconFont = IconFont.Auto;
            iconPictureBox1.Location = new Point(15, 15);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(32, 32);
            iconPictureBox1.TabIndex = 2;
            iconPictureBox1.TabStop = false;
            // 
            // txtBarcode
            // 
            txtBarcode.BackColor = Color.White;
            txtBarcode.BorderColor = Color.Black;
            txtBarcode.BorderFocusColor = Color.FromArgb(255, 128, 0);
            txtBarcode.BorderStyle = BorderStyle.None;
            txtBarcode.Font = new Font("Segoe UI", 12F);
            txtBarcode.ForeColor = Color.Black;
            txtBarcode.Location = new Point(175, 15);
            txtBarcode.MinimumSize = new Size(0, 50);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.PlaceholderColor = Color.DarkGray;
            txtBarcode.PlaceholderText = "Scan barcode...";
            txtBarcode.Size = new Size(421, 50);
            txtBarcode.TabIndex = 1;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Black;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Yellow;
            label4.Location = new Point(53, 21);
            label4.Name = "label4";
            label4.Size = new Size(116, 21);
            label4.TabIndex = 0;
            label4.Text = "Scan Barcode:";
            // 
            // POSForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 204, 0);
            ClientSize = new Size(992, 640);
            Controls.Add(panelBarcode);
            Controls.Add(btnAddToCart);
            Controls.Add(panelCart);
            Controls.Add(panelProducts);
            FormBorderStyle = FormBorderStyle.None;
            Name = "POSForm";
            Text = "POS";
            Load += POSForm_Load;
            panelProducts.ResumeLayout(false);
            panelProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panelCart.ResumeLayout(false);
            panelCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            panelBarcode.ResumeLayout(false);
            panelBarcode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private NeoBrutalistPanel panelProducts;
        private NeoBrutalistPanel panelCart;
        private NeoBrutalistPanel panelBarcode;
        private NeoBrutalistTextBox txtSearch;
        private Label label1;
        private DataGridView dgvProducts;
        private Label label2;
        private DataGridView dgvCart;
        private Label lblTotal;
        private Label label3;
        private NeoBrutalistButton btnClearCart;
        private NeoBrutalistButton btnRemoveFromCart;
        private NeoBrutalistButton btnPay;
        private IconPictureBox iconPictureBox1;
        private NeoBrutalistTextBox txtBarcode;
        private NeoBrutalistButton btnAddToCart;
        private NeoBrutalistButton btnCategoryManagement;
        public Label label4;
    }
}
