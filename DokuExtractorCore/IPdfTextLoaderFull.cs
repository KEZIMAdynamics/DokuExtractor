﻿using DokuExtractorCore.Model;
using DokuExtractorCore.Model.PdfHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    /// <summary>
    /// PDF text loader full interface
    /// </summary>
    public interface IPdfTextLoaderFull
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
        /// Gets text from a PDF that is within a given area.
        /// </summary>
        /// <param name="pdfFilePath">PDF location on disk.</param>
        /// <param name="cropAreaInfo">Percentual area which is to be extracted.</param>
        /// <returns></returns>
        Task<string> GetTextFromPdf(string pdfFilePath, PercentalAreaInfo cropAreaInfo);

        /// <summary>
        /// Gets text from PDF for positional data fields
        /// </summary>
        /// <param name="pdfFilePath"></param>
        /// <param name="datafields"></param>
        /// <returns></returns>
        Task<List<DataFieldResult>> GetTextFromPdfForPositionalDataFields(string pdfFilePath, List<DataFieldClassTemplate> datafields);

        /// <summary>
        /// Returns MD5-Hashwert
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        string CheckMD5(string filename);
    }
}
