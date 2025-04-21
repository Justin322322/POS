using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grocery_POS.Models;
using Grocery_POS.Services;
using Grocery_POS.UI;

namespace Grocery_POS.Forms
{
    public partial class TransactionHistoryForm : Form
    {
        private readonly TransactionService transactionService;
        private Transaction? selectedTransaction;

        public TransactionHistoryForm()
        {
            InitializeComponent();
            transactionService = new TransactionService();
        }

        private void TransactionHistoryForm_Load(object sender, EventArgs e)
        {
            // Set date range to current month
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;

            // Load transactions
            LoadTransactions();

            // Setup DataGridViews
            SetupDataGridViews();
        }

        private void SetupDataGridViews()
        {
            // Configure transactions DataGridView
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.AllowUserToResizeRows = false;
            dgvTransactions.MultiSelect = false;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.BackgroundColor = Color.White;
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransactions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTransactions.ColumnHeadersHeight = 40;
            dgvTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTransactions.RowTemplate.Height = 30;

            // Add columns
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Id";
            idColumn.HeaderText = "ID";
            idColumn.DataPropertyName = "Id";
            idColumn.Width = 50;
            dgvTransactions.Columns.Add(idColumn);

            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.Name = "Date";
            dateColumn.HeaderText = "Date";
            dateColumn.DataPropertyName = "TransactionDate";
            dateColumn.Width = 150;
            dateColumn.DefaultCellStyle.Format = "g"; // Short date and time
            dgvTransactions.Columns.Add(dateColumn);

            DataGridViewTextBoxColumn totalColumn = new DataGridViewTextBoxColumn();
            totalColumn.Name = "Total";
            totalColumn.HeaderText = "Total";
            totalColumn.DataPropertyName = "TotalAmount";
            totalColumn.Width = 100;
            totalColumn.DefaultCellStyle.Format = "C2";
            dgvTransactions.Columns.Add(totalColumn);

            DataGridViewTextBoxColumn paymentMethodColumn = new DataGridViewTextBoxColumn();
            paymentMethodColumn.Name = "PaymentMethod";
            paymentMethodColumn.HeaderText = "Payment Method";
            paymentMethodColumn.DataPropertyName = "PaymentMethod";
            paymentMethodColumn.Width = 120;
            dgvTransactions.Columns.Add(paymentMethodColumn);

            // Configure transaction items DataGridView
            dgvTransactionItems.AutoGenerateColumns = false;
            dgvTransactionItems.AllowUserToAddRows = false;
            dgvTransactionItems.AllowUserToDeleteRows = false;
            dgvTransactionItems.AllowUserToResizeRows = false;
            dgvTransactionItems.MultiSelect = false;
            dgvTransactionItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactionItems.ReadOnly = true;
            dgvTransactionItems.RowHeadersVisible = false;
            dgvTransactionItems.BackgroundColor = Color.White;
            dgvTransactionItems.BorderStyle = BorderStyle.None;
            dgvTransactionItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransactionItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTransactionItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvTransactionItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransactionItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTransactionItems.ColumnHeadersHeight = 40;
            dgvTransactionItems.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTransactionItems.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dgvTransactionItems.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTransactionItems.RowTemplate.Height = 30;

            // Add columns
            DataGridViewTextBoxColumn productIdColumn = new DataGridViewTextBoxColumn();
            productIdColumn.Name = "ProductId";
            productIdColumn.HeaderText = "Product ID";
            productIdColumn.DataPropertyName = "ProductId";
            productIdColumn.Width = 80;
            dgvTransactionItems.Columns.Add(productIdColumn);

            DataGridViewTextBoxColumn productNameColumn = new DataGridViewTextBoxColumn();
            productNameColumn.Name = "ProductName";
            productNameColumn.HeaderText = "Product";
            productNameColumn.DataPropertyName = "ProductName";
            productNameColumn.Width = 200;
            dgvTransactionItems.Columns.Add(productNameColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.Name = "Price";
            priceColumn.HeaderText = "Price";
            priceColumn.DataPropertyName = "Price";
            priceColumn.Width = 100;
            priceColumn.DefaultCellStyle.Format = "C2";
            dgvTransactionItems.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.Name = "Quantity";
            quantityColumn.HeaderText = "Qty";
            quantityColumn.DataPropertyName = "Quantity";
            quantityColumn.Width = 50;
            dgvTransactionItems.Columns.Add(quantityColumn);

            DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn();
            subtotalColumn.Name = "Subtotal";
            subtotalColumn.HeaderText = "Subtotal";
            subtotalColumn.DataPropertyName = "Subtotal";
            subtotalColumn.Width = 100;
            subtotalColumn.DefaultCellStyle.Format = "C2";
            dgvTransactionItems.Columns.Add(subtotalColumn);
        }

        private void LoadTransactions()
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1); // End of the day

            var transactions = transactionService.GetTransactionsByDateRange(startDate, endDate);
            dgvTransactions.DataSource = transactions;

            // Clear transaction items
            dgvTransactionItems.DataSource = null;
            selectedTransaction = null;

            // Update total sales
            decimal totalSales = transactions.Sum(t => t.TotalAmount);
            lblTotalSales.Text = totalSales.ToString("C2");
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void dgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int transactionId = Convert.ToInt32(dgvTransactions.Rows[e.RowIndex].Cells["Id"].Value);
                selectedTransaction = transactionService.GetTransactionById(transactionId);
                
                if (selectedTransaction != null)
                {
                    dgvTransactionItems.DataSource = selectedTransaction.Items;
                }
            }
        }
    }
}
