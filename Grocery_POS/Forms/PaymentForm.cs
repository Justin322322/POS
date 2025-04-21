using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using Grocery_POS.UI;

namespace Grocery_POS.Forms
{
    public partial class PaymentForm : Form
    {
        // Constants
        private const int DECIMAL_PLACES = 2;
        private const string CURRENCY_SYMBOL = "₱";
        
        // Private fields
        private readonly decimal _totalAmount;
        private decimal _amountPaid;
        private decimal _change;
        private bool _updatingUI; // Guard against recursive events

        // Public properties with validation attributes
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal AmountPaid => _amountPaid;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal Change => _change;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PaymentMethod { get; private set; }

        public PaymentForm(decimal totalAmount)
        {
            InitializeComponent();
            
            // Initialize fields
            _totalAmount = Math.Round(totalAmount, DECIMAL_PLACES);
            PaymentMethod = "Cash";
            
            // Setup form
            ConfigureForm();
            SetupEventHandlers();
        }

        private void ConfigureForm()
        {
            // Form configuration
            KeyPreview = true;
            TopMost = true;
            StartPosition = FormStartPosition.CenterParent;

            // Initialize display
            lblTotalAmount.Text = FormatCurrency(_totalAmount);
            ResetForm();
        }

        private void SetupEventHandlers()
        {
            // Basic form events
            Load += PaymentForm_Load;
            KeyDown += PaymentForm_KeyDown;

            // Payment method events
            rbCash.CheckedChanged += rbCash_CheckedChanged;
            rbCard.CheckedChanged += rbCard_CheckedChanged;

            // Amount input events
            txtAmountPaid.TextChanged += txtAmountPaid_TextChanged;

            // Quick amount buttons
            btnExact.Click += btnExact_Click;
            btnQuick100.Click += btnQuick100_Click;
            btnQuick500.Click += btnQuick500_Click;
            btnQuick1000.Click += btnQuick1000_Click;

            // Action buttons
            btnConfirm.Click += btnConfirm_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private string FormatCurrency(decimal amount)
        {
            return CURRENCY_SYMBOL + amount.ToString("N" + DECIMAL_PLACES, CultureInfo.CurrentCulture);
        }

        private void ResetForm(bool preserveFocus = false)
        {
            if (_updatingUI) return;
            _updatingUI = true;

            try
            {
                bool hadFocus = txtAmountPaid.Focused && preserveFocus;

                // Reset values
                _amountPaid = 0;
                _change = 0;

                // Reset UI
                txtAmountPaid.Texts = string.Empty;
                txtAmountPaid.Text = string.Empty;
                lblChange.Text = FormatCurrency(0);
                UpdateChangeDisplay(0);
                btnConfirm.Enabled = false;

                // Restore focus if needed
                if (hadFocus)
                {
                    txtAmountPaid.Focus();
                    txtAmountPaid.SelectAll();
                }
            }
            finally
            {
                _updatingUI = false;
            }
        }

        private void UpdateChangeDisplay(decimal changeAmount)
        {
            lblChange.Text = FormatCurrency(changeAmount);
            
            if (changeAmount > 0)
            {
                lblChange.ForeColor = Color.Green;
                lblChange.Font = new Font(lblChange.Font.FontFamily, 20, FontStyle.Bold);
            }
            else if (changeAmount < 0)
            {
                lblChange.ForeColor = Color.Red;
                lblChange.Font = new Font(lblChange.Font.FontFamily, 20, FontStyle.Bold);
            }
            else
            {
                lblChange.ForeColor = Color.FromArgb(255, 204, 0);
                lblChange.Font = new Font(lblChange.Font.FontFamily, 20, FontStyle.Regular);
            }
        }

        private bool ValidateAndUpdateAmount(string input, bool preserveFocus = true)
        {
            if (_updatingUI) return false;
            _updatingUI = true;

            try
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    ResetForm(preserveFocus);
                    return false;
                }

                // Clean and parse input
                string cleanedInput = input.Replace(CURRENCY_SYMBOL, "").Trim();
                if (!decimal.TryParse(cleanedInput, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount))
                {
                    // Invalid input - show error state
                    UpdateChangeDisplay(0);
                    btnConfirm.Enabled = false;
                    return false;
                }

                // Update values
                _amountPaid = Math.Round(amount, DECIMAL_PLACES);
                _change = Math.Round(_amountPaid - _totalAmount, DECIMAL_PLACES);

                // Update UI
                UpdateChangeDisplay(_change);
                btnConfirm.Enabled = _amountPaid >= _totalAmount;

                return true;
            }
            finally
            {
                _updatingUI = false;
            }
        }

        private void HandleQuickAmount(decimal amount)
        {
            if (!rbCash.Checked || _updatingUI) return;
            
            try
            {
                _updatingUI = true;
                // Set the exact amount with proper currency formatting
                string formattedAmount = amount.ToString("F" + DECIMAL_PLACES, CultureInfo.InvariantCulture);
                txtAmountPaid.Texts = formattedAmount;
                txtAmountPaid.Text = formattedAmount;
                
                // Update the internal values and UI
                _amountPaid = amount;
                _change = Math.Round(_amountPaid - _totalAmount, DECIMAL_PLACES);
                UpdateChangeDisplay(_change);
                btnConfirm.Enabled = _amountPaid >= _totalAmount;
            }
            finally
            {
                _updatingUI = false;
                txtAmountPaid.Focus();
                txtAmountPaid.SelectAll();
            }
        }

        private void AddToCurrentAmount(decimal amountToAdd)
        {
            if (!rbCash.Checked || _updatingUI) return;

            try
            {
                _updatingUI = true;
                decimal currentAmount = 0;
                
                // Parse current amount, removing currency symbol if present
                string currentText = txtAmountPaid.Texts.Replace(CURRENCY_SYMBOL, "").Trim();
                if (!string.IsNullOrWhiteSpace(currentText))
                {
                    decimal.TryParse(currentText, NumberStyles.Any, CultureInfo.InvariantCulture, out currentAmount);
                }

                // Calculate new amount and format it
                decimal newAmount = currentAmount + amountToAdd;
                string formattedAmount = newAmount.ToString("F" + DECIMAL_PLACES, CultureInfo.InvariantCulture);
                
                // Update both Text and Texts properties of the custom textbox
                txtAmountPaid.Texts = formattedAmount;
                txtAmountPaid.Text = formattedAmount;
                
                // Update internal values and UI
                _amountPaid = newAmount;
                _change = Math.Round(_amountPaid - _totalAmount, DECIMAL_PLACES);
                UpdateChangeDisplay(_change);
                btnConfirm.Enabled = _amountPaid >= _totalAmount;
            }
            finally
            {
                _updatingUI = false;
                txtAmountPaid.Focus();
                txtAmountPaid.SelectAll();
            }
        }

        private void EnableCashControls(bool enable)
        {
            txtAmountPaid.Enabled = enable;
            lblChange.Enabled = enable;
            lblChangeLabel.Enabled = enable;
            panelQuickButtons.Enabled = enable;
            
            foreach (Control control in panelQuickButtons.Controls)
            {
                if (control is Button)
                {
                    control.Enabled = enable;
                }
            }
        }

        // Event Handlers
        private void txtAmountPaid_TextChanged(object? sender, EventArgs e)
        {
            if (_updatingUI) return;

            try
            {
                _updatingUI = true;
                int cursorPosition = txtAmountPaid.SelectionStart;
                
                // Clean and parse the input
                string cleanedInput = txtAmountPaid.Texts.Replace(CURRENCY_SYMBOL, "").Trim();
                if (decimal.TryParse(cleanedInput, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount))
                {
                    _amountPaid = Math.Round(amount, DECIMAL_PLACES);
                    _change = Math.Round(_amountPaid - _totalAmount, DECIMAL_PLACES);
                    UpdateChangeDisplay(_change);
                    btnConfirm.Enabled = _amountPaid >= _totalAmount;
                }
                else
                {
                    _amountPaid = 0;
                    _change = -_totalAmount;
                    UpdateChangeDisplay(_change);
                    btnConfirm.Enabled = false;
                }

                if (txtAmountPaid.Focused)
                {
                    txtAmountPaid.SelectionStart = Math.Min(cursorPosition, txtAmountPaid.Text.Length);
                    txtAmountPaid.SelectionLength = 0;
                }
            }
            finally
            {
                _updatingUI = false;
            }
        }

        private void rbCash_CheckedChanged(object? sender, EventArgs e)
        {
            if (rbCash.Checked)
            {
                PaymentMethod = "Cash";
                EnableCashControls(true);
                ResetForm();
                BeginInvoke(() => txtAmountPaid.Focus());
            }
        }

        private void rbCard_CheckedChanged(object? sender, EventArgs e)
        {
            if (rbCard.Checked)
            {
                PaymentMethod = "Card";
                EnableCashControls(false);
                
                _amountPaid = _totalAmount;
                _change = 0;
                
                string formattedAmount = _totalAmount.ToString("F" + DECIMAL_PLACES, CultureInfo.InvariantCulture);
                txtAmountPaid.Texts = formattedAmount;
                txtAmountPaid.Text = formattedAmount;
                
                UpdateChangeDisplay(0);
                btnConfirm.Enabled = true;
                btnConfirm.Focus();
            }
        }

        private void btnExact_Click(object? sender, EventArgs e)
        {
            HandleQuickAmount(_totalAmount);
        }

        private void btnQuick100_Click(object? sender, EventArgs e)
        {
            AddToCurrentAmount(100m);
        }

        private void btnQuick500_Click(object? sender, EventArgs e)
        {
            AddToCurrentAmount(500m);
        }

        private void btnQuick1000_Click(object? sender, EventArgs e)
        {
            AddToCurrentAmount(1000m);
        }

        private void btnConfirm_Click(object? sender, EventArgs e)
        {
            try
            {
                if (PaymentMethod == "Cash" && _amountPaid < _totalAmount)
                {
                    MessageBox.Show(
                        "Insufficient amount paid.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    txtAmountPaid.Focus();
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error processing payment: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PaymentForm_Load(object? sender, EventArgs e)
        {
            rbCash.Checked = true;
            ResetForm(true);
            txtAmountPaid.Focus();
        }

        private void PaymentForm_KeyDown(object? sender, KeyEventArgs e)
        {
            // Always handle Escape
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = e.SuppressKeyPress = true;
                btnCancel.PerformClick();
                return;
            }

            // Handle Enter when confirm is enabled
            if (e.KeyCode == Keys.Enter && btnConfirm.Enabled)
            {
                return; // Let ProcessCmdKey handle this
            }

            // Only process shortcuts for cash payment
            if (!rbCash.Checked) return;

            switch (e.KeyCode)
            {
                case Keys.F1:
                    e.Handled = e.SuppressKeyPress = true;
                    btnExact.PerformClick();
                    break;
                case Keys.F2:
                    e.Handled = e.SuppressKeyPress = true;
                    btnQuick100.PerformClick();
                    break;
                case Keys.F3:
                    e.Handled = e.SuppressKeyPress = true;
                    btnQuick500.PerformClick();
                    break;
                case Keys.F4:
                    e.Handled = e.SuppressKeyPress = true;
                    btnQuick1000.PerformClick();
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && btnConfirm.Enabled)
            {
                btnConfirm.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
