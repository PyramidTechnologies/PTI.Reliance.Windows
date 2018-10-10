namespace PTI.Reliance.Windows
{
    using System.Drawing;
    using System.Collections.Generic;
    using System.Drawing.Printing;

    /// <summary>
    /// A Document contains an ordered list of Content
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// Gets or Sets the name of this ticket as shown in the print spooler
        /// </summary>
        string JobName { get; set; }

        /// <summary>
        /// If true, document will measure itself and determine the best paper length
        /// to use. Otherwise, printing will respect the system selected page size.
        /// </summary>
        bool AutoSize { get; set; }

        /// <summary>
        /// Print document into an area of this size. If <see cref="AutoSize"/>
        /// is enabled, this field will be ignored.
        /// </summary>
        PageSizeMillimeters RequestedSize { get; set; }

        /// <summary>
        /// Gets or Sets list of document content.
        /// Paper leaves the Reliance Printer top-first
        /// so DocumentContent[0] is printed first.
        /// </summary>
        IEnumerable<IContent> DocumentContent { get; set; }

        /// <summary>
        /// Returns the size in pixels for the current content
        /// </summary>
        /// <returns></returns>
        SizeF MeasureSize();

        /// <summary>
        /// System printing handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Print(object sender, PrintPageEventArgs e);
    }
}
