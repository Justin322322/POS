using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery_POS.Models;
using MySql.Data.MySqlClient;

namespace Grocery_POS.Services
{
    public class UserService
    {
        private readonly DatabaseConnection dbConnection;

        public UserService()
        {
            dbConnection = DatabaseConnection.Instance;
        }

        public bool Authenticate(string username, string password)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine($"MySQL Connection Error during authentication: {ex.Message}");
                        return false;
                    }

                    // First check if the users table exists
                    string checkTableQuery = "SHOW TABLES LIKE 'users'";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkTableQuery, conn))
                    {
                        object result = checkCmd.ExecuteScalar();
                        if (result == null)
                        {
                            Console.WriteLine("The users table does not exist. Database may not be properly initialized.");
                            return false;
                        }
                    }

                    // Now check for the user
                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // For debugging
                        if (count == 0)
                        {
                            // Check if the user exists but password is wrong
                            string userCheckQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                            using (MySqlCommand userCmd = new MySqlCommand(userCheckQuery, conn))
                            {
                                userCmd.Parameters.AddWithValue("@username", username);
                                int userExists = Convert.ToInt32(userCmd.ExecuteScalar());
                                if (userExists > 0)
                                {
                                    Console.WriteLine("Username exists but password is incorrect.");
                                }
                                else
                                {
                                    Console.WriteLine($"No user found with username: {username}");
                                }
                            }
                        }

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error authenticating user: {ex.Message}");
                return false;
            }
        }

        public User? GetUserByUsername(string username)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM users WHERE username = @username";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Username = reader["username"].ToString() ?? string.Empty,
                                    Password = reader["password"].ToString() ?? string.Empty,
                                    FullName = reader["full_name"].ToString() ?? string.Empty,
                                    Role = reader["role"].ToString() ?? string.Empty,
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
                Console.WriteLine($"Error getting user: {ex.Message}");
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM users";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Username = reader["username"].ToString() ?? string.Empty,
                                    Password = reader["password"].ToString() ?? string.Empty,
                                    FullName = reader["full_name"].ToString() ?? string.Empty,
                                    Role = reader["role"].ToString() ?? string.Empty,
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
                Console.WriteLine($"Error getting all users: {ex.Message}");
            }
            return users;
        }

        public bool AddUser(User user)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO users (username, password, full_name, role)
                        VALUES (@username, @password, @fullName, @role)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", user.Username);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        cmd.Parameters.AddWithValue("@fullName", user.FullName);
                        cmd.Parameters.AddWithValue("@role", user.Role);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE users
                        SET username = @username, password = @password, full_name = @fullName, role = @role
                        WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", user.Id);
                        cmd.Parameters.AddWithValue("@username", user.Username);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        cmd.Parameters.AddWithValue("@fullName", user.FullName);
                        cmd.Parameters.AddWithValue("@role", user.Role);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM users WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting user: {ex.Message}");
                return false;
            }
        }
    }
}
