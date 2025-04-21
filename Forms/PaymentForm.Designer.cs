namespace PaymentApp
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.RadioButton rbCard;
        private System.Windows.Forms.Label label8;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.rbCard = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            // Configure Amount Paid TextBox
            this.txtAmountPaid.PlaceholderText = "Enter amount";
            this.txtAmountPaid.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAmountPaid.Size = new System.Drawing.Size(249, 40);
            
            // Configure Total Amount Label
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            
            // Configure Change Label
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            
            // Configure payment method buttons
            this.rbCash.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbCard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            
            // Add keyboard shortcut hints
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(12, 350);
            this.label8.Text = "Shortcuts: F1=Exact | F2=+100 | F3=+500 | F4=+1000 | Enter=Confirm | Esc=Cancel";
            this.Controls.Add(this.label8);
            
            this.ResumeLayout(false);
        }
    }
}