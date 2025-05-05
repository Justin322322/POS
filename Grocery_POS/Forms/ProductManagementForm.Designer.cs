using Grocery_POS.UI;
using System.Windows.Forms;
using System.Drawing;
using FontAwesome.Sharp;

namespace Grocery_POS.Forms
{
    partial class ProductManagementForm
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
            lblTitle = new Label();
            panelBarcode = new NeoBrutalistPanel();
            txtBarcode = new NeoBrutalistTextBox();
            lblBarcode = new Label();
            iconBarcode = new IconPictureBox();
            panelSearch = new NeoBrutalistPanel();
            txtSearch = new NeoBrutalistTextBox();
            lblSearch = new Label();
            panelProducts = new NeoBrutalistPanel();
            dgvProducts = new DataGridView();
            panelForm = new NeoBrutalistPanel();
            btnDelete = new NeoBrutalistButton();
            btnSave = new NeoBrutalistButton();
            btnNew = new NeoBrutalistButton();
            txtProductId = new NeoBrutalistTextBox();
            txtProductName = new NeoBrutalistTextBox();
            txtPrice = new NeoBrutalistTextBox();
            txtStock = new NeoBrutalistTextBox();
            cmbCategory = new ComboBox();
            lblProductId = new Label();
            lblProductName = new Label();
            lblPrice = new Label();
            lblStock = new Label();
            lblCategory = new Label();
            panelBarcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconBarcode).BeginInit();
            panelSearch.SuspendLayout();
            panelProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panelForm.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(18, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(346, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Product Management";
            // 
            // panelBarcode
            // 
            panelBarcode.BackColor = Color.White;
            panelBarcode.BorderColor = Color.Black;
            panelBarcode.Controls.Add(txtBarcode);
            panelBarcode.Controls.Add(lblBarcode);
            panelBarcode.Controls.Add(iconBarcode);
            panelBarcode.Location = new Point(697, 79);
            panelBarcode.Name = "panelBarcode";
            panelBarcode.Padding = new Padding(10);
            panelBarcode.ShadowColor = Color.Black;
            panelBarcode.Size = new Size(421, 60);
            panelBarcode.TabIndex = 1;
            // 
            // txtBarcode
            // 
            txtBarcode.BackColor = Color.White;
            txtBarcode.BorderColor = Color.Black;
            txtBarcode.BorderFocusColor = Color.FromArgb(255, 204, 0);
            txtBarcode.BorderSize = 2;
            txtBarcode.BorderStyle = BorderStyle.None;
            txtBarcode.Font = new Font("Segoe UI", 10F);
            txtBarcode.ForeColor = Color.Black;
            txtBarcode.Location = new Point(149, 15);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.PlaceholderColor = Color.FromArgb(128, 128, 128);
            txtBarcode.Size = new Size(259, 36);
            txtBarcode.TabIndex = 0;
            // 
            // lblBarcode
            // 
            lblBarcode.AutoSize = true;
            lblBarcode.BackColor = Color.Black;
            lblBarcode.Font = new Font("Segoe UI", 10F);
            lblBarcode.ForeColor = Color.Yellow;
            lblBarcode.Location = new Point(50, 23);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(93, 19);
            lblBarcode.TabIndex = 1;
            lblBarcode.Text = "Scan Barcode:";
            // 
            // iconBarcode
            // 
            iconBarcode.BackColor = Color.White;
            iconBarcode.ForeColor = Color.Black;
            iconBarcode.IconChar = IconChar.Barcode;
            iconBarcode.IconColor = Color.Black;
            iconBarcode.IconFont = IconFont.Auto;
            iconBarcode.IconSize = 24;
            iconBarcode.Location = new Point(15, 18);
            iconBarcode.Name = "iconBarcode";
            iconBarcode.Size = new Size(24, 24);
            iconBarcode.TabIndex = 2;
            iconBarcode.TabStop = false;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.BorderColor = Color.Black;
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Location = new Point(142, 79);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(10);
            panelSearch.ShadowColor = Color.Black;
            panelSearch.Size = new Size(532, 60);
            panelSearch.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BorderColor = Color.Black;
            txtSearch.BorderFocusColor = Color.FromArgb(255, 204, 0);
            txtSearch.BorderSize = 2;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.Black;
            txtSearch.Location = new Point(150, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderColor = Color.FromArgb(128, 128, 128);
            txtSearch.Size = new Size(369, 36);
            txtSearch.TabIndex = 0;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.BackColor = Color.Black;
            lblSearch.Font = new Font("Segoe UI", 10F);
            lblSearch.ForeColor = Color.Yellow;
            lblSearch.Location = new Point(34, 23);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(110, 19);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search Products:";
            // 
            // panelProducts
            // 
            panelProducts.BackColor = Color.White;
            panelProducts.BorderColor = Color.Black;
            panelProducts.Controls.Add(dgvProducts);
            panelProducts.Location = new Point(142, 156);
            panelProducts.Name = "panelProducts";
            panelProducts.Padding = new Padding(10);
            panelProducts.ShadowColor = Color.Black;
            panelProducts.Size = new Size(976, 327);
            panelProducts.TabIndex = 3;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 204, 0);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 204, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(10, 10);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowTemplate.Height = 30;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(956, 307);
            dgvProducts.TabIndex = 0;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.BorderColor = Color.Black;
            panelForm.Controls.Add(btnDelete);
            panelForm.Controls.Add(btnSave);
            panelForm.Controls.Add(btnNew);
            panelForm.Controls.Add(txtProductId);
            panelForm.Controls.Add(txtProductName);
            panelForm.Controls.Add(txtPrice);
            panelForm.Controls.Add(txtStock);
            panelForm.Controls.Add(cmbCategory);
            panelForm.Controls.Add(lblProductId);
            panelForm.Controls.Add(lblProductName);
            panelForm.Controls.Add(lblPrice);
            panelForm.Controls.Add(lblStock);
            panelForm.Controls.Add(lblCategory);
            panelForm.Location = new Point(142, 489);
            panelForm.Name = "panelForm";
            panelForm.Padding = new Padding(20);
            panelForm.ShadowColor = Color.Black;
            panelForm.Size = new Size(976, 253);
            panelForm.TabIndex = 4;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.BorderColor = Color.Black;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnDelete.Location = new Point(387, 169);
            btnDelete.Name = "btnDelete";
            btnDelete.OffsetX = 3;
            btnDelete.OffsetY = 3;
            btnDelete.Padding = new Padding(0, 0, 5, 5);
            btnDelete.ShadowColor = Color.Black;
            btnDelete.ShadowSize = 3;
            btnDelete.Size = new Size(80, 61);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 192, 0);
            btnSave.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnSave.Location = new Point(473, 169);
            btnSave.Name = "btnSave";
            btnSave.OffsetX = 3;
            btnSave.OffsetY = 3;
            btnSave.Padding = new Padding(0, 0, 5, 5);
            btnSave.ShadowColor = Color.Black;
            btnSave.ShadowSize = 3;
            btnSave.Size = new Size(80, 61);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(0, 122, 204);
            btnNew.BorderColor = Color.Black;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnNew.Location = new Point(559, 169);
            btnNew.Name = "btnNew";
            btnNew.OffsetX = 3;
            btnNew.OffsetY = 3;
            btnNew.Padding = new Padding(0, 0, 5, 5);
            btnNew.ShadowColor = Color.Black;
            btnNew.ShadowSize = 3;
            btnNew.Size = new Size(80, 61);
            btnNew.TabIndex = 2;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // txtProductId
            // 
            txtProductId.BackColor = Color.White;
            txtProductId.BorderColor = Color.Black;
            txtProductId.BorderFocusColor = Color.FromArgb(255, 204, 0);
            txtProductId.BorderStyle = BorderStyle.None;
            txtProductId.Font = new Font("Segoe UI", 11F);
            txtProductId.ForeColor = Color.Black;
            txtProductId.Location = new Point(140, 23);
            txtProductId.Name = "txtProductId";
            txtProductId.PlaceholderColor = Color.FromArgb(128, 128, 128);
            txtProductId.ReadOnly = true;
            txtProductId.Size = new Size(200, 37);
            txtProductId.TabIndex = 3;
            // 
            // txtProductName
            // 
            txtProductName.BackColor = Color.White;
            txtProductName.BorderColor = Color.Black;
            txtProductName.BorderFocusColor = Color.FromArgb(255, 204, 0);
            txtProductName.BorderStyle = BorderStyle.None;
            txtProductName.Font = new Font("Segoe UI", 11F);
            txtProductName.ForeColor = Color.Black;
            txtProductName.Location = new Point(140, 109);
            txtProductName.Name = "txtProductName";
            txtProductName.PlaceholderColor = Color.FromArgb(128, 128, 128);
            txtProductName.Size = new Size(170, 37);
            txtProductName.TabIndex = 4;
            // 
            // txtPrice
            // 
            txtPrice.BackColor = Color.White;
            txtPrice.BorderColor = Color.Black;
            txtPrice.BorderFocusColor = Color.FromArgb(255, 204, 0);
            txtPrice.BorderStyle = BorderStyle.None;
            txtPrice.Font = new Font("Segoe UI", 11F);
            txtPrice.ForeColor = Color.Black;
            txtPrice.Location = new Point(140, 203);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderColor = Color.FromArgb(128, 128, 128);
            txtPrice.Size = new Size(120, 37);
            txtPrice.TabIndex = 5;
            // 
            // txtStock
            // 
            txtStock.BackColor = Color.White;
            txtStock.BorderColor = Color.Black;
            txtStock.BorderFocusColor = Color.FromArgb(255, 204, 0);
            txtStock.BorderStyle = BorderStyle.None;
            txtStock.Font = new Font("Segoe UI", 11F);
            txtStock.ForeColor = Color.Black;
            txtStock.Location = new Point(140, 160);
            txtStock.Name = "txtStock";
            txtStock.PlaceholderColor = Color.FromArgb(128, 128, 128);
            txtStock.Size = new Size(120, 37);
            txtStock.TabIndex = 6;
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.White;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 11F);
            cmbCategory.ForeColor = Color.Black;
            cmbCategory.Location = new Point(140, 75);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(200, 28);
            cmbCategory.TabIndex = 7;
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.BackColor = Color.Black;
            lblProductId.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblProductId.ForeColor = Color.Yellow;
            lblProductId.Location = new Point(20, 30);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(88, 20);
            lblProductId.TabIndex = 8;
            lblProductId.Text = "Product ID:";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.BackColor = Color.Black;
            lblProductName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblProductName.ForeColor = Color.Yellow;
            lblProductName.Location = new Point(20, 121);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(114, 20);
            lblProductName.TabIndex = 9;
            lblProductName.Text = "Product Name:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.BackColor = Color.Black;
            lblPrice.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPrice.ForeColor = Color.Yellow;
            lblPrice.Location = new Point(23, 216);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(47, 20);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "Price:";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.BackColor = Color.Black;
            lblStock.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStock.ForeColor = Color.Yellow;
            lblStock.Location = new Point(23, 168);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(52, 20);
            lblStock.TabIndex = 11;
            lblStock.Text = "Stock:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.BackColor = Color.Black;
            lblCategory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCategory.ForeColor = Color.Yellow;
            lblCategory.Location = new Point(20, 75);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(77, 20);
            lblCategory.TabIndex = 12;
            lblCategory.Text = "Category:";
            // 
            // ProductManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 204, 0);
            ClientSize = new Size(1286, 751);
            Controls.Add(lblTitle);
            Controls.Add(panelBarcode);
            Controls.Add(panelSearch);
            Controls.Add(panelProducts);
            Controls.Add(panelForm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductManagementForm";
            Padding = new Padding(15);
            Load += ProductManagementForm_Load;
            panelBarcode.ResumeLayout(false);
            panelBarcode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconBarcode).EndInit();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private NeoBrutalistPanel panelBarcode;
        private NeoBrutalistTextBox txtBarcode;
        private Label lblBarcode;
        private IconPictureBox iconBarcode;
        private NeoBrutalistPanel panelSearch;
        private NeoBrutalistTextBox txtSearch;
        private Label lblSearch;
        private NeoBrutalistPanel panelProducts;
        private DataGridView dgvProducts;
        private NeoBrutalistPanel panelForm;
        private NeoBrutalistButton btnDelete;
        private NeoBrutalistButton btnSave;
        private NeoBrutalistButton btnNew;
        private NeoBrutalistTextBox txtProductId;
        private Label lblProductId;
        private NeoBrutalistTextBox txtProductName;
        private NeoBrutalistTextBox txtPrice;
        private NeoBrutalistTextBox txtStock;
        private ComboBox cmbCategory;
        private Label lblProductName;
        private Label lblPrice;
        private Label lblStock;
        private Label lblCategory;
    }
}
