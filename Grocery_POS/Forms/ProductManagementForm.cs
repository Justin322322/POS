using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Grocery_POS.Models;
using Grocery_POS.Services;
using Grocery_POS.UI;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace Grocery_POS.Forms
{
    public partial class ProductManagementForm : Form
    {
        private readonly ProductService productService;
        private readonly CategoryService categoryService;
        private readonly DatabaseConnection _db;
        private Product currentProduct;
        private bool isNewProduct = false;

        public ProductManagementForm()
        {
            InitializeComponent();
            productService = new ProductService();
            categoryService = new CategoryService();
            _db = DatabaseConnection.Instance;
            currentProduct = new Product();

            // Set up the DataGridView styling
            SetupDataGridView();

            // Ensure the form panel has the correct background color
            panelForm.BackColor = Color.White;

            // Load data
            LoadCategories();
            LoadProducts();
        }

        private void SetupDataGridView()
        {
            // Configure DataGridView appearance
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 204, 0);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 0);
            dgvProducts.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvProducts.RowTemplate.Height = 30;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Create columns
            if (dgvProducts.Columns.Count == 0)
            {
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Id",
                    HeaderText = "Id",
                    DataPropertyName = "Id",
                    Width = 50
                });

                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Name",
                    HeaderText = "Name",
                    DataPropertyName = "Name",
                    Width = 150
                });

                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CategoryId",
                    HeaderText = "Category ID",
                    DataPropertyName = "CategoryId",
                    Width = 80,
                    Visible = false // Hide the ID column
                });

                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CategoryName",
                    HeaderText = "Category",
                    DataPropertyName = "CategoryName",
                    Width = 120
                });

                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Price",
                    HeaderText = "Price",
                    DataPropertyName = "Price",
                    Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "₱0.00",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                });

                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Stock",
                    HeaderText = "Stock",
                    DataPropertyName = "Stock",
                    Width = 80
                });

                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Barcode",
                    HeaderText = "Barcode",
                    DataPropertyName = "Barcode",
                    Width = 100
                });

                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CreatedAt",
                    HeaderText = "CreatedAt",
                    DataPropertyName = "CreatedAt",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd/MM/yyyy HH:mm"
                    }
                });

                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "UpdatedAt",
                    HeaderText = "UpdatedAt",
                    DataPropertyName = "UpdatedAt",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd/MM/yyyy HH:mm"
                    }
                });
            }
        }

        private void ProductManagementForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
            ClearFields();

            // Set up event handlers
            txtSearch.TextChanged += TxtSearch_TextChanged;
            txtBarcode.KeyDown += TxtBarcode_KeyDown;
            dgvProducts.CellClick += DgvProducts_CellClick;

            // Ensure proper styling
            EnsureProperStyling();
        }

        private void EnsureProperStyling()
        {
            // Ensure the form panel has the correct background color
            panelForm.BackColor = Color.White;

            // Ensure all labels in the form panel have proper styling
            foreach (Control control in panelForm.Controls)
            {
                if (control is Label label)
                {
                    label.BackColor = Color.White;
                    label.ForeColor = Color.Black;
                }
            }

            // Ensure the category dropdown has proper styling
            cmbCategory.BackColor = Color.White;
            cmbCategory.ForeColor = Color.Black;
        }

        private void LoadProducts()
        {
            try
            {
                // Get all products
                var products = productService.GetAllProducts();

                // Get all categories for lookup
                var categories = categoryService.GetAllCategories();
                var categoryDict = categories.ToDictionary(c => c.Id, c => c.Name);

                // Create a view with category names
                var productView = products.Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.CategoryId,
                    CategoryName = categoryDict.ContainsKey(p.CategoryId) ? categoryDict[p.CategoryId] : "Unknown",
                    p.Price,
                    p.Stock,
                    p.Barcode,
                    p.CreatedAt,
                    p.UpdatedAt
                }).ToList();

                dgvProducts.DataSource = productView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                // Load categories for the combo box
                var categories = categoryService.GetAllCategories();
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtProductId.Texts = "";
            txtProductName.Texts = "";
            txtPrice.Texts = "0.00";
            txtStock.Texts = "0";
            txtBarcode.Texts = "";
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;

            isNewProduct = true;
            currentProduct = new Product();
            btnDelete.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Texts))
            {
                MessageBox.Show("Product name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return;
            }

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }

            // Parse price and stock
            if (!decimal.TryParse(txtPrice.Texts, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price) || price < 0)
            {
                MessageBox.Show("Invalid price format. Please enter a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            if (!int.TryParse(txtStock.Texts, out int stock) || stock < 0)
            {
                MessageBox.Show("Invalid stock format. Please enter a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return;
            }

            try
            {
                // Create a new product object if adding a new product
                if (isNewProduct)
                {
                    currentProduct = new Product
                    {
                        Name = txtProductName.Texts.Trim(),
                        CategoryId = (int)cmbCategory.SelectedValue,
                        Price = price,
                        Stock = stock,
                        Barcode = txtBarcode.Texts.Trim(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                }
                else
                {
                    // Update existing product
                    currentProduct.Name = txtProductName.Texts.Trim();
                    currentProduct.CategoryId = (int)cmbCategory.SelectedValue;
                    currentProduct.Price = price;
                    currentProduct.Stock = stock;
                    currentProduct.Barcode = txtBarcode.Texts.Trim();
                    currentProduct.UpdatedAt = DateTime.Now;
                }

                bool success;
                if (isNewProduct)
                {
                    success = productService.AddProduct(currentProduct);
                    if (success)
                        MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    success = productService.UpdateProduct(currentProduct);
                    if (success)
                        MessageBox.Show("Product updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (success)
                {
                    LoadProducts();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to save product. Please check your database connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentProduct.Id <= 0)
            {
                MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = productService.DeleteProduct(currentProduct.Id);
                    if (success)
                    {
                        MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProducts();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete product. The product may be referenced in transactions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["Id"].Value);
                    var product = productService.GetProductById(productId);
                    currentProduct = product ?? new Product();

                    if (currentProduct != null && currentProduct.Id > 0)
                    {
                        isNewProduct = false;
                        txtProductId.Texts = currentProduct.Id.ToString();
                        txtProductName.Texts = currentProduct.Name;
                        txtPrice.Texts = currentProduct.Price.ToString("F2", CultureInfo.InvariantCulture);
                        txtStock.Texts = currentProduct.Stock.ToString();
                        txtBarcode.Texts = currentProduct.Barcode;

                        // Find and select the category
                        for (int i = 0; i < cmbCategory.Items.Count; i++)
                        {
                            var category = (Category)cmbCategory.Items[i];
                            if (category.Id == currentProduct.CategoryId)
                            {
                                cmbCategory.SelectedIndex = i;
                                break;
                            }
                        }

                        btnDelete.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Texts))
                {
                    LoadProducts();
                }
                else
                {
                    // Get search results
                    var products = productService.SearchProducts(txtSearch.Texts);

                    // Get all categories for lookup
                    var categories = categoryService.GetAllCategories();
                    var categoryDict = categories.ToDictionary(c => c.Id, c => c.Name);

                    // Create a view with category names
                    var productView = products.Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.CategoryId,
                        CategoryName = categoryDict.ContainsKey(p.CategoryId) ? categoryDict[p.CategoryId] : "Unknown",
                        p.Price,
                        p.Stock,
                        p.Barcode,
                        p.CreatedAt,
                        p.UpdatedAt
                    }).ToList();

                    dgvProducts.DataSource = productView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (!string.IsNullOrWhiteSpace(txtBarcode.Texts))
                {
                    try
                    {
                        // First try to get product by exact barcode match
                        Product? product = productService.GetProductByBarcode(txtBarcode.Texts.Trim());

                        if (product != null && product.Id > 0)
                        {
                            currentProduct = product;
                            isNewProduct = false;
                            txtProductId.Texts = currentProduct.Id.ToString();
                            txtProductName.Texts = currentProduct.Name;
                            txtPrice.Texts = currentProduct.Price.ToString("F2", CultureInfo.InvariantCulture);
                            txtStock.Texts = currentProduct.Stock.ToString();

                            // Find and select the category
                            for (int i = 0; i < cmbCategory.Items.Count; i++)
                            {
                                var category = (Category)cmbCategory.Items[i];
                                if (category.Id == currentProduct.CategoryId)
                                {
                                    cmbCategory.SelectedIndex = i;
                                    break;
                                }
                            }

                            btnDelete.Enabled = true;
                        }
                        else
                        {
                            // If no exact match, try search
                            var products = productService.SearchProducts(txtBarcode.Texts.Trim());
                            if (products.Count > 0)
                            {
                                currentProduct = products[0];
                                isNewProduct = false;
                                txtProductId.Texts = currentProduct.Id.ToString();
                                txtProductName.Texts = currentProduct.Name;
                                txtPrice.Texts = currentProduct.Price.ToString("F2", CultureInfo.InvariantCulture);
                                txtStock.Texts = currentProduct.Stock.ToString();

                                // Find and select the category
                                for (int i = 0; i < cmbCategory.Items.Count; i++)
                                {
                                    var category = (Category)cmbCategory.Items[i];
                                    if (category.Id == currentProduct.CategoryId)
                                    {
                                        cmbCategory.SelectedIndex = i;
                                        break;
                                    }
                                }

                                btnDelete.Enabled = true;
                            }
                            else
                            {
                                // No product found with this barcode, prepare for new product
                                ClearFields();
                                txtBarcode.Texts = txtBarcode.Texts.Trim(); // Keep the scanned barcode
                                txtProductName.Focus();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error searching for product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
