using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery_POS.Models;
using MySql.Data.MySqlClient;

namespace Grocery_POS.Services
{
    public class ProductService
    {
        private readonly DatabaseConnection dbConnection;

        public ProductService()
        {
            dbConnection = DatabaseConnection.Instance;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM products ORDER BY name ASC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Product
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Name = reader["name"].ToString() ?? string.Empty,
                                    CategoryId = Convert.ToInt32(reader["category_id"]),
                                    Price = Convert.ToDecimal(reader["price"]),
                                    Stock = Convert.ToInt32(reader["stock"]),
                                    Barcode = reader["barcode"].ToString() ?? string.Empty,
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
                Console.WriteLine($"Error getting all products: {ex.Message}");
            }
            return products;
        }

        public Product? GetProductById(int id)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM products WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Product
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Name = reader["name"].ToString() ?? string.Empty,
                                    CategoryId = Convert.ToInt32(reader["category_id"]),
                                    Price = Convert.ToDecimal(reader["price"]),
                                    Stock = Convert.ToInt32(reader["stock"]),
                                    Barcode = reader["barcode"].ToString() ?? string.Empty,
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
                Console.WriteLine($"Error getting product by id: {ex.Message}");
            }
            return null;
        }

        public Product? GetProductByBarcode(string barcode)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM products WHERE barcode = @barcode";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@barcode", barcode);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Product
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Name = reader["name"].ToString() ?? string.Empty,
                                    CategoryId = Convert.ToInt32(reader["category_id"]),
                                    Price = Convert.ToDecimal(reader["price"]),
                                    Stock = Convert.ToInt32(reader["stock"]),
                                    Barcode = reader["barcode"].ToString() ?? string.Empty,
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
                Console.WriteLine($"Error getting product by barcode: {ex.Message}");
            }
            return null;
        }

        public List<Product> SearchProducts(string searchTerm)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM products WHERE name LIKE @searchTerm OR barcode LIKE @searchTerm ORDER BY name ASC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Product
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Name = reader["name"].ToString() ?? string.Empty,
                                    CategoryId = Convert.ToInt32(reader["category_id"]),
                                    Price = Convert.ToDecimal(reader["price"]),
                                    Stock = Convert.ToInt32(reader["stock"]),
                                    Barcode = reader["barcode"].ToString() ?? string.Empty,
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
                Console.WriteLine($"Error searching products: {ex.Message}");
            }
            return products;
        }

        public bool AddProduct(Product product)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO products (name, category_id, price, stock, barcode, created_at, updated_at)
                        VALUES (@name, @categoryId, @price, @stock, @barcode, NOW(), NOW())";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", product.Name);
                        cmd.Parameters.AddWithValue("@categoryId", product.CategoryId);
                        cmd.Parameters.AddWithValue("@price", product.Price);
                        cmd.Parameters.AddWithValue("@stock", product.Stock);
                        cmd.Parameters.AddWithValue("@barcode", product.Barcode);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE products
                        SET name = @name, category_id = @categoryId, price = @price, stock = @stock,
                            barcode = @barcode, updated_at = NOW()
                        WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", product.Id);
                        cmd.Parameters.AddWithValue("@name", product.Name);
                        cmd.Parameters.AddWithValue("@categoryId", product.CategoryId);
                        cmd.Parameters.AddWithValue("@price", product.Price);
                        cmd.Parameters.AddWithValue("@stock", product.Stock);
                        cmd.Parameters.AddWithValue("@barcode", product.Barcode);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM products WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
                return false;
            }
        }

        public bool UpdateStock(int productId, int newStock)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE products
                        SET stock = @stock, updated_at = NOW()
                        WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", productId);
                        cmd.Parameters.AddWithValue("@stock", newStock);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product stock: {ex.Message}");
                return false;
            }
        }

        public bool DecrementStock(int productId, int quantity = 1)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    // First check if there's enough stock
                    string checkQuery = "SELECT stock FROM products WHERE id = @id";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@id", productId);
                        object result = checkCmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            int currentStock = Convert.ToInt32(result);
                            if (currentStock < quantity)
                            {
                                // Not enough stock
                                return false;
                            }
                        }
                        else
                        {
                            // Product not found
                            return false;
                        }
                    }

                    // Update the stock
                    string updateQuery = @"
                        UPDATE products
                        SET stock = stock - @quantity, updated_at = NOW()
                        WHERE id = @id AND stock >= @quantity";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@id", productId);
                        updateCmd.Parameters.AddWithValue("@quantity", quantity);
                        return updateCmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error decrementing product stock: {ex.Message}");
                return false;
            }
        }
    }
}
