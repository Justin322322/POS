using Grocery_POS.UI;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Windows.Forms;

namespace Grocery_POS.Forms
{
    partial class ReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelFilter = new NeoBrutalistPanel();
            btnPrintPreview = new NeoBrutalistButton();
            btnGenerateReport = new NeoBrutalistButton();
            dtpEndDate = new DateTimePicker();
            label3 = new Label();
            dtpStartDate = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            panelSummary = new NeoBrutalistPanel();
            lblAvgTransaction = new Label();
            label7 = new Label();
            lblTotalTransactions = new Label();
            label5 = new Label();
            lblTotalSales = new Label();
            label4 = new Label();
            panelTopProducts = new NeoBrutalistPanel();
            dgvTopProducts = new DataGridView();
            label6 = new Label();
            panelPaymentMethods = new NeoBrutalistPanel();
            dgvPaymentMethods = new DataGridView();
            label8 = new Label();
            panelChart = new NeoBrutalistPanel();
            label9 = new Label();
            panelFilter.SuspendLayout();
            panelSummary.SuspendLayout();
            panelTopProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).BeginInit();
            panelPaymentMethods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPaymentMethods).BeginInit();
            panelChart.SuspendLayout();
            SuspendLayout();
            //
            // panelFilter
            //
            panelFilter.BackColor = Color.White;
            panelFilter.BorderColor = Color.Black;
            panelFilter.Controls.Add(btnPrintPreview);
            panelFilter.Controls.Add(btnGenerateReport);
            panelFilter.Controls.Add(dtpEndDate);
            panelFilter.Controls.Add(label3);
            panelFilter.Controls.Add(dtpStartDate);
            panelFilter.Controls.Add(label2);
            panelFilter.Controls.Add(label1);
            panelFilter.Location = new Point(12, 12);
            panelFilter.Name = "panelFilter";
            panelFilter.Padding = new Padding(10);
            panelFilter.ShadowColor = Color.LightGray;
            panelFilter.Size = new Size(1036, 64);
            panelFilter.TabIndex = 0;
            //
            // btnPrintPreview
            //
            btnPrintPreview.BackColor = Color.FromArgb(0, 153, 51);
            btnPrintPreview.BorderColor = Color.Black;
            btnPrintPreview.FlatAppearance.BorderSize = 0;
            btnPrintPreview.FlatStyle = FlatStyle.Flat;
            btnPrintPreview.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnPrintPreview.ForeColor = Color.White;
            btnPrintPreview.HoverBorderColor = Color.Black;
            btnPrintPreview.Location = new Point(670, 15);
            btnPrintPreview.Name = "btnPrintPreview";
            btnPrintPreview.OffsetX = 3;
            btnPrintPreview.OffsetY = 3;
            btnPrintPreview.Padding = new Padding(0, 0, 3, 3);
            btnPrintPreview.ShadowColor = Color.Black;
            btnPrintPreview.ShadowSize = 3;
            btnPrintPreview.Size = new Size(150, 35);
            btnPrintPreview.TabIndex = 6;
            btnPrintPreview.Text = "PRINT PREVIEW";
            btnPrintPreview.UseVisualStyleBackColor = false;
            btnPrintPreview.Click += btnPrintPreview_Click;
            //
            // btnGenerateReport
            //
            btnGenerateReport.BackColor = Color.FromArgb(0, 122, 204);
            btnGenerateReport.BorderColor = Color.Black;
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.HoverBorderColor = Color.Black;
            btnGenerateReport.Location = new Point(500, 15);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.OffsetX = 3;
            btnGenerateReport.OffsetY = 3;
            btnGenerateReport.Padding = new Padding(0, 0, 3, 3);
            btnGenerateReport.ShadowColor = Color.Black;
            btnGenerateReport.ShadowSize = 3;
            btnGenerateReport.Size = new Size(150, 35);
            btnGenerateReport.TabIndex = 5;
            btnGenerateReport.Text = "GENERATE REPORT";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
            //
            // dtpEndDate
            //
            dtpEndDate.Font = new Font("Segoe UI", 9.75F);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(370, 20);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(120, 25);
            dtpEndDate.TabIndex = 4;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.BackColor = Color.LightGray;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(300, 24);
            label3.Name = "label3";
            label3.Size = new Size(64, 17);
            label3.TabIndex = 3;
            label3.Text = "End Date";
            //
            // dtpStartDate
            //
            dtpStartDate.Font = new Font("Segoe UI", 9.75F);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(170, 20);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(120, 25);
            dtpStartDate.TabIndex = 2;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.BackColor = Color.LightGray;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(95, 24);
            label2.Name = "label2";
            label2.Size = new Size(70, 17);
            label2.TabIndex = 1;
            label2.Text = "Start Date";
            //
            // label1
            //
            label1.AutoSize = true;
            label1.BackColor = Color.LightGray;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(15, 20);
            label1.Name = "label1";
            label1.Size = new Size(76, 21);
            label1.TabIndex = 0;
            label1.Text = "Filter by:";
            //
            // panelSummary
            //
            panelSummary.BackColor = Color.White;
            panelSummary.BorderColor = Color.Black;
            panelSummary.Controls.Add(lblAvgTransaction);
            panelSummary.Controls.Add(label7);
            panelSummary.Controls.Add(lblTotalTransactions);
            panelSummary.Controls.Add(label5);
            panelSummary.Controls.Add(lblTotalSales);
            panelSummary.Controls.Add(label4);
            panelSummary.Location = new Point(12, 82);
            panelSummary.Name = "panelSummary";
            panelSummary.Padding = new Padding(15);
            panelSummary.ShadowColor = Color.LightGray;
            panelSummary.Size = new Size(1036, 100);
            panelSummary.TabIndex = 1;
            //
            // lblAvgTransaction
            //
            lblAvgTransaction.AutoSize = true;
            lblAvgTransaction.BackColor = Color.LightGray;
            lblAvgTransaction.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvgTransaction.Location = new Point(691, 38);
            lblAvgTransaction.Name = "lblAvgTransaction";
            lblAvgTransaction.Size = new Size(93, 40);
            lblAvgTransaction.TabIndex = 5;
            lblAvgTransaction.Text = "$0.00";
            //
            // label7
            //
            label7.AutoSize = true;
            label7.BackColor = Color.LightGray;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(650, 15);
            label7.Name = "label7";
            label7.Size = new Size(165, 21);
            label7.TabIndex = 4;
            label7.Text = "Average Transaction";
            //
            // lblTotalTransactions
            //
            lblTotalTransactions.AutoSize = true;
            lblTotalTransactions.BackColor = Color.LightGray;
            lblTotalTransactions.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lblTotalTransactions.Location = new Point(402, 38);
            lblTotalTransactions.Name = "lblTotalTransactions";
            lblTotalTransactions.Size = new Size(34, 40);
            lblTotalTransactions.TabIndex = 3;
            lblTotalTransactions.Text = "0";
            //
            // label5
            //
            label5.AutoSize = true;
            label5.BackColor = Color.LightGray;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(350, 15);
            label5.Name = "label5";
            label5.Size = new Size(147, 21);
            label5.TabIndex = 2;
            label5.Text = "Total Transactions";
            //
            // lblTotalSales
            //
            lblTotalSales.AutoSize = true;
            lblTotalSales.BackColor = Color.LightGray;
            lblTotalSales.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lblTotalSales.Location = new Point(50, 38);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(93, 40);
            lblTotalSales.TabIndex = 1;
            lblTotalSales.Text = "$0.00";
            //
            // label4
            //
            label4.AutoSize = true;
            label4.BackColor = Color.LightGray;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(50, 15);
            label4.Name = "label4";
            label4.Size = new Size(91, 21);
            label4.TabIndex = 0;
            label4.Text = "Total Sales";
            //
            // panelTopProducts
            //
            panelTopProducts.BackColor = Color.White;
            panelTopProducts.BorderColor = Color.Black;
            panelTopProducts.Controls.Add(dgvTopProducts);
            panelTopProducts.Controls.Add(label6);
            panelTopProducts.Location = new Point(12, 192);
            panelTopProducts.Name = "panelTopProducts";
            panelTopProducts.Padding = new Padding(15);
            panelTopProducts.ShadowColor = Color.Black;
            panelTopProducts.Size = new Size(514, 253);
            panelTopProducts.TabIndex = 2;
            //
            // dgvTopProducts
            //
            dgvTopProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopProducts.Location = new Point(15, 50);
            dgvTopProducts.Name = "dgvTopProducts";
            dgvTopProducts.Size = new Size(481, 185);
            dgvTopProducts.TabIndex = 1;
            //
            // label6
            //
            label6.AutoSize = true;
            label6.BackColor = Color.Black;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.Yellow;
            label6.Location = new Point(15, 15);
            label6.Name = "label6";
            label6.Size = new Size(109, 21);
            label6.TabIndex = 0;
            label6.Text = "Top Products";
            //
            // panelPaymentMethods
            //
            panelPaymentMethods.BackColor = Color.White;
            panelPaymentMethods.BorderColor = Color.Black;
            panelPaymentMethods.Controls.Add(dgvPaymentMethods);
            panelPaymentMethods.Controls.Add(label8);
            panelPaymentMethods.Location = new Point(532, 192);
            panelPaymentMethods.Name = "panelPaymentMethods";
            panelPaymentMethods.Padding = new Padding(15);
            panelPaymentMethods.ShadowColor = Color.Black;
            panelPaymentMethods.Size = new Size(516, 253);
            panelPaymentMethods.TabIndex = 3;
            //
            // dgvPaymentMethods
            //
            dgvPaymentMethods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPaymentMethods.Location = new Point(15, 50);
            dgvPaymentMethods.Name = "dgvPaymentMethods";
            dgvPaymentMethods.Size = new Size(483, 185);
            dgvPaymentMethods.TabIndex = 1;
            //
            // label8
            //
            label8.AutoSize = true;
            label8.BackColor = Color.Black;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.ForeColor = Color.Yellow;
            label8.Location = new Point(15, 15);
            label8.Name = "label8";
            label8.Size = new Size(149, 21);
            label8.TabIndex = 0;
            label8.Text = "Payment Methods";
            //
            // panelChart
            //
            panelChart.BackColor = Color.White;
            panelChart.BorderColor = Color.Black;
            panelChart.Controls.Add(label9);
            panelChart.Location = new Point(12, 451);
            panelChart.Name = "panelChart";
            panelChart.Padding = new Padding(15);
            panelChart.ShadowColor = Color.Black;
            panelChart.Size = new Size(1036, 296);
            panelChart.TabIndex = 4;
            //
            // label9
            //
            label9.AutoSize = true;
            label9.BackColor = Color.Black;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.ForeColor = Color.Yellow;
            label9.Location = new Point(15, 15);
            label9.Name = "label9";
            label9.Size = new Size(93, 21);
            label9.TabIndex = 0;
            label9.Text = "Daily Sales";
            //
            // ReportsForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 204, 0);
            ClientSize = new Size(1060, 759);
            Controls.Add(panelChart);
            Controls.Add(panelPaymentMethods);
            Controls.Add(panelTopProducts);
            Controls.Add(panelSummary);
            Controls.Add(panelFilter);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportsForm";
            Text = "Reports";
            Load += ReportsForm_Load;
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            panelTopProducts.ResumeLayout(false);
            panelTopProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).EndInit();
            panelPaymentMethods.ResumeLayout(false);
            panelPaymentMethods.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPaymentMethods).EndInit();
            panelChart.ResumeLayout(false);
            panelChart.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private NeoBrutalistPanel panelFilter;
        private Label label1;
        private DateTimePicker dtpStartDate;
        private Label label2;
        private DateTimePicker dtpEndDate;
        private Label label3;
        private NeoBrutalistButton btnGenerateReport;
        private NeoBrutalistButton btnPrintPreview;
        private NeoBrutalistPanel panelSummary;
        private Label label4;
        private Label lblTotalSales;
        private Label lblTotalTransactions;
        private Label label5;
        private Label lblAvgTransaction;
        private Label label7;
        private NeoBrutalistPanel panelTopProducts;
        private DataGridView dgvTopProducts;
        private Label label6;
        private NeoBrutalistPanel panelPaymentMethods;
        private DataGridView dgvPaymentMethods;
        private Label label8;
        private NeoBrutalistPanel panelChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales;
        private Label label9;
    }
}
