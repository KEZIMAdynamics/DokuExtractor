using DokuExtractorCore.Model.PdfHelper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    public interface IPdfTextLoader
    {
        // Currently disabled until it's actually needed.
        //Task<string> GetPdfInfo(string pdfFilePath);
        //Task<PdfPageSizeInfo> GetPdfPageSize(string pdfFilePath);

        /// <summary>
        /// Reads the content text from a PDF file and returns it. The text layout is preserved.
        /// </summary>
        /// <param name="pdfFilePath">Full name of PDF file</param>
        /// <param name="useMd5Cache">Keep extracted text files cached to improve performance if a PDF text is extracted more than one time. Reference between PDFs and text files is kept via the PDF's MD5-hash.</param>
        /// <returns></returns>
        Task<string> GetTextFromPdf(string pdfFilePath, bool useMd5Cache);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pdfFilePath"></param>
        /// <param name="useMd5Cache"></param>
        /// <param name="cropAreaX">Percentual X-Coordinate of the area which is to be extracted.</param>
        /// <param name="cropAreaY">Percentual Y-Coordinate of the area which is to be extracted.</param>
        /// <param name="cropAreaWdith">Percentual width of the area which is to be extracted.</param>
        /// <param name="cropAreaHeight">Percentual height of the area which is to be extracted.</param>
        /// <returns></returns>
        Task<string> GetTextFromPdf(string pdfFilePath, PercentalCropAreaInfo cropAreaInfo);

        string CheckMD5(string filename);

        Task RenderPdfToPngs(string pdfFilePath, string pdfImagesPath);
    }
}
