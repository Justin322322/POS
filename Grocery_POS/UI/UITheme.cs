using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Grocery_POS.UI
{
    /// <summary>
    /// Centralized theme class for the application UI
    /// </summary>
    public static class UITheme
    {
        // Primary colors
        public static Color Primary = Color.FromArgb(66, 139, 202);      // Blue
        public static Color PrimaryDark = Color.FromArgb(51, 122, 183);  // Darker blue
        public static Color PrimaryLight = Color.FromArgb(173, 216, 230); // Light blue

        // Secondary colors
        public static Color Secondary = Color.FromArgb(255, 193, 7);     // Amber/Yellow
        public static Color SecondaryDark = Color.FromArgb(227, 165, 0); // Darker amber
        public static Color SecondaryLight = Color.FromArgb(255, 222, 125); // Light amber

        // Neutral colors
        public static Color Background = Color.FromArgb(173, 216, 230);  // Light blue background
        public static Color Surface = Color.FromArgb(173, 216, 230);     // Light blue surface (same as background)
        public static Color PanelBackground = Color.FromArgb(173, 216, 230); // Light blue panel background
        public static Color Border = Color.FromArgb(135, 206, 235);      // Slightly darker blue border
        public static Color BorderDark = Color.FromArgb(70, 130, 180);   // Steel blue border

        // Text colors
        public static Color TextPrimary = Color.FromArgb(33, 37, 41);    // Dark gray, almost black
        public static Color TextSecondary = Color.FromArgb(108, 117, 125); // Medium gray
        public static Color TextLight = Color.White;                     // White text

        // Status colors
        public static Color Success = Color.FromArgb(40, 167, 69);       // Green
        public static Color Danger = Color.FromArgb(220, 53, 69);        // Red
        public static Color Warning = Color.FromArgb(255, 193, 7);       // Amber/Yellow
        public static Color Info = Color.FromArgb(23, 162, 184);         // Cyan

        // Font settings
        public static Font HeadingFont = new Font("Segoe UI", 14, FontStyle.Bold);
        public static Font SubheadingFont = new Font("Segoe UI", 12, FontStyle.Bold);
        public static Font BodyFont = new Font("Segoe UI", 10, FontStyle.Regular);
        public static Font ButtonFont = new Font("Segoe UI", 10, FontStyle.Bold);
        public static Font SmallFont = new Font("Segoe UI", 8, FontStyle.Regular);

        // Apply theme to a NeoBrutalistPanel
        public static void ApplyToPanelPrimary(NeoBrutalistPanel panel)
        {
            panel.BackColor = PanelBackground;
            panel.BorderColor = Primary;
            panel.BorderSize = 1;
            panel.ShadowColor = PrimaryDark;
            panel.ShadowSize = 2;
            panel.OffsetX = 2;
            panel.OffsetY = 2;
        }

        public static void ApplyToPanelSecondary(NeoBrutalistPanel panel)
        {
            panel.BackColor = PanelBackground;
            panel.BorderColor = Secondary;
            panel.BorderSize = 1;
            panel.ShadowColor = SecondaryDark;
            panel.ShadowSize = 2;
            panel.OffsetX = 2;
            panel.OffsetY = 2;
        }

        // Apply theme to a NeoBrutalistButton
        public static void ApplyToButtonPrimary(NeoBrutalistButton button)
        {
            button.BackColor = Primary;
            button.ForeColor = TextLight;
            button.BorderColor = PrimaryDark;
            button.HoverBorderColor = PrimaryLight;
            button.ShadowColor = PrimaryDark;
            button.ShadowSize = 3;
            button.OffsetX = 2;
            button.OffsetY = 2;
            button.Font = ButtonFont;
        }

        public static void ApplyToButtonSecondary(NeoBrutalistButton button)
        {
            button.BackColor = Secondary;
            button.ForeColor = TextPrimary;
            button.BorderColor = SecondaryDark;
            button.HoverBorderColor = SecondaryLight;
            button.ShadowColor = SecondaryDark;
            button.ShadowSize = 3;
            button.OffsetX = 2;
            button.OffsetY = 2;
            button.Font = ButtonFont;
        }

        // Apply theme to a DataGridView
        public static void ApplyToDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = PanelBackground;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Border;
            dgv.DefaultCellStyle.BackColor = PanelBackground;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.SelectionBackColor = Primary;
            dgv.DefaultCellStyle.SelectionForeColor = TextLight;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Primary;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextLight;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(BodyFont, FontStyle.Bold);
            dgv.RowHeadersDefaultCellStyle.BackColor = PanelBackground;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(190, 225, 235); // Slightly different shade for alternating rows
            dgv.EnableHeadersVisualStyles = false;
        }

        // Apply theme to a Chart
        public static void ApplyToChart(Chart chart)
        {
            chart.BackColor = PanelBackground;
            chart.BorderlineColor = Border;
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineWidth = 1;

            // Apply to chart areas
            foreach (ChartArea area in chart.ChartAreas)
            {
                area.BackColor = PanelBackground;
                area.BorderColor = Border;
                area.BorderWidth = 1;
                area.AxisX.LineColor = BorderDark;
                area.AxisY.LineColor = BorderDark;
                area.AxisX.LabelStyle.ForeColor = TextPrimary;
                area.AxisY.LabelStyle.ForeColor = TextPrimary;
                area.AxisX.MajorGrid.LineColor = Border;
                area.AxisY.MajorGrid.LineColor = Border;
                area.AxisX.MajorTickMark.LineColor = BorderDark;
                area.AxisY.MajorTickMark.LineColor = BorderDark;
            }

            // Apply to series
            foreach (Series series in chart.Series)
            {
                if (series.Name.Contains("Sales") || series.Name.Contains("Revenue"))
                {
                    series.Color = Primary;
                }
                else if (series.Name.Contains("Profit"))
                {
                    series.Color = Success;
                }
                else if (series.Name.Contains("Loss"))
                {
                    series.Color = Danger;
                }
                else
                {
                    series.Color = Secondary;
                }
            }

            // Apply to titles
            foreach (Title title in chart.Titles)
            {
                title.ForeColor = TextPrimary;
                title.Font = SubheadingFont;
            }

            // Apply to legends
            foreach (Legend legend in chart.Legends)
            {
                legend.BackColor = PanelBackground;
                legend.ForeColor = TextPrimary;
                legend.BorderColor = Border;
            }
        }
    }
}
