using DokuExtractorCore.Model;
using Sprache.Calc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore
{
    /// <summary>
    /// Directories
    /// </summary>
    public static class Directories
    {
        /// <summary>
        /// Folder path, where the Template folders (group and class template folders) are
        /// </summary>
        public static string AppRootPath { get; set; } = Environment.CurrentDirectory;
        /// <summary>
        /// Folder path, where the poppler.zip is
        /// </summary>
        public static string PopplerZipPath { get; set; } = Environment.CurrentDirectory;
    }
}
