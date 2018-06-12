using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    public class TwoLineTable
    {
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }

        public TwoLineTable(string FirstLine, string SecondLine)     // Constructor with FirstLine and SecondLine 
        {
            this.FirstLine = FirstLine;
            this.SecondLine = SecondLine;
        }
       
    }
}
