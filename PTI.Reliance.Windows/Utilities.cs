using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;

namespace PTI.Reliance.Windows
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public static class Utilities
    {
        /// <summary>
        /// Produce the bounding box size given a list of non-occluding
        /// rectangle sizes.
        /// </summary>
        /// <param name="rects">List of rectangles</param>
        /// <returns>Largest width and height required to contains all rects</returns>
        public static SizeF BoundingBox(IEnumerable<SizeF> rects)
        {
            var result = new SizeF();
            foreach (var r in rects)
            {
                result.Height += r.Height;
                result.Width = Math.Max(result.Width, r.Width);
            }

            return result;
        }

        /// <summary>
        /// Convert millimeters to inches
        /// </summary>
        /// <param name="mm">Length in mm</param>
        /// <returns>Length in inches</returns>
        public static float ConvertMmToInches(float mm)
        {
            return mm / 25.4f;
        }

        /// <summary>
        /// Convert inches to millimeters
        /// </summary>
        /// <param name="inches">Length in inches</param>
        /// <returns>Length in mm</returns>
        public static float ConvertInchesToMm(float inches)
        {
            return inches * 25.4f;
        }

        /// <summary>
        /// Returns all printer page sizes on system
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetPageSizeList()
        {
            var doc = new PrintDocument();            
            var paperSizes = doc.PrinterSettings.PaperSizes;
            return (from object ps in paperSizes select ps.ToString()).ToList();
        }
    }
}
