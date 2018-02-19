namespace PTI.Reliance.Windows
{
    using System.Drawing;
    using System.Drawing.Printing;

    /// <summary>
    /// Content is text, images, or other "content" that can be drawn onto
    /// a print document.
    /// </summary>
    public interface IContent
    {
        /// <summary>
        /// Returns the size in pixels for the current content
        /// </summary>
        /// <returns></returns>
        SizeF MeasureSize();

        /// <summary>
        /// Draws the content of this object onto the specified page
        /// </summary>
        /// <param name="args">Page to draw on</param>
        /// <param name="rect">Point to begin drawing at</param>
        void Draw(PrintPageEventArgs args, PointF rect);
    }
}
