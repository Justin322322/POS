using System;
using System.Collections.Generic;

namespace Grocery_POS.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string CashierName { get; set; }
        public List<TransactionItem> Items { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Change { get; set; }
        public string PaymentMethod { get; set; }

        public Receipt()
        {
            CashierName = string.Empty;
            Items = new List<TransactionItem>();
            PaymentMethod = "Cash";
            Date = DateTime.Now;
        }
    }
} 