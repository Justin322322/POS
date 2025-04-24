using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Grocery_POS.Models;

namespace Grocery_POS.Forms
{
    public partial class ReportPreviewForm : Form
    {
        private readonly DateTime startDate;
        private readonly DateTime endDate;
        private readonly decimal totalSales;
        private readonly int totalTransactions;
        private readonly decimal avgTransaction;
        private readonly List<Transaction> transactions;

        public ReportPreviewForm(
            DateTime startDate,
            DateTime endDate,
            decimal totalSales,
            int totalTransactions,
            decimal avgTransaction,
            List<Transaction> transactions)
        {
            InitializeComponent();
            this.startDate = startDate;
            this.endDate = endDate;
            this.totalSales = totalSales;
            this.totalTransactions = totalTransactions;
            this.avgTransaction = avgTransaction;
            this.transactions = transactions;

            LoadReport();
        }

        private void LoadReport()
        {
            // Use StringBuilder for better performance
            StringBuilder reportText = new StringBuilder();

            // Build report content
            reportText.AppendLine("GROCERY POS SYSTEM");
            reportText.AppendLine("TRANSACTION REPORT");
            reportText.AppendLine();

            reportText.AppendLine($"Report Period: {startDate:MM/dd/yyyy} - {endDate:MM/dd/yyyy}");
            reportText.AppendLine($"Generated On: {DateTime.Now:MM/dd/yyyy HH:mm:ss}");
            reportText.AppendLine();

            // Summary Section
            reportText.AppendLine("SUMMARY");
            reportText.AppendLine("----------------------------------------");
            reportText.AppendLine($"Total Sales: {totalSales:C2}");
            reportText.AppendLine($"Total Transactions: {totalTransactions}");
            reportText.AppendLine($"Average Transaction: {avgTransaction:C2}");
            reportText.AppendLine();

            // Transactions Section
            reportText.AppendLine("TRANSACTION DETAILS");
            reportText.AppendLine("----------------------------------------");

            // Group transactions by date for better organization
            var transactionsByDate = transactions
                .OrderBy(t => t.TransactionDate)
                .GroupBy(t => t.TransactionDate.Date);

            foreach (var dateGroup in transactionsByDate)
            {
                // Print date header
                reportText.AppendLine();
                reportText.AppendLine($"DATE: {dateGroup.Key:MM/dd/yyyy}");
                reportText.AppendLine("----------------------------------------");
                reportText.AppendLine("TRANS ID   TIME     ITEMS    PAYMENT       AMOUNT");

                // Print transactions for this date
                foreach (var transaction in dateGroup)
                {
                    string id = transaction.TransactionId.ToString().PadRight(10);
                    string time = transaction.TransactionDate.ToString("HH:mm").PadRight(8);
                    string items = transaction.Items.Count.ToString().PadRight(8);
                    string method = transaction.PaymentMethod.PadRight(12);
                    string amount = transaction.TotalAmount.ToString("C2").PadLeft(10);

                    reportText.AppendLine($"{id}{time}{items}{method}{amount}");
                }

                // Print subtotal for the day
                decimal dayTotal = dateGroup.Sum(t => t.TotalAmount);
                reportText.AppendLine("----------------------------------------");
                reportText.AppendLine($"Day Total: {dayTotal:C2}".PadLeft(48));
                reportText.AppendLine();
            }

            // Add transaction item details if requested
            if (transactions.Count > 0 && transactions.Count <= 20) // Only show details for a reasonable number of transactions
            {
                reportText.AppendLine();
                reportText.AppendLine("TRANSACTION ITEM DETAILS");
                reportText.AppendLine("----------------------------------------");

                foreach (var transaction in transactions.OrderBy(t => t.TransactionDate))
                {
                    reportText.AppendLine();
                    reportText.AppendLine($"Transaction ID: {transaction.TransactionId}");
                    reportText.AppendLine($"Date/Time: {transaction.TransactionDate:MM/dd/yyyy HH:mm:ss}");
                    reportText.AppendLine($"Payment Method: {transaction.PaymentMethod}");
                    reportText.AppendLine($"Total Amount: {transaction.TotalAmount:C2}");
                    reportText.AppendLine("----------------------------------------");
                    reportText.AppendLine("QTY  ITEM                PRICE    AMOUNT");

                    foreach (var item in transaction.Items)
                    {
                        string qty = item.Quantity.ToString().PadRight(4);
                        string name = item.ProductName.Length > 20 ?
                            item.ProductName.Substring(0, 20) :
                            item.ProductName.PadRight(20);
                        string price = item.Price.ToString("C2").PadLeft(8);
                        string amount = (item.Price * item.Quantity).ToString("C2").PadLeft(10);
                        reportText.AppendLine($"{qty}{name}{price}{amount}");
                    }
                    reportText.AppendLine("----------------------------------------");
                }
            }

            // Set the text all at once for better performance
            rtbReport.Text = reportText.ToString();

            // Apply formatting after setting the text
            rtbReport.SelectAll();
            rtbReport.SelectionFont = new Font("Courier New", 10);
            rtbReport.SelectionAlignment = HorizontalAlignment.Left;
            rtbReport.DeselectAll();

            // Center the header
            CenterTextLines(0, 2);

            // Scroll to top
            rtbReport.SelectionStart = 0;
            rtbReport.ScrollToCaret();
        }

        private void CenterTextLines(int startLine, int endLine)
        {
            if (rtbReport.Lines.Length <= endLine) return;

            int startPos = rtbReport.GetFirstCharIndexFromLine(startLine);
            int endLineStartPos = rtbReport.GetFirstCharIndexFromLine(endLine);
            int endPos = endLineStartPos + rtbReport.Lines[endLine].Length;

            rtbReport.Select(startPos, endPos - startPos);
            rtbReport.SelectionAlignment = HorizontalAlignment.Center;
            rtbReport.DeselectAll();
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            // Disable the print button to prevent multiple clicks
            btnPrint.Enabled = false;
            btnPrint.Text = "Printing...";

            try
            {
                await Task.Run(() => {
                    try {
                        var document = new PrintDocument();
                        document.DefaultPageSettings.PaperSize = new PaperSize("Letter", 850, 1100);
                        document.PrintPage += (s, pe) =>
                        {
                            if (pe.Graphics != null && rtbReport.Text != null)
                            {
                                // Calculate how many characters can fit on a page
                                Font printFont = new Font("Courier New", 10);
                                float lineHeight = printFont.GetHeight(pe.Graphics);
                                int linesPerPage = (int)((pe.MarginBounds.Height - 100) / lineHeight);

                                // Draw the text
                                pe.Graphics.DrawString(rtbReport.Text, printFont, Brushes.Black,
                                    new RectangleF(50, 50, pe.MarginBounds.Width - 100, pe.MarginBounds.Height - 100));
                            }
                            pe.HasMorePages = false;
                        };
                        document.Print();
                        return true;
                    }
                    catch {
                        return false;
                    }
                }).ContinueWith(t => {
                    // This runs on the UI thread
                    if (t.Result)
                    {
                        MessageBox.Show("Transaction report printed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to print report. Please check printer connection and try again.",
                                      "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Re-enable the print button
                    btnPrint.Enabled = true;
                    btnPrint.Text = "Print Report";
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to print report: {ex.Message}\nPlease check printer connection and try again.",
                              "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Re-enable the print button
                btnPrint.Enabled = true;
                btnPrint.Text = "Print Report";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
