using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery_POS.Models;
using MySql.Data.MySqlClient;

namespace Grocery_POS.Services
{
    public class CategoryService
    {
        private readonly DatabaseConnection dbConnection;

        public CategoryService()
        {
            dbConnection = DatabaseConnection.Instance;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM categories ORDER BY name ASC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new Category
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Name = reader["name"].ToString() ?? string.Empty,
                                    Description = reader["description"].ToString() ?? string.Empty,
                                    CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                    UpdatedAt = Convert.ToDateTime(reader["updated_at"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all categories: {ex.Message}");
            }
            return categories;
        }

        public Category? GetCategoryById(int id)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM categories WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Category
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Name = reader["name"].ToString() ?? string.Empty,
                                    Description = reader["description"].ToString() ?? string.Empty,
                                    CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                    UpdatedAt = Convert.ToDateTime(reader["updated_at"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting category by id: {ex.Message}");
            }
            return null;
        }

        public bool AddCategory(Category category)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO categories (name, description, created_at, updated_at)
                        VALUES (@name, @description, NOW(), NOW())";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", category.Name);
                        cmd.Parameters.AddWithValue("@description", category.Description);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding category: {ex.Message}");
                return false;
            }
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE categories
                        SET name = @name, description = @description, updated_at = NOW()
                        WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", category.Id);
                        cmd.Parameters.AddWithValue("@name", category.Name);
                        cmd.Parameters.AddWithValue("@description", category.Description);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating category: {ex.Message}");
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    // Check if there are any products using this category (for informational purposes only)
                    string checkQuery = "SELECT COUNT(*) FROM products WHERE category_id = @id";
                    int productCount = 0;
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@id", id);
                        productCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                    }

                    // Proceed with deletion - the ON DELETE SET NULL constraint will set product category_id to NULL
                    string deleteQuery = "DELETE FROM categories WHERE id = @id";
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", id);
                        int result = deleteCmd.ExecuteNonQuery();

                        if (result > 0 && productCount > 0)
                        {
                            // Log that products were updated
                            Console.WriteLine($"Deleted category ID {id}. {productCount} products had their category set to NULL.");
                        }

                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting category: {ex.Message}");
                return false;
            }
        }
    }
}
