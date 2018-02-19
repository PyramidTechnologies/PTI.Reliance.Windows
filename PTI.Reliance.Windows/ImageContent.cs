namespace PTI.Reliance.Windows
{
    using System;
    using System.Drawing;
    using System.Drawing.Printing;

    public class ImageContent : IContent, IDisposable
    {
        bool _disposed = false;

        /// <summary>
        /// Create a new Image Content with specified image
        /// </summary>
        /// <param name="bitmap">Bitmap source to copy</param>
        public ImageContent(Bitmap bitmap)
        {
            SetImage(bitmap);
        }

        /// <summary>
        /// Create a new Image Content with the specified image
        /// </summary>
        /// <param name="bitmapPath">Bitmap path</param>
        public ImageContent(string bitmapPath)
        {
            SetImage(bitmapPath);
        }

        /// <summary>
        /// Copies specified bitmap to this document
        /// You are free to release source after calling
        /// this method.
        /// This method assigns the natural bitmap size
        /// as the size of the image that will be printed.
        /// </summary>
        /// <seealso cref="BitmapSize"/>
        /// <param name="source">Bitmap to copy</param>
        public void SetImage(Bitmap source)
        {
            Bitmap = new Bitmap(source);
            BitmapSize = Bitmap.Size;
        }

        /// <summary>
        /// Loads bitmap from the specified path. This supports
        /// the standard image format: BMP, GIF, EXIF, JPG, PNG and TIFF.
        /// This method assigns the natural bitmap size
        /// as the size of the image that will be printed.
        /// </summary>
        /// <seealso cref="BitmapSize"/>         
        /// <param name="bitmapPath">Full path to bitmap image</param>
        public void SetImage(string bitmapPath)
        {
            Bitmap = new Bitmap(bitmapPath);
            BitmapSize = Bitmap.Size;
        }

        /// <summary>
        /// Gets or Sets desired Bitmap size in screen pixels
        /// </summary>
        public Size BitmapSize { get; set; }

        /// <summary>
        /// Gets or Sets bitmap for this object. Remember that the
        /// .NET Bitmap class is not quite unmanaged so this class
        /// takes care to dispose of it properly.
        /// </summary>
        private Bitmap Bitmap { get; set; }

        /// <inheritdoc />
        public SizeF MeasureSize()
        {
            return BitmapSize;
        }

        /// <inheritdoc />
        public void Draw(PrintPageEventArgs args, PointF point)
        {
            if (Bitmap == null)
            {
                return;
            }

            using (var bmp = new Bitmap(Bitmap))
            {
                args.Graphics.DrawImage(bmp, point);
            }
        }

        #region Disposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);         
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Bitmap.Dispose();
            }

            _disposed = true;
        }
        #endregion
    }
}
