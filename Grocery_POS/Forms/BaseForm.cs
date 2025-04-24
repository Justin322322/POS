using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Grocery_POS.UI;

namespace Grocery_POS.Forms
{
    /// <summary>
    /// Base form class that applies consistent styling to all forms
    /// </summary>
    public class BaseForm : Form
    {
        public BaseForm()
        {
            // Set default form properties
            this.BackColor = UITheme.Background;
            this.Font = UITheme.BodyFont;
            this.ForeColor = UITheme.TextPrimary;
            this.FormBorderStyle = FormBorderStyle.None;

            // Apply background color to all controls
            foreach (Control control in this.Controls)
            {
                if (!(control is NeoBrutalistPanel))
                {
                    control.BackColor = UITheme.Background;
                }
            }

            // Handle form load to apply theme to all controls
            this.Load += BaseForm_Load;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            ApplyThemeToControls(this.Controls);
        }

        /// <summary>
        /// Recursively applies theme to all controls in the form
        /// </summary>
        protected void ApplyThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Set background color for all controls except panels
                if (!(control is NeoBrutalistPanel) &&
                    !(control is NeoBrutalistButton) &&
                    !(control is DataGridView) &&
                    !(control is Chart))
                {
                    control.BackColor = UITheme.PanelBackground;
                }

                // Apply theme based on control type
                if (control is NeoBrutalistPanel panel)
                {
                    UITheme.ApplyToPanelPrimary(panel);
                }
                else if (control is NeoBrutalistButton button)
                {
                    UITheme.ApplyToButtonPrimary(button);
                }
                else if (control is DataGridView dgv)
                {
                    UITheme.ApplyToDataGridView(dgv);
                }
                else if (control is Label label)
                {
                    if (label.Font.Size >= 12)
                    {
                        label.Font = UITheme.SubheadingFont;
                    }
                    else
                    {
                        label.Font = UITheme.BodyFont;
                    }
                    label.ForeColor = UITheme.TextPrimary;

                    // Make sure label background matches parent
                    label.BackColor = control.Parent.BackColor;

                    // Remove any border or 3D effects
                    label.BorderStyle = BorderStyle.None;
                    label.FlatStyle = FlatStyle.Flat;
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = UITheme.PanelBackground;
                    textBox.ForeColor = UITheme.TextPrimary;
                    textBox.Font = UITheme.BodyFont;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = UITheme.PanelBackground;
                    comboBox.ForeColor = UITheme.TextPrimary;
                    comboBox.Font = UITheme.BodyFont;
                }
                else if (control is DateTimePicker dtp)
                {
                    dtp.Font = UITheme.BodyFont;
                    dtp.CalendarForeColor = UITheme.TextPrimary;
                    dtp.CalendarMonthBackground = UITheme.PanelBackground;
                    dtp.CalendarTitleBackColor = UITheme.Primary;
                    dtp.CalendarTitleForeColor = UITheme.TextLight;
                }
                else if (control is Chart chart)
                {
                    UITheme.ApplyToChart(chart);
                }

                // Recursively apply theme to child controls
                if (control.Controls.Count > 0)
                {
                    ApplyThemeToControls(control.Controls);
                }
            }
        }
    }
}
