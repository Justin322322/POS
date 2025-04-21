public partial class PaymentForm : Form
{
    private decimal AmountPaid { get; set; }
    private decimal Change { get; set; }
    private string PaymentMethod { get; set; }
    private decimal TotalAmount { get; set; }

    public PaymentForm(decimal totalAmount)
    {
        InitializeComponent();
        TotalAmount = totalAmount;
        lblTotalAmount.Text = "₱" + TotalAmount.ToString("N2");
        btnConfirm.Enabled = false;
    }

    private void txtAmountPaid_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (decimal.TryParse(txtAmountPaid.Texts.Replace("₱", "").Trim(), out decimal amountPaid))
            {
                AmountPaid = amountPaid;
                Change = AmountPaid - TotalAmount;
                lblChange.Text = "₱" + Change.ToString("N2");
                btnConfirm.Enabled = AmountPaid >= TotalAmount;

                // Highlight change in green if valid
                lblChange.ForeColor = Change >= 0 ? Color.Green : Color.Red;
            }
            else
            {
                AmountPaid = 0;
                Change = 0;
                lblChange.Text = "₱0.00";
                lblChange.ForeColor = Color.Black;
                btnConfirm.Enabled = false;
            }
        }
        catch (Exception)
        {
            AmountPaid = 0;
            Change = 0;
            lblChange.Text = "₱0.00";
            lblChange.ForeColor = Color.Black;
            btnConfirm.Enabled = false;
        }
    }

    private void rbCash_CheckedChanged(object sender, EventArgs e)
    {
        if (rbCash.Checked)
        {
            PaymentMethod = "Cash";
            txtAmountPaid.Enabled = true;
            lblChange.Enabled = true;
            lblChangeLabel.Enabled = true;
            txtAmountPaid.Texts = "";
            lblChange.Text = "₱0.00";
            lblChange.ForeColor = Color.Black;
            btnConfirm.Enabled = false;
            txtAmountPaid.Focus();
        }
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            if (PaymentMethod == "Cash")
            {
                if (AmountPaid < TotalAmount)
                {
                    MessageBox.Show("Insufficient amount paid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmountPaid.Focus();
                    return;
                }
            }
            else if (PaymentMethod == "Card")
            {
                // For card payments, ensure the exact amount
                AmountPaid = TotalAmount;
                Change = 0;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error processing payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        // Handle keyboard shortcuts
        switch (keyData)
        {
            case Keys.Enter when btnConfirm.Enabled:
                btnConfirm.PerformClick();
                return true;
            case Keys.Escape:
                btnCancel.PerformClick();
                return true;
            case Keys.F1: // Exact amount
                if (rbCash.Checked)
                {
                    txtAmountPaid.Texts = TotalAmount.ToString("N2");
                    return true;
                }
                break;
            case Keys.F2: // +100
                if (rbCash.Checked)
                {
                    txtAmountPaid.Texts = (TotalAmount + 100).ToString("N2");
                    return true;
                }
                break;
            case Keys.F3: // +500
                if (rbCash.Checked)
                {
                    txtAmountPaid.Texts = (TotalAmount + 500).ToString("N2");
                    return true;
                }
                break;
            case Keys.F4: // +1000
                if (rbCash.Checked)
                {
                    txtAmountPaid.Texts = (TotalAmount + 1000).ToString("N2");
                    return true;
                }
                break;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
}