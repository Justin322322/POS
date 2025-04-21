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
    public class NeoBrutalistPanel : Panel
    {
        // Fields
        private int borderSize = 3;
        private int borderRadius = 0;
        private Color borderColor = Color.FromArgb(0, 0, 0);
        private int shadowSize = 5;
        private Color shadowColor = Color.FromArgb(128, 128, 128);
        private int offsetX = 5;
        private int offsetY = 5;

        // Properties
        [Category("Neo Brutalist")]
        [DefaultValue(3)]
        [Description("Border size of the panel")]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        [Category("Neo Brutalist")]
        [DefaultValue(0)]
        [Description("Border radius of the panel")]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        [Category("Neo Brutalist")]
        [Description("Border color of the panel")]
        [TypeConverter(typeof(System.Drawing.ColorConverter))]
        [Editor("System.Drawing.Design.ColorEditor, System.Drawing.Design", typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Category("Neo Brutalist")]
        [DefaultValue(5)]
        [Description("Shadow size of the panel")]
        public int ShadowSize
        {
            get => shadowSize;
            set
            {
                shadowSize = value;
                Invalidate();
            }
        }

        [Category("Neo Brutalist")]
        [Description("Shadow color of the panel")]
        [TypeConverter(typeof(System.Drawing.ColorConverter))]
        [Editor("System.Drawing.Design.ColorEditor, System.Drawing.Design", typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ShadowColor
        {
            get => shadowColor;
            set
            {
                shadowColor = value;
                Invalidate();
            }
        }

        [Category("Neo Brutalist")]
        [DefaultValue(5)]
        [Description("X offset of the shadow")]
        public int OffsetX
        {
            get => offsetX;
            set
            {
                offsetX = value;
                Invalidate();
            }
        }

        [Category("Neo Brutalist")]
        [DefaultValue(5)]
        [Description("Y offset of the shadow")]
        public int OffsetY
        {
            get => offsetY;
            set
            {
                offsetY = value;
                Invalidate();
            }
        }

        // Constructor
        public NeoBrutalistPanel()
        {
            Size = new Size(200, 200);
            BackColor = Color.FromArgb(255, 255, 255);
            Padding = new Padding(borderSize);
        }

        // Methods
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = new Rectangle(0, 0, Width, Height);
            Rectangle rectBorder = new Rectangle(0, 0, Width - 1, Height - 1);

            // Draw shadow
            using (SolidBrush shadowBrush = new SolidBrush(shadowColor))
            {
                e.Graphics.FillRectangle(shadowBrush, offsetX, offsetY, Width - offsetX, Height - offsetY);
            }

            if (borderRadius > 0) // Rounded panel
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;

                    // Panel surface
                    Region = new Region(pathSurface);

                    // Draw surface border for HD result
                    e.Graphics.DrawPath(penSurface, pathSurface);

                    // Panel border
                    if (borderSize >= 1)
                        e.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else // Normal panel
            {
                // Panel surface
                Region = new Region(rectSurface);

                // Panel border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (DesignMode)
                Invalidate();
        }
    }
}
