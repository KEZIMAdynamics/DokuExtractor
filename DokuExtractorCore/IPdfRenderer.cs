using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    /// <summary>
    /// PDF renderer interface
    /// </summary>
    public interface IPdfRenderer
    {
        /// <summary>
        /// Renders a PDF to PNGs
        /// </summary>
        /// <param name="pdfFilePath"></param>
        /// <param name="pdfImagesPath"></param>
        /// <returns></returns>
        Task RenderPdfToPngs(string pdfFilePath, string pdfImagesPath);
    }
}
