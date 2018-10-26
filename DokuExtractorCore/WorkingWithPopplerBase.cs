using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    /// <summary>
    /// Working with poppler base
    /// </summary>
    public abstract class WorkingWithPopplerBase
    {
        /// <summary>
        /// Has poppler been checked
        /// </summary>
        protected bool popplerChecked;

        /// <summary>
        /// Supply poppler
        /// </summary>
        protected void SupplyPoppler()
        {
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "bin", "pdftotext.exe")) == false)
            {
                ZipFile.ExtractToDirectory(Path.Combine(Directories.PopplerZipPath, "poppler-0.51.zip"), Path.Combine(Environment.CurrentDirectory));
            }
            popplerChecked = true;
        }


    }
}
