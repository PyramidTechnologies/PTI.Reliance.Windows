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
        /// must match the OS name of the printer (case insensitive)
        /// </summary>
        string PrinterName { get; set; }
        
        /// <summary>
        /// Prints the current document content        
        /// </summary>
        /// <param name="doc">Document to print</param>
        void PrintDocument(IDocument doc);
    }
}
