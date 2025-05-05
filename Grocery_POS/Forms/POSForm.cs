using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grocery_POS.Models;
using Grocery_POS.Services;
using Grocery_POS.UI;

namespace Grocery_POS.Forms
{
    public partial class POSForm : Form
    {
        private readonly ProductService productService;
        private readonly TransactionService transactionService;
        private readonly ReceiptService receiptService;
        private readonly User currentUser;
        private List<TransactionItem> cartItems;
        private decimal totalAmount = 0;

        public POSForm(User user)
        {
            InitializeComponent();
            productService = new ProductService();
            transactionService = new TransactionService();
            receiptService = new ReceiptService();
            currentUser = user;
            cartItems = new List<TransactionItem>();

            // Force colors for all controls
            this.BackColor = Color.FromArgb(255, 204, 0); // Yellow background for form

            // Set panel colors
            panelProducts.BackColor = Color.White;
            panelCart.BackColor = Color.White;
            panelBarcode.BackColor = Color.White;

            // Set button colors
            btnAddToCart.BackColor = Color.White;
            btnAddToCart.ForeColor = Color.Black;

            btnRemoveFromCart.BackColor = Color.White;
            btnRemoveFromCart.ForeColor = Color.Black;

            btnClearCart.BackColor = Color.White;
            btnClearCart.ForeColor = Color.Black;

            btnPay.BackColor = Color.White;
            btnPay.ForeColor = Color.Black;

            // Set label colors
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            lblTotal.ForeColor = Color.Black;

            // Set textbox colors
            txtSearch.ForeColor = Color.Black;
            txtSearch.BackColor = Color.White;
            txtBarcode.ForeColor = Color.Black;
            txtBarcode.BackColor = Color.White;

            // Set DataGridView colors
            dgvProducts.ForeColor = Color.Black;
            dgvProducts.DefaultCellStyle.ForeColor = Color.Black;
            dgvCart.ForeColor = Color.Black;
            dgvCart.DefaultCellStyle.ForeColor = Color.Black;

            // Set up DataGridView
            SetupDataGridView();

            btnCategoryManagement.Click += btnCategoryManagement_Click;
        }

        private void SetupDataGridView()
        {
            // Configure cart DataGridView
            dgvCart.AutoGenerateColumns = false;
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AllowUserToResizeRows = false;
            dgvCart.MultiSelect = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCart.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCart.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 204, 0);
            dgvCart.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCart.ColumnHeadersHeight = 40;
            dgvCart.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvCart.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 0);
            dgvCart.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCart.RowTemplate.Height = 30;

            // Add columns
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Id";
            idColumn.HeaderText = "ID";
            idColumn.DataPropertyName = "ProductId";
            idColumn.Width = 50;
            dgvCart.Columns.Add(idColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.HeaderText = "Product";
            nameColumn.DataPropertyName = "ProductName";
            nameColumn.Width = 200;
            dgvCart.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.Name = "Price";
            priceColumn.HeaderText = "Price";
            priceColumn.DataPropertyName = "Price";
            priceColumn.Width = 100;
            priceColumn.DefaultCellStyle.Format = "₱#,##0.00";
            dgvCart.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.Name = "Quantity";
            quantityColumn.HeaderText = "Qty";
            quantityColumn.DataPropertyName = "Quantity";
            quantityColumn.Width = 50;
            dgvCart.Columns.Add(quantityColumn);

            DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn();
            subtotalColumn.Name = "Subtotal";
            subtotalColumn.HeaderText = "Subtotal";
            subtotalColumn.DataPropertyName = "Subtotal";
            subtotalColumn.Width = 100;
            subtotalColumn.DefaultCellStyle.Format = "₱#,##0.00";
            dgvCart.Columns.Add(subtotalColumn);

            // Configure product search DataGridView
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.MultiSelect = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 204, 0);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvProducts.ColumnHeadersHeight = 40;
            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 0);
            dgvProducts.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvProducts.RowTemplate.Height = 30;
            dgvProducts.CellDoubleClick += dgvProducts_CellDoubleClick;

            // Add columns
            DataGridViewTextBoxColumn prodIdColumn = new DataGridViewTextBoxColumn();
            prodIdColumn.Name = "Id";
            prodIdColumn.HeaderText = "ID";
            prodIdColumn.DataPropertyName = "Id";
            prodIdColumn.Width = 50;
            dgvProducts.Columns.Add(prodIdColumn);

            DataGridViewTextBoxColumn prodNameColumn = new DataGridViewTextBoxColumn();
            prodNameColumn.Name = "Name";
            prodNameColumn.HeaderText = "Product";
            prodNameColumn.DataPropertyName = "Name";
            prodNameColumn.Width = 200;
            dgvProducts.Columns.Add(prodNameColumn);

            DataGridViewTextBoxColumn prodPriceColumn = new DataGridViewTextBoxColumn();
            prodPriceColumn.Name = "Price";
            prodPriceColumn.HeaderText = "Price";
            prodPriceColumn.DataPropertyName = "Price";
            prodPriceColumn.Width = 100;
            prodPriceColumn.DefaultCellStyle.Format = "₱#,##0.00";
            dgvProducts.Columns.Add(prodPriceColumn);

            DataGridViewTextBoxColumn stockColumn = new DataGridViewTextBoxColumn();
            stockColumn.Name = "Stock";
            stockColumn.HeaderText = "Stock";
            stockColumn.DataPropertyName = "Stock";
            stockColumn.Width = 80;
            dgvProducts.Columns.Add(stockColumn);

            DataGridViewTextBoxColumn barcodeColumn = new DataGridViewTextBoxColumn();
            barcodeColumn.Name = "Barcode";
            barcodeColumn.HeaderText = "Barcode";
            barcodeColumn.DataPropertyName = "Barcode";
            barcodeColumn.Width = 120;
            dgvProducts.Columns.Add(barcodeColumn);
        }

        private void POSForm_Load(object sender, EventArgs e)
        {
            // Load products
            LoadProducts();
            UpdateTotalAmount();
        }

        private void LoadProducts()
        {
            dgvProducts.DataSource = productService.GetAllProducts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadProducts();
            }
            else
            {
                dgvProducts.DataSource = productService.SearchProducts(txtSearch.Text);
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["Id"].Value);
                Product? product = productService.GetProductById(productId);

                if (product != null)
                {
                    // Check if product is already in cart
                    TransactionItem? existingItem = cartItems.FirstOrDefault(item => item.ProductId == productId);

                    if (existingItem != null)
                    {
                        // Increment quantity
                        existingItem.Quantity++;
                        existingItem.Subtotal = existingItem.Price * existingItem.Quantity;
                    }
                    else
                    {
                        // Add new item
                        TransactionItem item = new TransactionItem
                        {
                            ProductId = product.Id,
                            ProductName = product.Name,
                            Price = product.Price,
                            Quantity = 1,
                            Subtotal = product.Price
                        };

                        cartItems.Add(item);
                    }

                    // Refresh cart
                    RefreshCart();
                    UpdateTotalAmount();
                }
            }
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(dgvCart.SelectedRows[0].Cells["Id"].Value);
                TransactionItem? item = cartItems.FirstOrDefault(i => i.ProductId == productId);

                if (item != null)
                {
                    cartItems.Remove(item);
                    RefreshCart();
                    UpdateTotalAmount();
                }
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            cartItems.Clear();
            RefreshCart();
            UpdateTotalAmount();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (cartItems.Count == 0)
                {
                    MessageBox.Show("Cart is empty. Please add items to cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verify stock levels before proceeding
                foreach (var item in cartItems)
                {
                    Product? product = productService.GetProductById(item.ProductId);
                    if (product == null || product.Stock < item.Quantity)
                    {
                        MessageBox.Show($"Insufficient stock for product: {item.ProductName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Show payment form
                using (PaymentForm paymentForm = new PaymentForm(totalAmount))
                {
                    if (paymentForm.ShowDialog() == DialogResult.OK)
                    {
                        // Disable the Pay button to prevent multiple clicks
                        btnPay.Enabled = false;

                        // Create transaction
                        Transaction transaction = new Transaction
                        {
                            UserId = currentUser.Id,
                            TransactionDate = DateTime.Now,
                            TotalAmount = totalAmount,
                            AmountPaid = paymentForm.AmountPaid,
                            Change = paymentForm.Change,
                            PaymentMethod = paymentForm.PaymentMethod,
                            Items = new List<TransactionItem>(cartItems) // Create a new list to avoid reference issues
                        };

                        // Save transaction first (most important operation)
                        bool saveSuccess = transactionService.SaveTransaction(transaction);

                        if (saveSuccess)
                        {
                            // Show receipt preview after successful save
                            using (ReceiptPreviewForm previewForm = new ReceiptPreviewForm(transaction, currentUser.Username))
                            {
                                previewForm.ShowDialog();
                            }

                            MessageBox.Show($"Transaction completed successfully!\n\nTotal: ₱{totalAmount:N2}\nPaid: ₱{paymentForm.AmountPaid:N2}\nChange: ₱{paymentForm.Change:N2}",
                                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear cart and refresh UI
                            cartItems.Clear();
                            RefreshCart();
                            UpdateTotalAmount();

                            // Reload products in the background to avoid UI freeze
                            Task.Run(() =>
                            {
                                // Use Invoke to update UI from background thread
                                this.Invoke((MethodInvoker)delegate
                                {
                                    LoadProducts(); // Reload products to update stock
                                    txtBarcode.Clear();
                                    txtBarcode.Focus();
                                    btnPay.Enabled = true; // Re-enable the Pay button
                                });
                            });
                        }
                        else
                        {
                            MessageBox.Show("Failed to complete transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnPay.Enabled = true; // Re-enable the Pay button
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCart()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = cartItems;
        }

        private void UpdateTotalAmount()
        {
            try
            {
                totalAmount = cartItems.Sum(item => item.Subtotal);
                lblTotal.Text = "₱" + totalAmount.ToString("#,##0.00");
            }
            catch (Exception)
            {
                totalAmount = 0;
                lblTotal.Text = "₱0.00";
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtBarcode.Text.Trim();
                if (!string.IsNullOrEmpty(barcode))
                {
                    Product? product = productService.GetProductByBarcode(barcode);
                    if (product != null)
                    {
                        // Check if product is already in cart
                        TransactionItem? existingItem = cartItems.FirstOrDefault(item => item.ProductId == product.Id);

                        if (existingItem != null)
                        {
                            // Increment quantity
                            existingItem.Quantity++;
                            existingItem.Subtotal = existingItem.Price * existingItem.Quantity;
                        }
                        else
                        {
                            // Add new item
                            TransactionItem item = new TransactionItem
                            {
                                ProductId = product.Id,
                                ProductName = product.Name,
                                Price = product.Price,
                                Quantity = 1,
                                Subtotal = product.Price
                            };

                            cartItems.Add(item);
                        }

                        // Refresh cart
                        RefreshCart();
                        UpdateTotalAmount();
                        txtBarcode.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCategoryManagement_Click(object? sender, EventArgs e)
        {
            CategoryManagementForm categoryManagementForm = new CategoryManagementForm();
            categoryManagementForm.ShowDialog();
            LoadProducts(); // Refresh products after category management
        }

        private void dgvProducts_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["Id"].Value);
                string? nameValue = dgvProducts.Rows[e.RowIndex].Cells["Name"].Value?.ToString();
                if (string.IsNullOrEmpty(nameValue))
                {
                    MessageBox.Show("Invalid product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal price = Convert.ToDecimal(dgvProducts.Rows[e.RowIndex].Cells["Price"].Value);
                int stock = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["Stock"].Value);

                if (stock <= 0)
                {
                    MessageBox.Show("This product is out of stock.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if item already exists in cart
                var existingItem = cartItems.FirstOrDefault(item => item.ProductId == productId);
                if (existingItem != null)
                {
                    if (existingItem.Quantity >= stock)
                    {
                        MessageBox.Show("Cannot add more items than available in stock.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    existingItem.Quantity++;
                    existingItem.Subtotal = existingItem.Price * existingItem.Quantity;
                }
                else
                {
                    var newItem = new TransactionItem
                    {
                        ProductId = productId,
                        ProductName = nameValue,
                        Price = price,
                        Quantity = 1,
                        Subtotal = price
                    };
                    cartItems.Add(newItem);
                }

                RefreshCart();
                UpdateTotalAmount();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
