using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    public interface IPdfRenderer
    {
        Task RenderPdfToPngs(string pdfFilePath, string pdfImagesPath);
    }
}
