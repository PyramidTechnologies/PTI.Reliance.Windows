namespace PTI.Reliance.Windows
{
    using System;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Drawing.Printing;

    /// <inheritdoc />
    /// <summary>
    /// Document implementation
    /// </summary>
    public class Document : IDocument
    {
        /// <inheritdoc />
        public string JobName { get; set; }

        /// <inheritdoc />
        public bool AutoSize { get; set; }

        /// <inheritdoc />
        public IEnumerable<IContent> DocumentContent { get; set; }

        /// <inheritdoc />
        public SizeF MeasureSize()
        {
            var size = new SizeF();
            foreach (var content in DocumentContent)
            {
                var contentSize = content.MeasureSize();
                size.Height += contentSize.Height;
                size.Width = Math.Max(size.Width, contentSize.Width);
            }

            return size;
        }

        public void Print(object sender, PrintPageEventArgs e)
        {
            // TODO Margins and Spacing
            var origin = new PointF(0, 0);

            foreach (var content in DocumentContent)
            {
                content.Draw(e, origin);
                origin.Y += content.MeasureSize().Height;
            }
        }
    }
}
