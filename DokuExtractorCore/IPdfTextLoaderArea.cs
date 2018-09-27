using DokuExtractorCore.Model;
using DokuExtractorCore.Model.PdfHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    public interface IPdfTextLoaderArea
    {
        /// <summary>
        /// Gets text from a PDF based that is within a given area.
        /// </summary>
        /// <param name="pdfFilePath">PDF location on disk.</param>
        /// <param name="cropAreaInfo">Percentual area which is to be extracted.</param>
        /// <returns></returns>
        Task<string> GetTextFromPdf(string pdfFilePath, PercentalAreaInfo cropAreaInfo);

        //Task<PdfPageSizeInfo> GetPdfPageSize(string pdfFilePath);
    }
}
