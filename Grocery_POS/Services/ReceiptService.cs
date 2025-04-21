using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Linq;
using Grocery_POS.Models;

namespace Grocery_POS.Services
{
    public class ReceiptService
    {
        private readonly Font regularFont = new Font("Courier New", 9);
        private readonly Font boldFont = new Font("Courier New", 9, FontStyle.Bold);
        private readonly Font headerFont = new Font("Courier New", 11, FontStyle.Bold);
        private readonly int paperWidth = 280;
        private readonly int margin = 10;
        private readonly StringFormat centerFormat;
        private readonly StringFormat leftFormat;
        private readonly StringFormat rightFormat;
        private Transaction? currentTransaction;
        private string? cashierName;

        public ReceiptService()
        {
            centerFormat = new StringFormat { Alignment = StringAlignment.Center };
            leftFormat = new StringFormat { Alignment = StringAlignment.Near };
            rightFormat = new StringFormat { Alignment = StringAlignment.Far };
        }

        public void GenerateReceipt(Transaction transaction, string username)
        {
            currentTransaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
            cashierName = username ?? throw new ArgumentNullException(nameof(username));
        }

        public void PrintReceipt()
        {
            if (currentTransaction == null || cashierName == null)
            {
                throw new InvalidOperationException("No receipt to print. Call GenerateReceipt first.");
            }

            try
            {
                var document = new PrintDocument();
                document.DefaultPageSettings.PaperSize = new PaperSize("Custom", paperWidth, 0);
                document.PrintController = new StandardPrintController(); // Prevents print dialog
                document.PrintPage += PrintPage;
                document.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to print receipt: " + ex.Message);
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            int yPos = margin;
            Graphics g = e.Graphics;

            // Store Header
            string storeName = "GROCERY POS SYSTEM";
            string address = "123 Bataan";
            string phone = "Tel: (123) 456-7890";
            
            g.DrawString(storeName, headerFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 20), centerFormat);
            yPos += 20;
            g.DrawString(address, regularFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 15), centerFormat);
            yPos += 15;
            g.DrawString(phone, regularFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 15), centerFormat);
            yPos += 20;

            // Transaction Info
            DrawDottedLine(g, yPos);
            yPos += 5;
            g.DrawString($"Transaction #: {currentTransaction.TransactionId}", boldFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 15), leftFormat);
            yPos += 15;
            g.DrawString($"Date: {DateTime.Now:MM/dd/yyyy HH:mm:ss}", regularFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 15), leftFormat);
            yPos += 15;
            g.DrawString($"Cashier: {cashierName}", regularFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 15), leftFormat);
            yPos += 20;

            // Items Header
            DrawDottedLine(g, yPos);
            yPos += 5;
            g.DrawString("QTY  ITEM                PRICE    AMOUNT", boldFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 15), leftFormat);
            yPos += 15;
            DrawDottedLine(g, yPos);
            yPos += 10;

            // Items
            foreach (var item in currentTransaction.Items)
            {
                string qty = item.Quantity.ToString().PadRight(4);
                string name = item.ProductName.PadRight(20).Substring(0, 20);
                string price = ("₱" + item.Price.ToString("N2")).PadLeft(8);
                string amount = ("₱" + (item.Price * item.Quantity).ToString("N2")).PadLeft(8);

                g.DrawString($"{qty}{name}{price}{amount}", regularFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 15), leftFormat);
                yPos += 15;
            }

            // Totals
            yPos += 5;
            DrawDottedLine(g, yPos);
            yPos += 10;
            
            string totalLabel = "TOTAL AMOUNT:".PadRight(28);
            string totalAmount = ("₱" + currentTransaction.TotalAmount.ToString("N2")).PadLeft(10);
            g.DrawString($"{totalLabel}{totalAmount}", boldFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 15), leftFormat);
            yPos += 15;

            string paidLabel = "AMOUNT PAID:".PadRight(28);
            string paidAmount = ("₱" + currentTransaction.AmountPaid.ToString("N2")).PadLeft(10);
            g.DrawString($"{paidLabel}{paidAmount}", regularFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 15), leftFormat);
            yPos += 15;

            string changeLabel = "CHANGE:".PadRight(28);
            string changeAmount = ("₱" + currentTransaction.Change.ToString("N2")).PadLeft(10);
            g.DrawString($"{changeLabel}{changeAmount}", regularFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 15), leftFormat);
            yPos += 15;

            string methodLabel = "PAYMENT METHOD:".PadRight(28);
            string method = currentTransaction.PaymentMethod.PadLeft(10);
            g.DrawString($"{methodLabel}{method}", regularFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 15), leftFormat);
            yPos += 25;

            // Footer
            DrawDottedLine(g, yPos);
            yPos += 10;
            g.DrawString("Thank you for shopping!", boldFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 15), centerFormat);
            yPos += 15;
            g.DrawString("Please come again!", regularFont, Brushes.Black, new RectangleF(margin, yPos, paperWidth - 2 * margin, 15), centerFormat);
            yPos += 25;

            // Set page height
            e.PageSettings.PaperSize = new PaperSize("Custom", paperWidth, yPos + margin);
            e.HasMorePages = false;
        }

        private void DrawDottedLine(Graphics g, int yPos)
        {
            using (Pen pen = new Pen(Color.Black, 1))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                g.DrawLine(pen, margin, yPos, paperWidth - margin, yPos);
            }
        }
    }
} 