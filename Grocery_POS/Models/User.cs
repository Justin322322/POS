using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery_POS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } // Admin, Cashier, etc.
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
            FullName = string.Empty;
            Role = "Cashier"; // Default role
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
