namespace PTI.Reliance.Windows
{
    /// <summary>
    /// Base printer class
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Gets or Sets the name of the printer this instance 
        /// is associated with. If setting the name, the string
        /// must match the OS name of the printer (case insentitive)
        /// </summary>
        string PrinterName { get; set; }

        /// <summary>
        /// Gets or Sets paper width in mm
        /// </summary>
        int PaperWidthmm { get; set; }

        /// <summary>
        /// Prints the current document content        
        /// </summary>
        /// <param name="doc">Document to print</param>
        void PrintDocument(IDocument doc);
    }
}
