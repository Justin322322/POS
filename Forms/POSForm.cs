    private void btnPay_Click(object sender, EventArgs e)
    {
        try
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty. Please add items to cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verify stock levels before proceeding
            var insufficientStockItems = new List<string>();
            foreach (var item in cartItems)
            {
                Product? product = productService.GetProductById(item.ProductId);
                if (product == null || product.Stock < item.Quantity)
                {
                    insufficientStockItems.Add($"{item.ProductName} (Available: {product?.Stock ?? 0}, Required: {item.Quantity})");
                }
            }

            if (insufficientStockItems.Count > 0)
            {
                string message = "Insufficient stock for the following items:\n\n" + 
                               string.Join("\n", insufficientStockItems);
                MessageBox.Show(message, "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show payment form
            using (PaymentForm paymentForm = new PaymentForm(totalAmount))
            {
                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    // Create transaction
                    Transaction transaction = new Transaction
                    {
                        UserId = currentUser.Id,
                        TransactionDate = DateTime.Now,
                        TotalAmount = totalAmount,
                        AmountPaid = paymentForm.AmountPaid,
                        Change = paymentForm.Change,
                        PaymentMethod = paymentForm.PaymentMethod,
                        Items = new List<TransactionItem>(cartItems)
                    };

                    // Save transaction
                    if (transactionService.SaveTransaction(transaction))
                    {
                        try
                        {
                            // Generate and print receipt
                            receiptService.GenerateReceipt(transaction, currentUser.Username);
                            receiptService.PrintReceipt();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Transaction completed but failed to print receipt: {ex.Message}\n\nPlease check printer connection and try printing again.", 
                                          "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        MessageBox.Show($"Transaction completed successfully!\n\nTotal: ₱{totalAmount:N2}\nPaid: ₱{paymentForm.AmountPaid:N2}\nChange: ₱{paymentForm.Change:N2}", 
                                      "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear cart and refresh
                        cartItems.Clear();
                        RefreshCart();
                        UpdateTotalAmount();
                        LoadProducts(); // Reload products to update stock
                        txtBarcode.Clear();
                        txtBarcode.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Failed to complete transaction. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error processing payment: {ex.Message}\n\nPlease try again or contact support if the problem persists.", 
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }