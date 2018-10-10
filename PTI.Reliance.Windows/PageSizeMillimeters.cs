namespace PTI.Reliance.Windows
{
    using System.Drawing.Printing;

    /// <summary>
    /// A wrapper for PaperSize that works in mm
    /// </summary>
    public class PageSizeMillimeters
    {
        /// <summary>
        /// Create a new page size with given dimensions in mm
        /// </summary>
        /// <param name="widthMm">Total width of page being printed</param>
        /// <param name="heightMm">Total height of page being printed</param>
        public PageSizeMillimeters(int widthMm, int heightMm)
        {
            WidthMm = (int)(Utilities.ConvertMmToInches(widthMm) * 100);
            HeightMm = (int)(Utilities.ConvertMmToInches(heightMm) * 100);

            WinPaperSize = new PaperSize
            {
                PaperName = "User Size",
                RawKind = 256, // DMPAPER_USER
                Width = WidthMm,
                Height = HeightMm
            };
        }

        /// <summary>
        /// Width of this page in mm
        /// </summary>
        public int WidthMm { get; }

        /// <summary>
        /// Height of this page in mm
        /// </summary>
        public int HeightMm { get; }

        /// <summary>
        /// Returns the Windows paper size
        /// </summary>
        internal PaperSize WinPaperSize { get; }

        /// <summary>
        /// Returns Width x Height
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}mm x {1}mm", WidthMm, HeightMm);
        }
    }
}
