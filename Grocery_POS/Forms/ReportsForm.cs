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

                // Ensure chart is initialized
                if (chartSales == null)
                {
                    // Create the chart control if it doesn't exist
                    chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
                    chartSales.Location = new Point(15, 50);
                    chartSales.Name = "chartSales";
                    chartSales.Size = new Size(1006, 145);
                    chartSales.TabIndex = 1;
                    chartSales.Text = "Sales Chart";

                    // Add the chart to the panel
                    if (panelChart != null)
                    {
                        panelChart.Controls.Add(chartSales);
                    }
                }

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
                // Check if chart control is available
                if (chartSales == null)
                {
                    // Create the chart control if it doesn't exist
                    chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
                    chartSales.Location = new Point(15, 50);
                    chartSales.Name = "chartSales";
                    chartSales.Size = new Size(1006, 145);
                    chartSales.TabIndex = 1;
                    chartSales.Text = "Sales Chart";

                    // Add the chart to the panel
                    if (panelChart != null)
                    {
                        panelChart.Controls.Add(chartSales);
                    }
                }

                // Initialize chart series and areas
                try
                {
                    // Create a new series if needed
                    if (chartSales.Series.Count == 0)
                    {
                        // Create a new series
                        var series = new System.Windows.Forms.DataVisualization.Charting.Series
                        {
                            Name = "Sales",
                            ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                            IsVisibleInLegend = true,
                            Color = System.Drawing.Color.FromArgb(0, 122, 204)
                        };

                        // Add the series to the chart
                        chartSales.Series.Add(series);

                        // Set chart appearance
                        if (chartSales.ChartAreas.Count == 0)
                        {
                            chartSales.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Default"));
                        }

                        if (chartSales.Legends.Count == 0)
                        {
                            chartSales.Legends.Add(new System.Windows.Forms.DataVisualization.Charting.Legend("Default"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error initializing chart: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

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

                    // Update chart if it's properly initialized
                    if (chartSales != null && chartSales.Series.Count > 0 && chartSales.Series["Sales"] != null)
                    {
                        // Clear chart
                        chartSales.Series["Sales"].Points.Clear();

                        // Add data to chart
                        foreach (var day in dailySales)
                        {
                            chartSales.Series["Sales"].Points.AddXY(day.Date.ToShortDateString(), (double)day.TotalSales);
                        }
                    }
                    else
                    {
                        // Just log the issue without showing a message box to avoid overwhelming the user
                        System.Diagnostics.Debug.WriteLine("Chart not properly initialized for data loading");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading chart data: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
