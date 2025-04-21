#nullable enable
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
    public class NeoBrutalistTextBox : TextBox
    {
        // Fields
        private int borderSize = 3;
        private int borderRadius = 0;
        private Color borderColor = Color.Black;
        private Color borderFocusColor = Color.FromArgb(255, 204, 0);
        private bool isFocused = false;
        private bool underlinedStyle = false;
        private Color placeholderColor = Color.FromArgb(128, 128, 128);
        private string placeholderText = string.Empty;
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;
        private string texts = string.Empty;

        // Constructor
        public NeoBrutalistTextBox()
        {
            BorderStyle = BorderStyle.None;
            // Set default font size to 14pt for better readability
            Font = new Font("Segoe UI", 14F);
            AutoSize = false;
            // Increase default size for better visibility
            Size = new Size(300, 45);
            // Increase padding for better text placement
            Padding = new Padding(15, 10, 15, 10);
            BackColor = Color.White;
            ForeColor = Color.Black;
            this.TextChanged += NeoBrutalistTextBox_TextChanged;
        }

        // Properties
        [Category("Neo Brutalist")]
        [DefaultValue(3)]
        [Description("Border size of the textbox")]
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
        [Description("Border radius of the textbox")]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    Invalidate();
                }
            }
        }

        [Category("Neo Brutalist")]
        [Description("Border color of the textbox")]
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
        [Description("Border color when the textbox has focus")]
        [TypeConverter(typeof(System.Drawing.ColorConverter))]
        [Editor("System.Drawing.Design.ColorEditor, System.Drawing.Design", typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderFocusColor
        {
            get => borderFocusColor;
            set
            {
                borderFocusColor = value;
                Invalidate();
            }
        }

        [Category("Neo Brutalist")]
        [DefaultValue(false)]
        [Description("Whether to use an underlined style")]
        public bool UnderlinedStyle
        {
            get => underlinedStyle;
            set
            {
                underlinedStyle = value;
                Invalidate();
            }
        }

        [Category("Neo Brutalist")]
        [DefaultValue(false)]
        [Description("Whether to use password character")]
        public new bool PasswordChar
        {
            get => isPasswordChar;
            set
            {
                isPasswordChar = value;
                if (!isPlaceholder)
                    base.UseSystemPasswordChar = value;
            }
        }

        [Category("Neo Brutalist")]
        [DefaultValue(false)]
        [Description("Whether the textbox is multiline")]
        public new bool Multiline
        {
            get => base.Multiline;
            set
            {
                base.Multiline = value;
                if (value)
                {
                    base.MinimumSize = new Size(0, 0);
                    base.Multiline = value;
                }
                else
                {
                    base.MinimumSize = new Size(0, 50);
                }
            }
        }

        [Category("Neo Brutalist")]
        [Description("The text content of the textbox")]
        [DefaultValue("")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
#nullable disable
        public override string Text
        {
            get => texts;
            set
            {
                texts = value ?? string.Empty;
                if (isPlaceholder)
                {
                    base.Text = string.Empty;
                    RemovePlaceholder();
                }
                else
                {
                    base.Text = value ?? string.Empty;
                }
            }
        }
#nullable enable

        [Category("Neo Brutalist")]
        [Description("The text content of the textbox")]
        [DefaultValue("")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string Texts
        {
            get => texts;
            set
            {
                texts = value;
                if (isPlaceholder)
                {
                    base.Text = "";
                    RemovePlaceholder();
                }
                else
                {
                    base.Text = value;
                }
            }
        }

        [Category("Neo Brutalist")]
        [DefaultValue("")]
        [Description("The placeholder text to display when the textbox is empty")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public new string PlaceholderText
        {
            get => placeholderText;
            set
            {
                placeholderText = value;
                if (isPlaceholder)
                    base.Text = value;
            }
        }

        [Category("Neo Brutalist")]
        [Description("The color of the placeholder text")]
        [TypeConverter(typeof(System.Drawing.ColorConverter))]
        [Editor("System.Drawing.Design.ColorEditor, System.Drawing.Design", typeof(System.Drawing.Design.UITypeEditor))]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color PlaceholderColor
        {
            get => placeholderColor;
            set
            {
                placeholderColor = value;
                if (isPlaceholder)
                    ForeColor = value;
            }
        }

        // Overridden methods
        protected override void OnPaint(PaintEventArgs? e)
        {
            if (e == null) return;
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius > 1) // Rounded TextBox
            {
                // Fields
                var rectBorderSmooth = ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(Parent?.BackColor ?? Color.White, smoothSize))
                using (Pen penBorder = new Pen(isFocused ? borderFocusColor : borderColor, borderSize))
                {
                    // Draw border smoothing
                    Region = new Region(pathBorderSmooth);
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    graph.DrawPath(penBorderSmooth, pathBorderSmooth);

                    // Draw border
                    if (borderSize >= 1)
                        graph.DrawPath(penBorder, pathBorder);
                }
            }
            else // Normal TextBox
            {
                // Draw border
                using (Pen penBorder = new Pen(isFocused ? borderFocusColor : borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    graph.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!Multiline)
            {
                int padding = 17;
                if (Font != null)
                {
                    // Adjust height based on font size
                    var textHeight = TextRenderer.MeasureText("Text", Font).Height;
                    Height = textHeight + padding;
                }
            }
        }

        // These methods are overridden below

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(texts) && !string.IsNullOrWhiteSpace(placeholderText))
            {
                isPlaceholder = true;
                base.Text = placeholderText;
                base.ForeColor = placeholderColor;
                base.UseSystemPasswordChar = false;
            }
        }

        private void RemovePlaceholder()
        {
            if (isPlaceholder)
            {
                isPlaceholder = false;
                base.Text = "";
                base.ForeColor = Color.Black; // Default text color
                base.UseSystemPasswordChar = isPasswordChar;
            }
        }

        private void NeoBrutalistTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (!isPlaceholder)
                texts = base.Text;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            isFocused = true;
            RemovePlaceholder();
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            isFocused = false;
            SetPlaceholder();
            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }
    }
}
