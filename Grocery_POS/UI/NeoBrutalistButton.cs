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
    public class NeoBrutalistButton : Button
    {
        // Fields
        private int borderSize = 3;
        private int borderRadius = 0;
        private Color borderColor = Color.FromArgb(0, 0, 0);
        private Color hoverBorderColor = Color.FromArgb(0, 120, 215);
        private int shadowSize = 5;
        private Color shadowColor = Color.FromArgb(128, 128, 128);
        private int offsetX = 5;
        private int offsetY = 5;

        // Properties
        [Category("Neo Brutalist")]
        [DefaultValue(3)]
        [Description("Border size of the button")]
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
        [Description("Border radius of the button")]
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
        [Description("Border color of the button")]
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
        [Description("Border color when hovering over the button")]
        [TypeConverter(typeof(System.Drawing.ColorConverter))]
        [Editor("System.Drawing.Design.ColorEditor, System.Drawing.Design", typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color HoverBorderColor
        {
            get => hoverBorderColor;
            set
            {
                hoverBorderColor = value;
                Invalidate();
            }
        }

        [Category("Neo Brutalist")]
        [DefaultValue(5)]
        [Description("Shadow size of the button")]
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
        [Description("Shadow color of the button")]
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
        public NeoBrutalistButton()
        {
            FlatStyle = FlatStyle.Standard;
            FlatAppearance.BorderSize = 0;
            Size = new Size(150, 45);
            BackColor = Color.White;
            ForeColor = Color.Black;
            borderColor = Color.Black;
            shadowColor = Color.FromArgb(128, 128, 128);
            hoverBorderColor = Color.FromArgb(0, 120, 215);
            Font = new Font("Segoe UI", 12, FontStyle.Bold);
            Cursor = Cursors.Hand;
            UseVisualStyleBackColor = false;

            // Set padding to accommodate shadow
            Padding = new Padding(0, 0, offsetX, offsetY);
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

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = new Rectangle(0, 0, Width - offsetX, Height - offsetY);
            Rectangle rectBorder = new Rectangle(0, 0, Width - offsetX - 1, Height - offsetY - 1);

            // Draw shadow
            using (SolidBrush shadowBrush = new SolidBrush(shadowColor))
            {
                pevent.Graphics.FillRectangle(shadowBrush, offsetX, offsetY, Width - offsetX, Height - offsetY);
            }

            using (SolidBrush brushSurface = new SolidBrush(BackColor))
            using (SolidBrush brushText = new SolidBrush(ForeColor))
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                if (borderRadius > 0) // Rounded button
                {
                    using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                    using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
                    using (Pen penSurface = new Pen(Parent.BackColor, 2))
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;

                        // Button surface
                        Region = new Region(pathSurface);
                        pevent.Graphics.FillPath(brushSurface, pathSurface);

                        // Draw surface border for HD result
                        pevent.Graphics.DrawPath(penSurface, pathSurface);

                        // Button border
                        if (borderSize >= 1)
                            pevent.Graphics.DrawPath(penBorder, pathBorder);

                        // Draw text
                        pevent.Graphics.DrawString(Text, Font, brushText, rectSurface, sf);
                    }
                }
                else // Normal button
                {
                    // Button surface
                    Region = new Region(rectSurface);
                    pevent.Graphics.FillRectangle(brushSurface, rectSurface);

                    // Button border
                    if (borderSize >= 1)
                    {
                        using (Pen penBorder = new Pen(borderColor, borderSize))
                        {
                            penBorder.Alignment = PenAlignment.Inset;
                            pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - offsetX - 1, Height - offsetY - 1);
                        }
                    }

                    // Draw text
                    pevent.Graphics.DrawString(Text, Font, brushText, rectSurface, sf);
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

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            // Only change the border color on hover, not the background color
            borderColor = hoverBorderColor;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            // Restore original border color
            borderColor = BorderColor;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            offsetX = 2;
            offsetY = 2;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            offsetX = 5;
            offsetY = 5;
            Invalidate();
        }
    }
}
