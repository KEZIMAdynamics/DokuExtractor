using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace DokuExtractorCore
{
    /// <summary>
    /// Can open a PDF file and return its content text
    /// </summary>
    public class PdfTextLoader
    {
        private bool popplerChecked;

        /// <summary>
        /// Reads the content text from a PDF file and returns it. The text layout is preserved.
        /// </summary>
        /// <param name="pdfFilePath">Full name of PDF file</param>
        /// <param name="useMd5Cache">Keep extracted text files cached to improve performance if a PDF text is extracted more than one time. Reference between PDFs and text files is kept via the PDF's MD5-hash.</param>
        /// <returns></returns>
        public async Task<string> GetTextFromPdf(string pdfFilePath, bool useMd5Cache)
        {
            if (popplerChecked == false)
                SupplyPoppler();

            var pdfInfo = new FileInfo(pdfFilePath);
            var targetFilePath = pdfFilePath + ".txt";

            if (useMd5Cache)
            {
                var hash = CheckMD5(pdfFilePath);
                var hashPath = Path.Combine(pdfInfo.DirectoryName, hash + ".txt");

                if (File.Exists(hashPath))
                    return File.ReadAllText(hashPath);
                else
                    targetFilePath = hashPath;
            }

            var pdfToTextPath = Path.Combine(Environment.CurrentDirectory, "bin", "pdftotext.exe");

            var pdfProcess = new Process();
            pdfProcess.StartInfo.FileName = pdfToTextPath;
            pdfProcess.StartInfo.Arguments = "-layout " + pdfFilePath.EncapsulateInDoubleQuotes() + " " + targetFilePath.EncapsulateInDoubleQuotes();
            pdfProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            var watch = new Stopwatch();
            watch.Start();
            pdfProcess.Start();
            await pdfProcess.WaitForExitAsync();
            watch.Stop();

            Debug.Print("Extraction time: " + watch.Elapsed);

            var retVal = File.ReadAllText(targetFilePath);

            if (useMd5Cache == false)
                File.Decrypt(targetFilePath);

            return retVal;
        }

        private string CheckMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                }
            }
        }

        private void SupplyPoppler()
        {
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "bin", "pdftotext.exe")) == false)
            {
                ZipFile.ExtractToDirectory(Path.Combine(Environment.CurrentDirectory, "poppler-0.51.zip"), Path.Combine(Environment.CurrentDirectory));
            }
            popplerChecked = true;
        }
    }
}
