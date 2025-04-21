using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grocery_POS.UI
{
    public class DottedBackgroundPanel : Panel
    {
        private Color dotColor = Color.Black;
        private int dotSize = 2;
        private int dotSpacing = 20;

        [Category("Neo Brutalist")]
        [Description("Color of the dots")]
        [TypeConverter(typeof(System.Drawing.ColorConverter))]
        [Editor("System.Drawing.Design.ColorEditor, System.Drawing.Design", typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color DotColor
        {
            get => dotColor;
            set
            {
                dotColor = value;
                Invalidate();
            }
        }

        [Category("Neo Brutalist")]
        [DefaultValue(2)]
        [Description("Size of the dots")]
        public int DotSize
        {
            get => dotSize;
            set
            {
                dotSize = value;
                Invalidate();
            }
        }

        [Category("Neo Brutalist")]
        [DefaultValue(20)]
        [Description("Spacing between dots")]
        public int DotSpacing
        {
            get => dotSpacing;
            set
            {
                dotSpacing = value;
                Invalidate();
            }
        }

        public DottedBackgroundPanel()
        {
            DoubleBuffered = true;
            BackColor = Color.FromArgb(245, 245, 245); // Light neutral background for better contrast
            dotColor = Color.FromArgb(0, 120, 215); // Blue accent dots for a modern, cohesive look
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            // Draw dots
            using (SolidBrush brush = new SolidBrush(dotColor))
            {
                for (int x = 0; x < Width; x += dotSpacing)
                {
                    for (int y = 0; y < Height; y += dotSpacing)
                    {
                        e.Graphics.FillEllipse(brush, x, y, dotSize, dotSize);
                    }
                }
            }
        }
    }
}
