using System;
using System.Collections.Generic;
using System.Text;

namespace DokuExtractorCore.Model.PdfHelper
{
   public class PdfPageSizeInfo
    {
        public float SizeX { get; set; }
        public float SizeY { get; set; }
        public string Unit { get; set; }
        public string OriginalSizeString { get; set; }
    }
}
