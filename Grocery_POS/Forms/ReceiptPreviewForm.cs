using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grocery_POS.Models;

namespace Grocery_POS.Forms
{
    public partial class ReceiptPreviewForm : Form
    {
        private readonly Transaction transaction;
        private readonly string cashierName;

        public ReceiptPreviewForm(Transaction transaction, string cashierName)
        {
            InitializeComponent();
            this.transaction = transaction;
            this.cashierName = cashierName;
            LoadReceipt();
        }

        private void LoadReceipt()
        {
            // Use StringBuilder for better performance
            StringBuilder receiptText = new StringBuilder();

            // Build receipt content
            receiptText.AppendLine("GROCERY POS SYSTEM");
            receiptText.AppendLine("123 Bataan");
            receiptText.AppendLine("Tel: (123) 456-7890");
            receiptText.AppendLine();

            receiptText.AppendLine($"Transaction #: {transaction.TransactionId}");
            receiptText.AppendLine($"Date: {DateTime.Now:MM/dd/yyyy HH:mm:ss}");
            receiptText.AppendLine($"Cashier: {cashierName}");
            receiptText.AppendLine();

            receiptText.AppendLine("QTY  ITEM                PRICE    AMOUNT");
            receiptText.AppendLine("----------------------------------------");

            // Process items in batches for better performance
            const int batchSize = 10;
            for (int i = 0; i < transaction.Items.Count; i += batchSize)
            {
                int end = Math.Min(i + batchSize, transaction.Items.Count);
                for (int j = i; j < end; j++)
                {
                    var item = transaction.Items[j];
                    string qty = item.Quantity.ToString().PadRight(4);
                    string name = item.ProductName.Length > 20 ?
                        item.ProductName.Substring(0, 20) :
                        item.ProductName.PadRight(20);
                    string price = ("₱" + item.Price.ToString("N2")).PadLeft(8);
                    string amount = ("₱" + (item.Price * item.Quantity).ToString("N2")).PadLeft(8);
                    receiptText.AppendLine($"{qty}{name}{price}{amount}");
                }
            }

            receiptText.AppendLine("----------------------------------------");

            // Totals
            string totalLabel = "TOTAL AMOUNT:".PadRight(28);
            string totalAmount = ("₱" + transaction.TotalAmount.ToString("N2")).PadLeft(10);
            receiptText.AppendLine($"{totalLabel}{totalAmount}");

            string paidLabel = "AMOUNT PAID:".PadRight(28);
            string paidAmount = ("₱" + transaction.AmountPaid.ToString("N2")).PadLeft(10);
            receiptText.AppendLine($"{paidLabel}{paidAmount}");

            string changeLabel = "CHANGE:".PadRight(28);
            string changeAmount = ("₱" + transaction.Change.ToString("N2")).PadLeft(10);
            receiptText.AppendLine($"{changeLabel}{changeAmount}");

            string methodLabel = "PAYMENT METHOD:".PadRight(28);
            string method = transaction.PaymentMethod.PadLeft(10);
            receiptText.AppendLine($"{methodLabel}{method}");
            receiptText.AppendLine();

            receiptText.AppendLine("Thank you for shopping!");
            receiptText.AppendLine("Please come again!");

            // Set the text all at once for better performance
            rtbReceipt.Text = receiptText.ToString();

            // Apply formatting after setting the text
            rtbReceipt.SelectAll();
            rtbReceipt.SelectionAlignment = HorizontalAlignment.Left;
            rtbReceipt.DeselectAll();

            // Center the header and footer
            CenterTextLines(0, 3); // Header
            CenterTextLines(rtbReceipt.Lines.Length - 2, rtbReceipt.Lines.Length - 1); // Footer
        }

        private void CenterTextLines(int startLine, int endLine)
        {
            if (rtbReceipt.Lines.Length <= endLine) return;

            int startPos = rtbReceipt.GetFirstCharIndexFromLine(startLine);
            int endLineStartPos = rtbReceipt.GetFirstCharIndexFromLine(endLine);
            int endPos = endLineStartPos + rtbReceipt.Lines[endLine].Length;

            rtbReceipt.Select(startPos, endPos - startPos);
            rtbReceipt.SelectionAlignment = HorizontalAlignment.Center;
            rtbReceipt.DeselectAll();
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
                        document.DefaultPageSettings.PaperSize = new PaperSize("Custom", 280, 800); // Fixed height for better performance
                        document.PrintPage += (s, pe) =>
                        {
                            if (pe.Graphics != null && rtbReceipt.Text != null)
                            {
                                pe.Graphics.DrawString(rtbReceipt.Text, new Font("Courier New", 9), Brushes.Black, new RectangleF(10, 10, 260, pe.PageBounds.Height));
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
                        MessageBox.Show("Receipt printed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to print receipt. Please check printer connection and try again.",
                                      "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Re-enable the print button
                    btnPrint.Enabled = true;
                    btnPrint.Text = "Print Receipt";
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to print receipt: {ex.Message}\nPlease check printer connection and try again.",
                              "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Re-enable the print button
                btnPrint.Enabled = true;
                btnPrint.Text = "Print Receipt";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}