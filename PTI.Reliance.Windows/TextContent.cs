﻿namespace PTI.Reliance.Windows
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
    /// TODO list
    /// Tab stops
    /// Bold, Italic, etc.
    /// </summary>
    public class TextContent : IContent
    {
        /// <summary>
        /// Constructor
        /// <param name="initialText">Optional starting text</param>
        /// <param name="font">Optional font</param>
        /// <param name="justification">Line's horizontal justification</param>
        /// </summary>
        public TextContent(string initialText = "", Font font = null, StringAlignment justification = StringAlignment.Near)
        {
            TextBuilder = new StringBuilder(initialText);

            if (font == null)
            {
                font = SystemFonts.DefaultFont;
            }

            CurrentFont = font;
            Justification = justification;
        }

        /// <summary>
        /// Gets or Sets the current font configuration for this printer.
        /// This controls the typeface, point size and weight.
        /// E.g. Comic Sans 32 point bold
        /// </summary>
        public Font CurrentFont { get; set; }

        /// <summary>
        /// Gets or Sets the justification for this content        
        /// Warning: Center justification will break text wrapping
        /// </summary>        
        public StringAlignment Justification { get; set; }     

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
                var size = hwnd.MeasureString(text, drawFont);
                return size;
            }
        }

        /// <inheritdoc />
        public void Draw(PrintPageEventArgs args, PointF point)
        {          
            var drawFont = CurrentFont;
            var drawBrush = new SolidBrush(System.Drawing.Color.Black);

            // Produce alignment descriptor - always vertically centered
            var format = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = Justification,                
            };
            format.SetTabStops(0, new []{ 4.0f });

            // Allignment is relative to a region
            var textSize = MeasureSize();
            var region = new RectangleF(point.X, point.Y, args.PageBounds.Width, textSize.Height);

            args.Graphics.DrawString(TextBuilder.ToString(), drawFont, drawBrush, region, format);
        }

    }
}
