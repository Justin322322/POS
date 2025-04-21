using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery_POS.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public List<TransactionItem> Items { get; set; } = new();
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Change { get; set; }
        public string PaymentMethod { get; set; } = "Cash";

        public Transaction()
        {
            TransactionId = DateTime.Now.ToString("yyyyMMddHHmmss");
            TransactionDate = DateTime.Now;
        }
    }
}
