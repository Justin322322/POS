using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Grocery_POS.Services;

namespace Grocery_POS.Forms
{
    public partial class CategoryManagementForm : Form
    {
        private readonly DatabaseConnection _db;
        private readonly CategoryService categoryService;
        private int? selectedCategoryId;

        public CategoryManagementForm()
        {
            InitializeComponent();
            _db = DatabaseConnection.Instance;
            categoryService = new CategoryService();
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id, name, description FROM categories";
                    using (var adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvCategories.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO categories (name, description) VALUES (@name, @description)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtCategoryName.Text);
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!selectedCategoryId.HasValue)
            {
                MessageBox.Show("Please select a category to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE categories SET name = @name, description = @description WHERE id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtCategoryName.Text);
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@id", selectedCategoryId.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!selectedCategoryId.HasValue)
            {
                MessageBox.Show("Please select a category to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if there are products using this category
            int productCount = 0;
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM products WHERE category_id = @id";
                using (var cmd = new MySqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", selectedCategoryId.Value);
                    productCount = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            string confirmMessage = "Are you sure you want to delete this category?";
            if (productCount > 0)
            {
                confirmMessage = $"This category is used by {productCount} product(s). If you delete it, these products will have no category. Are you sure you want to continue?";
            }

            if (MessageBox.Show(confirmMessage, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                bool success = categoryService.DeleteCategory(selectedCategoryId.Value);
                if (success)
                {
                    string message = "Category deleted successfully!";
                    if (productCount > 0)
                    {
                        message = $"Category deleted successfully! {productCount} product(s) now have no category.";
                    }
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Failed to delete category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                selectedCategoryId = Convert.ToInt32(row.Cells["id"].Value);
                txtCategoryName.Text = row.Cells["name"].Value.ToString();
                txtDescription.Text = row.Cells["description"].Value?.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtCategoryName.Clear();
            txtDescription.Clear();
            selectedCategoryId = null;
        }

        private void CategoryManagementForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }
    }
}