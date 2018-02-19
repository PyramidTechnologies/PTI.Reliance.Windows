namespace PTI.Reliance.Windows
{
    using System.Drawing.Printing;

    /// <inheritdoc />
    /// <summary>
    /// Reliance Printer implementation for a printing device
    /// </summary>
    public class ReliancePrinter : IPrinter
    {
        public ReliancePrinter(string printerName)
        {
            PrinterName = printerName;
            PaperWidthmm = 80;
        }

        /// <inheritdoc />
        public string PrinterName { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Reliance default width is 80mm
        /// </summary>
        public int PaperWidthmm { get; set; }

        /// <inheritdoc />
        public void PrintDocument(IDocument doc)
        {
            var msDocument = new PrintDocument
            {
                DocumentName = doc.JobName,
                PrintController = new StandardPrintController(),
                OriginAtMargins = false,
                PrinterSettings = {PrinterName = PrinterName}
            };

            // The nature of the Windows print stack is that 
            // a) paper does not typically come in rolls
            // b) sizes are selected by the user at runtime
            // This makes kiosk life a challenge. The solution
            // is to dynamically measure the resulting document
            // and generate a new paper size on the fly.
            if (doc.AutoSize)
            {
                // Units are in hundreths of an inch 
                var width = (int) (Utilities.ConvertMmToInches(80) * 100);
                var pixelHeight = doc.MeasureSize().Height;
                var height = (int)pixelHeight * 2;

                var newSize = new PaperSize
                {
                    PaperName = "User Size",
                    RawKind = 256, // DMPAPER_USER
                    Height = height,
                    Width = width
                };         

                msDocument.DefaultPageSettings.PaperSize = newSize;
            }


            msDocument.PrintPage += doc.Print;

            msDocument.Print();
        }
    }
}
