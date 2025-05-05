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

            // Improved header styling
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvTransactions.ColumnHeadersHeight = 45;

            // Improved cell styling
            dgvTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 0);
            dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTransactions.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            dgvTransactions.RowTemplate.Height = 35;
            dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Add columns - simplified and improved
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Id";
            idColumn.HeaderText = "ID";
            idColumn.DataPropertyName = "Id";
            idColumn.Width = 60;
            idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransactions.Columns.Add(idColumn);

            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.Name = "Date";
            dateColumn.HeaderText = "Date & Time";
            dateColumn.DataPropertyName = "TransactionDate";
            dateColumn.Width = 170;
            dateColumn.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvTransactions.Columns.Add(dateColumn);

            DataGridViewTextBoxColumn totalColumn = new DataGridViewTextBoxColumn();
            totalColumn.Name = "Total";
            totalColumn.HeaderText = "Total Amount";
            totalColumn.DataPropertyName = "TotalAmount";
            totalColumn.Width = 120;
            totalColumn.DefaultCellStyle.Format = "₱ #,##0.00";
            totalColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns.Add(totalColumn);

            DataGridViewTextBoxColumn amountPaidColumn = new DataGridViewTextBoxColumn();
            amountPaidColumn.Name = "AmountPaid";
            amountPaidColumn.HeaderText = "Amount Paid";
            amountPaidColumn.DataPropertyName = "AmountPaid";
            amountPaidColumn.Width = 120;
            amountPaidColumn.DefaultCellStyle.Format = "₱ #,##0.00";
            amountPaidColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns.Add(amountPaidColumn);

            DataGridViewTextBoxColumn changeColumn = new DataGridViewTextBoxColumn();
            changeColumn.Name = "Change";
            changeColumn.HeaderText = "Change";
            changeColumn.DataPropertyName = "Change";
            changeColumn.Width = 100;
            changeColumn.DefaultCellStyle.Format = "₱ #,##0.00";
            changeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns.Add(changeColumn);

            DataGridViewTextBoxColumn paymentMethodColumn = new DataGridViewTextBoxColumn();
            paymentMethodColumn.Name = "PaymentMethod";
            paymentMethodColumn.HeaderText = "Payment Method";
            paymentMethodColumn.DataPropertyName = "PaymentMethod";
            paymentMethodColumn.Width = 120;
            paymentMethodColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

            // Improved header styling
            dgvTransactionItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dgvTransactionItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransactionItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvTransactionItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvTransactionItems.ColumnHeadersHeight = 40;

            // Improved cell styling
            dgvTransactionItems.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTransactionItems.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 0);
            dgvTransactionItems.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTransactionItems.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            dgvTransactionItems.RowTemplate.Height = 35;
            dgvTransactionItems.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Add columns - improved
            DataGridViewTextBoxColumn productIdColumn = new DataGridViewTextBoxColumn();
            productIdColumn.Name = "ProductId";
            productIdColumn.HeaderText = "ID";
            productIdColumn.DataPropertyName = "ProductId";
            productIdColumn.Width = 50;
            productIdColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransactionItems.Columns.Add(productIdColumn);

            DataGridViewTextBoxColumn productNameColumn = new DataGridViewTextBoxColumn();
            productNameColumn.Name = "ProductName";
            productNameColumn.HeaderText = "Product";
            productNameColumn.DataPropertyName = "ProductName";
            productNameColumn.Width = 180;
            dgvTransactionItems.Columns.Add(productNameColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.Name = "Price";
            priceColumn.HeaderText = "Price";
            priceColumn.DataPropertyName = "Price";
            priceColumn.Width = 90;
            priceColumn.DefaultCellStyle.Format = "₱ #,##0.00";
            priceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactionItems.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.Name = "Quantity";
            quantityColumn.HeaderText = "Qty";
            quantityColumn.DataPropertyName = "Quantity";
            quantityColumn.Width = 50;
            quantityColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransactionItems.Columns.Add(quantityColumn);

            DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn();
            subtotalColumn.Name = "Subtotal";
            subtotalColumn.HeaderText = "Subtotal";
            subtotalColumn.DataPropertyName = "Subtotal";
            subtotalColumn.Width = 100;
            subtotalColumn.DefaultCellStyle.Format = "₱ #,##0.00";
            subtotalColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
            lblTotalSales.Text = "₱" + totalSales.ToString("#,##0.00");
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
