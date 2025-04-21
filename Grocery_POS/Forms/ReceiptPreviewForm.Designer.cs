using System.Drawing;
using System.Windows.Forms;
using Grocery_POS.UI;

namespace Grocery_POS.Forms
{
    partial class ReceiptPreviewForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox rtbReceipt;
        private NeoBrutalistButton btnPrint;
        private NeoBrutalistButton btnClose;

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
            this.rtbReceipt = new System.Windows.Forms.RichTextBox();
            this.btnPrint = new NeoBrutalistButton();
            this.btnClose = new NeoBrutalistButton();
            this.SuspendLayout();

            // rtbReceipt
            this.rtbReceipt.BackColor = System.Drawing.Color.White;
            this.rtbReceipt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rtbReceipt.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbReceipt.Location = new System.Drawing.Point(12, 12);
            this.rtbReceipt.Name = "rtbReceipt";
            this.rtbReceipt.ReadOnly = true;
            this.rtbReceipt.Size = new System.Drawing.Size(350, 420);
            this.rtbReceipt.TabIndex = 0;
            this.rtbReceipt.Text = "";
            this.rtbReceipt.Margin = new System.Windows.Forms.Padding(10);

            // btnPrint
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnPrint.BorderColor = System.Drawing.Color.Black;
            this.btnPrint.BorderRadius = 0;
            this.btnPrint.BorderSize = 3;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(12, 444);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(170, 45);
            this.btnPrint.HoverBorderColor = System.Drawing.Color.Black;
            this.btnPrint.OffsetX = 3;
            this.btnPrint.OffsetY = 3;
            this.btnPrint.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.btnPrint.ShadowColor = System.Drawing.Color.Black;
            this.btnPrint.ShadowSize = 3;
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnClose.BorderColor = System.Drawing.Color.Black;
            this.btnClose.BorderRadius = 0;
            this.btnClose.BorderSize = 3;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(192, 444);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(170, 45);
            this.btnClose.HoverBorderColor = System.Drawing.Color.Black;
            this.btnClose.OffsetX = 3;
            this.btnClose.OffsetY = 3;
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.btnClose.ShadowColor = System.Drawing.Color.Black;
            this.btnClose.ShadowSize = 3;
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ReceiptPreviewForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(374, 501);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.rtbReceipt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiptPreviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Receipt Preview";
            this.ResumeLayout(false);
        }
    }
}