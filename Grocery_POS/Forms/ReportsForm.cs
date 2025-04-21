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
    public partial class ReportsForm : Form
    {
        private readonly TransactionService transactionService;
        private readonly ProductService productService;

        public ReportsForm()
        {
            InitializeComponent();
            transactionService = new TransactionService();
            productService = new ProductService();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Set date range to current month
                dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtpEndDate.Value = DateTime.Now;

                // Load reports
                LoadReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reports: {ex.Message}\n\nThis feature may require additional components.", "Reports Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReports()
        {
            try
            {
                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1); // End of the day

                // Get transactions for the date range
                var transactions = transactionService.GetTransactionsByDateRange(startDate, endDate);

                // Calculate total sales
                decimal totalSales = transactions.Sum(t => t.TotalAmount);
                lblTotalSales.Text = totalSales.ToString("C2");

                // Calculate total transactions
                lblTotalTransactions.Text = transactions.Count.ToString();

                // Calculate average transaction value
                decimal avgTransaction = transactions.Count > 0 ? totalSales / transactions.Count : 0;
                lblAvgTransaction.Text = avgTransaction.ToString("C2");

                // Get top selling products
                var topProducts = transactions
                    .SelectMany(t => t.Items)
                    .GroupBy(i => i.ProductId)
                    .Select(g => new
                    {
                        ProductId = g.Key,
                        ProductName = g.First().ProductName,
                        TotalQuantity = g.Sum(i => i.Quantity),
                        TotalSales = g.Sum(i => i.Subtotal)
                    })
                    .OrderByDescending(p => p.TotalQuantity)
                    .Take(5)
                    .ToList();

                // Display top products
                dgvTopProducts.DataSource = topProducts;

                // Calculate sales by payment method
                var salesByPaymentMethod = transactions
                    .GroupBy(t => t.PaymentMethod)
                    .Select(g => new
                    {
                        PaymentMethod = g.Key,
                        TotalSales = g.Sum(t => t.TotalAmount),
                        Count = g.Count()
                    })
                    .OrderByDescending(p => p.TotalSales)
                    .ToList();

                // Display sales by payment method
                dgvPaymentMethods.DataSource = salesByPaymentMethod;

                try
                {
                    // Calculate daily sales for chart
                    var dailySales = transactions
                        .GroupBy(t => t.TransactionDate.Date)
                        .Select(g => new
                        {
                            Date = g.Key,
                            TotalSales = g.Sum(t => t.TotalAmount)
                        })
                        .OrderBy(d => d.Date)
                        .ToList();

                    // Clear chart
                    if (chartSales.Series.Count > 0)
                    {
                        chartSales.Series["Sales"].Points.Clear();

                        // Add data to chart
                        foreach (var day in dailySales)
                        {
                            chartSales.Series["Sales"].Points.AddXY(day.Date.ToShortDateString(), (double)day.TotalSales);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chart component not available. This feature requires the Windows Forms DataVisualization package.", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading chart: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reports data: {ex.Message}", "Reports Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            LoadReports();
        }
    }
}
