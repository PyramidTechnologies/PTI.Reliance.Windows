namespace PTI.Reliance.Windows
{
    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Text;

    /// <inheritdoc />
    /// <summary>
    /// Plain-text content that can be dressed up with font faces,
    /// point sizes, and weight. All text in this content uses
    /// the same style. To use multiple styles in a document's text
    /// you must create multiple instances of TextContent.
    /// </summary>
    public class TextContent : IContent
    {
        /// <summary>
        /// Constructor
        /// <param name="initialText">Optional starting text</param>
        /// <param name="font">Optional font</param>
        /// </summary>
        public TextContent(string initialText = "", Font font = null)
        {
            TextBuilder = new StringBuilder(initialText);

            if (font == null)
            {
                font = SystemFonts.DefaultFont;
            }

            CurrentFont = font;
        }

        /// <summary>
        /// Gets or Sets the current font configuration for this printer.
        /// This controls the typeface, point size and weight.
        /// E.g. Comic Sans 32 point bold
        /// </summary>
        public Font CurrentFont { get; set; }

        /// <summary>
        /// Mutable document text
        /// </summary>
        public StringBuilder TextBuilder { get; set; }

        /// <inheritdoc />
        public SizeF MeasureSize()
        {
            using (var hwnd = Graphics.FromHwnd(IntPtr.Zero))
            {
                var drawFont = CurrentFont;
                var text = TextBuilder.ToString();
                return hwnd.MeasureString(text, drawFont);

            }
        }

        /// <inheritdoc />
        public void Draw(PrintPageEventArgs args, PointF point)
        {          
            var drawFont = CurrentFont;
            var drawBrush = new SolidBrush(System.Drawing.Color.Black);

            args.Graphics.DrawString(TextBuilder.ToString(), drawFont, drawBrush, point);
        }

    }
}
