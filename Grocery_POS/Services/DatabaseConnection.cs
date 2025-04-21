using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Grocery_POS.Services
{
    public class DatabaseConnection
    {
        // Default connection string - adjust as needed for your MySQL setup
        private static string connectionString = "Server=localhost;Database=grocery_pos;Uid=root;Pwd=;Port=3306;SslMode=none;AllowPublicKeyRetrieval=true;";
        private static DatabaseConnection? instance;

        private DatabaseConnection() { }

        public static DatabaseConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseConnection();
                }
                return instance;
            }
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public void SetConnectionString(string server, string database, string uid, string password)
        {
            connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};";
        }

        // Method to initialize the database and tables if they don't exist
        public bool InitializeDatabase()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    // Test connection first
                    try
                    {
                        conn.Open();
                        Console.WriteLine("MySQL connection successful!");
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine($"MySQL Connection Error: {ex.Message}");
                        return false;
                    }

                    // Create database if it doesn't exist
                    string createDbQuery = "CREATE DATABASE IF NOT EXISTS grocery_pos;";
                    using (MySqlCommand cmd = new MySqlCommand(createDbQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Use the database
                    string useDbQuery = "USE grocery_pos;";
                    using (MySqlCommand cmd = new MySqlCommand(useDbQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create Categories table
                    string createCategoriesTable = @"
                        CREATE TABLE IF NOT EXISTS categories (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            name VARCHAR(100) NOT NULL,
                            description TEXT,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        );";
                    using (MySqlCommand cmd = new MySqlCommand(createCategoriesTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create Products table
                    string createProductsTable = @"
                        CREATE TABLE IF NOT EXISTS products (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            name VARCHAR(100) NOT NULL,
                            category_id INT,
                            price DECIMAL(10,2) NOT NULL,
                            stock INT NOT NULL DEFAULT 0,
                            barcode VARCHAR(50),
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                            FOREIGN KEY (category_id) REFERENCES categories(id)
                        );";
                    using (MySqlCommand cmd = new MySqlCommand(createProductsTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create Users table
                    string createUsersTable = @"
                        CREATE TABLE IF NOT EXISTS users (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            username VARCHAR(50) NOT NULL UNIQUE,
                            password VARCHAR(255) NOT NULL,
                            full_name VARCHAR(100) NOT NULL,
                            role VARCHAR(20) NOT NULL DEFAULT 'Cashier',
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        );";
                    using (MySqlCommand cmd = new MySqlCommand(createUsersTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create Transactions table
                    string createTransactionsTable = @"
                        CREATE TABLE IF NOT EXISTS transactions (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            user_id INT,
                            transaction_date DATETIME DEFAULT CURRENT_TIMESTAMP,
                            total_amount DECIMAL(10,2) NOT NULL,
                            amount_paid DECIMAL(10,2) NOT NULL,
                            change_amount DECIMAL(10,2) NOT NULL,
                            payment_method VARCHAR(20) NOT NULL DEFAULT 'Cash',
                            FOREIGN KEY (user_id) REFERENCES users(id)
                        );";
                    using (MySqlCommand cmd = new MySqlCommand(createTransactionsTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create Transaction Items table
                    string createTransactionItemsTable = @"
                        CREATE TABLE IF NOT EXISTS transaction_items (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            transaction_id INT,
                            product_id INT,
                            product_name VARCHAR(100) NOT NULL,
                            price DECIMAL(10,2) NOT NULL,
                            quantity INT NOT NULL,
                            subtotal DECIMAL(10,2) NOT NULL,
                            FOREIGN KEY (transaction_id) REFERENCES transactions(id),
                            FOREIGN KEY (product_id) REFERENCES products(id)
                        );";
                    using (MySqlCommand cmd = new MySqlCommand(createTransactionItemsTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Insert default admin user if not exists
                    string insertDefaultUser = @"
                        INSERT INTO users (username, password, full_name, role)
                        SELECT 'admin', 'admin123', 'Administrator', 'Admin'
                        WHERE NOT EXISTS (SELECT 1 FROM users WHERE username = 'admin');";
                    using (MySqlCommand cmd = new MySqlCommand(insertDefaultUser, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Insert default categories if not exists
                    string insertDefaultCategories = @"
                        INSERT INTO categories (name, description)
                        SELECT 'Beverages', 'Drinks and liquids for consumption'
                        WHERE NOT EXISTS (SELECT 1 FROM categories WHERE name = 'Beverages');

                        INSERT INTO categories (name, description)
                        SELECT 'Bakery', 'Bread, pastries, and baked goods'
                        WHERE NOT EXISTS (SELECT 1 FROM categories WHERE name = 'Bakery');

                        INSERT INTO categories (name, description)
                        SELECT 'Canned Goods', 'Preserved food in cans or jars'
                        WHERE NOT EXISTS (SELECT 1 FROM categories WHERE name = 'Canned Goods');

                        INSERT INTO categories (name, description)
                        SELECT 'Dairy', 'Milk, cheese, and other dairy products'
                        WHERE NOT EXISTS (SELECT 1 FROM categories WHERE name = 'Dairy');

                        INSERT INTO categories (name, description)
                        SELECT 'Dry/Baking Goods', 'Flour, sugar, cereal, and baking items'
                        WHERE NOT EXISTS (SELECT 1 FROM categories WHERE name = 'Dry/Baking Goods');

                        INSERT INTO categories (name, description)
                        SELECT 'Frozen Foods', 'Frozen meals, vegetables, and desserts'
                        WHERE NOT EXISTS (SELECT 1 FROM categories WHERE name = 'Frozen Foods');

                        INSERT INTO categories (name, description)
                        SELECT 'Meat', 'Beef, pork, poultry, and seafood'
                        WHERE NOT EXISTS (SELECT 1 FROM categories WHERE name = 'Meat');

                        INSERT INTO categories (name, description)
                        SELECT 'Produce', 'Fruits and vegetables'
                        WHERE NOT EXISTS (SELECT 1 FROM categories WHERE name = 'Produce');

                        INSERT INTO categories (name, description)
                        SELECT 'Cleaners', 'Household cleaning products'
                        WHERE NOT EXISTS (SELECT 1 FROM categories WHERE name = 'Cleaners');

                        INSERT INTO categories (name, description)
                        SELECT 'Paper Goods', 'Paper towels, toilet paper, etc.'
                        WHERE NOT EXISTS (SELECT 1 FROM categories WHERE name = 'Paper Goods');

                        INSERT INTO categories (name, description)
                        SELECT 'Personal Care', 'Soap, shampoo, toothpaste, etc.'
                        WHERE NOT EXISTS (SELECT 1 FROM categories WHERE name = 'Personal Care');

                        INSERT INTO categories (name, description)
                        SELECT 'Other', 'Miscellaneous items'
                        WHERE NOT EXISTS (SELECT 1 FROM categories WHERE name = 'Other');";
                    using (MySqlCommand cmd = new MySqlCommand(insertDefaultCategories, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Insert sample products if not exists (with Philippine grocery products and prices)
                    string insertSampleProducts = @"
                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Alaska Powdered Milk 80g', (SELECT id FROM categories WHERE name = 'Dairy'), 49.50, 50, '4800092100123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Alaska Powdered Milk 80g');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Gardenia Classic White Bread', (SELECT id FROM categories WHERE name = 'Bakery'), 87.75, 30, '4800092200123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Gardenia Classic White Bread');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Magnolia Chicken Eggs (6pcs)', (SELECT id FROM categories WHERE name = 'Dairy'), 52.50, 40, '4800092300123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Magnolia Chicken Eggs (6pcs)');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Coca Cola 1.5L', (SELECT id FROM categories WHERE name = 'Beverages'), 63.25, 60, '4800092400123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Coca Cola 1.5L');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Magnolia Chicken Breast 1kg', (SELECT id FROM categories WHERE name = 'Meat'), 220.00, 25, '4800092500123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Magnolia Chicken Breast 1kg');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Saba Banana (1kg)', (SELECT id FROM categories WHERE name = 'Produce'), 60.00, 100, '4800092600123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Saba Banana (1kg)');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Tissue Roll 12pcs', (SELECT id FROM categories WHERE name = 'Paper Goods'), 180.00, 30, '4800092700123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Tissue Roll 12pcs');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Joy Dishwashing Liquid 250ml', (SELECT id FROM categories WHERE name = 'Cleaners'), 45.75, 45, '4800092800123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Joy Dishwashing Liquid 250ml');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Century Tuna Flakes 155g', (SELECT id FROM categories WHERE name = 'Canned Goods'), 38.50, 80, '4800092900123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Century Tuna Flakes 155g');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Jasmine Rice 5kg', (SELECT id FROM categories WHERE name = 'Dry/Baking Goods'), 275.00, 20, '4800093000123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Jasmine Rice 5kg');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Lucky Me Pancit Canton 6pcs', (SELECT id FROM categories WHERE name = 'Dry/Baking Goods'), 75.50, 40, '4800093100123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Lucky Me Pancit Canton 6pcs');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Milo 300g', (SELECT id FROM categories WHERE name = 'Beverages'), 99.75, 35, '4800093200123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Milo 300g');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Nescafe 3-in-1 Original 30x20g', (SELECT id FROM categories WHERE name = 'Beverages'), 125.50, 30, '4800093300123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Nescafe 3-in-1 Original 30x20g');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Piattos Cheese 85g', (SELECT id FROM categories WHERE name = 'Dry/Baking Goods'), 32.75, 50, '4800093400123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Piattos Cheese 85g');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Safeguard Soap 135g', (SELECT id FROM categories WHERE name = 'Personal Care'), 42.50, 40, '4800093500123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Safeguard Soap 135g');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Head & Shoulders Shampoo 180ml', (SELECT id FROM categories WHERE name = 'Personal Care'), 119.75, 25, '4800093600123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Head & Shoulders Shampoo 180ml');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Colgate Toothpaste 150g', (SELECT id FROM categories WHERE name = 'Personal Care'), 85.25, 35, '4800093700123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Colgate Toothpaste 150g');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Del Monte Spaghetti Sauce 250g', (SELECT id FROM categories WHERE name = 'Canned Goods'), 42.75, 40, '4800093800123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Del Monte Spaghetti Sauce 250g');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Spaghetti Pasta 1kg', (SELECT id FROM categories WHERE name = 'Dry/Baking Goods'), 72.50, 30, '4800093900123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Spaghetti Pasta 1kg');

                        INSERT INTO products (name, category_id, price, stock, barcode)
                        SELECT 'Condensed Milk 300ml', (SELECT id FROM categories WHERE name = 'Dairy'), 55.25, 45, '4800094000123'
                        WHERE NOT EXISTS (SELECT 1 FROM products WHERE name = 'Condensed Milk 300ml');";
                    using (MySqlCommand cmd = new MySqlCommand(insertSampleProducts, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
                return false;
            }
        }
    }
}
