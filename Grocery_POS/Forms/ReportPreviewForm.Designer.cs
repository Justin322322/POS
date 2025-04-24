using System.Drawing;
using System.Windows.Forms;
using Grocery_POS.UI;

namespace Grocery_POS.Forms
{
    partial class ReportPreviewForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox rtbReport;
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
            this.rtbReport = new System.Windows.Forms.RichTextBox();
            this.btnPrint = new NeoBrutalistButton();
            this.btnClose = new NeoBrutalistButton();
            this.SuspendLayout();

            // rtbReport
            this.rtbReport.BackColor = System.Drawing.Color.White;
            this.rtbReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rtbReport.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbReport.Location = new System.Drawing.Point(12, 12);
            this.rtbReport.Name = "rtbReport";
            this.rtbReport.ReadOnly = true;
            this.rtbReport.Size = new System.Drawing.Size(560, 520);
            this.rtbReport.TabIndex = 0;
            this.rtbReport.Text = "";
            this.rtbReport.Margin = new System.Windows.Forms.Padding(10);

            // btnPrint
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnPrint.BorderColor = System.Drawing.Color.Black;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.HoverBorderColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(12, 538);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.OffsetX = 3;
            this.btnPrint.OffsetY = 3;
            this.btnPrint.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.btnPrint.ShadowColor = System.Drawing.Color.Black;
            this.btnPrint.ShadowSize = 3;
            this.btnPrint.Size = new System.Drawing.Size(150, 40);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print Report";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(204, 0, 0);
            this.btnClose.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverBorderColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(422, 538);
            this.btnClose.Name = "btnClose";
            this.btnClose.OffsetX = 3;
            this.btnClose.OffsetY = 3;
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.btnClose.ShadowColor = System.Drawing.Color.Black;
            this.btnClose.ShadowSize = 3;
            this.btnClose.Size = new System.Drawing.Size(150, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ReportPreviewForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 204, 0);
            this.ClientSize = new System.Drawing.Size(584, 590);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.rtbReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportPreviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report Preview";
            this.ResumeLayout(false);
        }
    }
}
