using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery_POS.Models;
using MySql.Data.MySqlClient;

namespace Grocery_POS.Services
{
    public class TransactionService
    {
        private readonly DatabaseConnection dbConnection;
        private readonly ProductService productService;

        public TransactionService()
        {
            dbConnection = DatabaseConnection.Instance;
            productService = new ProductService();
        }

        public bool SaveTransaction(Transaction transaction)
        {
            MySqlConnection? conn = null;
            MySqlTransaction? dbTransaction = null;

            try
            {
                conn = dbConnection.GetConnection();
                conn.Open();
                dbTransaction = conn.BeginTransaction();

                // Insert transaction
                string transactionQuery = @"
                    INSERT INTO transactions (user_id, transaction_date, total_amount, amount_paid, change_amount, payment_method)
                    VALUES (@userId, @transactionDate, @totalAmount, @amountPaid, @change, @paymentMethod);
                    SELECT LAST_INSERT_ID();";

                int transactionId;
                using (MySqlCommand cmd = new MySqlCommand(transactionQuery, conn, dbTransaction))
                {
                    cmd.Parameters.AddWithValue("@userId", transaction.UserId);
                    cmd.Parameters.AddWithValue("@transactionDate", transaction.TransactionDate);
                    cmd.Parameters.AddWithValue("@totalAmount", transaction.TotalAmount);
                    cmd.Parameters.AddWithValue("@amountPaid", transaction.AmountPaid);
                    cmd.Parameters.AddWithValue("@change", transaction.Change);
                    cmd.Parameters.AddWithValue("@paymentMethod", transaction.PaymentMethod);

                    transactionId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Batch insert transaction items
                if (transaction.Items.Count > 0)
                {
                    // Prepare batch insert for transaction items
                    StringBuilder batchItemQuery = new StringBuilder();
                    batchItemQuery.Append(@"
                        INSERT INTO transaction_items (transaction_id, product_id, product_name, price, quantity, subtotal)
                        VALUES ");

                    List<MySqlParameter> parameters = new List<MySqlParameter>();
                    int paramIndex = 0;

                    for (int i = 0; i < transaction.Items.Count; i++)
                    {
                        var item = transaction.Items[i];
                        if (i > 0) batchItemQuery.Append(",");

                        string transIdParam = $"@transId{paramIndex}";
                        string prodIdParam = $"@prodId{paramIndex}";
                        string prodNameParam = $"@prodName{paramIndex}";
                        string priceParam = $"@price{paramIndex}";
                        string qtyParam = $"@qty{paramIndex}";
                        string subtotalParam = $"@subtotal{paramIndex}";

                        batchItemQuery.Append($"({transIdParam}, {prodIdParam}, {prodNameParam}, {priceParam}, {qtyParam}, {subtotalParam})");

                        parameters.Add(new MySqlParameter(transIdParam, transactionId));
                        parameters.Add(new MySqlParameter(prodIdParam, item.ProductId));
                        parameters.Add(new MySqlParameter(prodNameParam, item.ProductName));
                        parameters.Add(new MySqlParameter(priceParam, item.Price));
                        parameters.Add(new MySqlParameter(qtyParam, item.Quantity));
                        parameters.Add(new MySqlParameter(subtotalParam, item.Subtotal));

                        paramIndex++;
                    }

                    // Execute batch insert
                    using (MySqlCommand cmd = new MySqlCommand(batchItemQuery.ToString(), conn, dbTransaction))
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                        cmd.ExecuteNonQuery();
                    }

                    // Batch update product stock
                    StringBuilder batchStockUpdate = new StringBuilder();
                    batchStockUpdate.Append("UPDATE products SET stock = CASE id ");

                    parameters.Clear();
                    paramIndex = 0;

                    foreach (var item in transaction.Items)
                    {
                        string idParam = $"@id{paramIndex}";
                        string qtyParam = $"@qty{paramIndex}";

                        batchStockUpdate.Append($" WHEN {idParam} THEN stock - {qtyParam}");

                        parameters.Add(new MySqlParameter(idParam, item.ProductId));
                        parameters.Add(new MySqlParameter(qtyParam, item.Quantity));

                        paramIndex++;
                    }

                    batchStockUpdate.Append(" END WHERE id IN (");

                    for (int i = 0; i < transaction.Items.Count; i++)
                    {
                        if (i > 0) batchStockUpdate.Append(",");
                        batchStockUpdate.Append($"@pid{i}");
                        parameters.Add(new MySqlParameter($"@pid{i}", transaction.Items[i].ProductId));
                    }

                    batchStockUpdate.Append(")");

                    using (MySqlCommand cmd = new MySqlCommand(batchStockUpdate.ToString(), conn, dbTransaction))
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }

                dbTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                dbTransaction?.Rollback();
                Console.WriteLine($"Error saving transaction: {ex.Message}");
                return false;
            }
            finally
            {
                conn?.Close();
            }
        }

        public List<Transaction> GetAllTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT t.*, u.username
                        FROM transactions t
                        LEFT JOIN users u ON t.user_id = u.id
                        ORDER BY t.transaction_date DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transaction transaction = new Transaction
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    UserId = Convert.ToInt32(reader["user_id"]),
                                    TransactionDate = Convert.ToDateTime(reader["transaction_date"]),
                                    TotalAmount = Convert.ToDecimal(reader["total_amount"]),
                                    AmountPaid = Convert.ToDecimal(reader["amount_paid"]),
                                    Change = Convert.ToDecimal(reader["change_amount"]),
                                    PaymentMethod = reader["payment_method"].ToString() ?? string.Empty
                                };

                                transactions.Add(transaction);
                            }
                        }
                    }

                    // Get transaction items for each transaction
                    foreach (var transaction in transactions)
                    {
                        string itemsQuery = "SELECT * FROM transaction_items WHERE transaction_id = @transactionId";
                        using (MySqlCommand cmd = new MySqlCommand(itemsQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@transactionId", transaction.Id);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    TransactionItem item = new TransactionItem
                                    {
                                        Id = Convert.ToInt32(reader["id"]),
                                        TransactionId = Convert.ToInt32(reader["transaction_id"]),
                                        ProductId = Convert.ToInt32(reader["product_id"]),
                                        ProductName = reader["product_name"].ToString() ?? string.Empty,
                                        Price = Convert.ToDecimal(reader["price"]),
                                        Quantity = Convert.ToInt32(reader["quantity"]),
                                        Subtotal = Convert.ToDecimal(reader["subtotal"])
                                    };

                                    transaction.Items.Add(item);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all transactions: {ex.Message}");
            }
            return transactions;
        }

        public Transaction? GetTransactionById(int id)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT t.*, u.username
                        FROM transactions t
                        LEFT JOIN users u ON t.user_id = u.id
                        WHERE t.id = @id";

                    Transaction? transaction = null;
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                transaction = new Transaction
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    UserId = Convert.ToInt32(reader["user_id"]),
                                    TransactionDate = Convert.ToDateTime(reader["transaction_date"]),
                                    TotalAmount = Convert.ToDecimal(reader["total_amount"]),
                                    AmountPaid = Convert.ToDecimal(reader["amount_paid"]),
                                    Change = Convert.ToDecimal(reader["change_amount"]),
                                    PaymentMethod = reader["payment_method"].ToString() ?? string.Empty
                                };
                            }
                        }
                    }

                    if (transaction != null)
                    {
                        // Get transaction items
                        string itemsQuery = "SELECT * FROM transaction_items WHERE transaction_id = @transactionId";
                        using (MySqlCommand cmd = new MySqlCommand(itemsQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@transactionId", transaction.Id);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    TransactionItem item = new TransactionItem
                                    {
                                        Id = Convert.ToInt32(reader["id"]),
                                        TransactionId = Convert.ToInt32(reader["transaction_id"]),
                                        ProductId = Convert.ToInt32(reader["product_id"]),
                                        ProductName = reader["product_name"].ToString() ?? string.Empty,
                                        Price = Convert.ToDecimal(reader["price"]),
                                        Quantity = Convert.ToInt32(reader["quantity"]),
                                        Subtotal = Convert.ToDecimal(reader["subtotal"])
                                    };

                                    transaction.Items.Add(item);
                                }
                            }
                        }
                    }

                    return transaction;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting transaction by id: {ex.Message}");
                return null;
            }
        }

        public List<Transaction> GetTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT t.*, u.username
                        FROM transactions t
                        LEFT JOIN users u ON t.user_id = u.id
                        WHERE t.transaction_date BETWEEN @startDate AND @endDate
                        ORDER BY t.transaction_date DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transaction transaction = new Transaction
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    UserId = Convert.ToInt32(reader["user_id"]),
                                    TransactionDate = Convert.ToDateTime(reader["transaction_date"]),
                                    TotalAmount = Convert.ToDecimal(reader["total_amount"]),
                                    AmountPaid = Convert.ToDecimal(reader["amount_paid"]),
                                    Change = Convert.ToDecimal(reader["change_amount"]),
                                    PaymentMethod = reader["payment_method"].ToString() ?? string.Empty
                                };

                                transactions.Add(transaction);
                            }
                        }
                    }

                    // Get transaction items for each transaction
                    foreach (var transaction in transactions)
                    {
                        string itemsQuery = "SELECT * FROM transaction_items WHERE transaction_id = @transactionId";
                        using (MySqlCommand cmd = new MySqlCommand(itemsQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@transactionId", transaction.Id);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    TransactionItem item = new TransactionItem
                                    {
                                        Id = Convert.ToInt32(reader["id"]),
                                        TransactionId = Convert.ToInt32(reader["transaction_id"]),
                                        ProductId = Convert.ToInt32(reader["product_id"]),
                                        ProductName = reader["product_name"].ToString() ?? string.Empty,
                                        Price = Convert.ToDecimal(reader["price"]),
                                        Quantity = Convert.ToInt32(reader["quantity"]),
                                        Subtotal = Convert.ToDecimal(reader["subtotal"])
                                    };

                                    transaction.Items.Add(item);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting transactions by date range: {ex.Message}");
            }
            return transactions;
        }

        public decimal GetTotalSalesByDate(DateTime date)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT SUM(total_amount)
                        FROM transactions
                        WHERE DATE(transaction_date) = DATE(@date)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", date);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting total sales by date: {ex.Message}");
            }
            return 0;
        }
    }
}
