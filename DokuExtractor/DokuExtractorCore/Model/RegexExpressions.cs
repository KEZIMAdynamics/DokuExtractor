using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    public class RegexExpressions
    {
        public List<string> GeneralDateExpressions { get; set; } = new List<string>()
        { @"\s+", @"\s+.\s+", @"\s+\w+\s+", @"\s+\w+\s+\w+\s+", @"\s+\w+\s+\w+\s+\w+\s+", @".+\s+", @".+\s+\w+", @".+\s+\w+\s+", @".+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+", @".+\s+\w+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+\w+\s+", @".+\/" };

        public List<string> SpecificDateExpressions { get; set; } = new List<string>()
        {
         @"(\d+.\d{2}.\d+)",@"([a-zA-Z]+ \d+ , \d+)",@"(\d{2}-\d{2}-\d{4})",
         @"([\s,\d]+-[A-Z,a-z]{3}-\d{4})",@"(\d{1,2}\w+,\d{4})",@"(\d{1,2}\. \w+ \d{4})",
         @"(\d{4}-\d{2}-\d{2})",@"(\w+,\d{4})",@"(\d{1,2}\w+,\d{4})",@"(\d{1,2}\.\w+\d{4})",
         @"(\d+\D+\s+\w+\s+\d+)",@"(\d+\. .+ \d{4})",
         @"(\d{2}-\w+-\d{4})",@"(\w{1,10}\d+,\d{4})",@"(\w{3,}\d{1,2},\d{4})",@"(\d{1,2}.+\s+\d{4})",
         @"(\d{2}\/\d{2}\/\d{4})",@"(\d+/\d+/\d+)",@"(\d+/\d+/\d{4})",@"(\d{1,2}\/\d{1,2}\/\d{4})",
         @"(\d{4}-\d{2}-\d{2})",@"(\d{4}-\d{2}-\d{2})",@"(\d{1,2}\/\d{1,2}\/\d{4})",@"(\d{2}\,\d{2}\,\d{4})",
         @"(\w+\s*\d+,\s*\d{4})",@"(\d{1,2}-\d{1,2}-\d{4})",@"(\d{2}/\d{2}/\d{4})",@"(\d{1,2}\.\d{1,2}\.\d{4})",@"(\d{2}.+,\s\d{4})",@"(\d+\.\d+\s\d+\s\d)"

        };

        public List<string> GeneralCurrencyExpressions { get; set; } = new List<string>()
        { @"\s+", @"\s+.\s+", @"\s+\w+\s+", @"\s+\w+\s+\w+\s+", @"\s+\w+\s+\w+\s+\w+\s+", @".+\s+", @".+\s+\w+", @".+\s+\w+\s+", @".+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+", @".+\s+\w+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+\w+\s+", @".+\/", @"\s+\w+\s+\d+,\d{2}\s+",@"\s+\d+,\d{2}\s+\w+\s+" };

        public List<string> SpecificCurrencyExpressions { get; set; } = new List<string>()
        {
         @"(\d+.?\d{0,3},\d{2})",
         @"(\d+,\d{2})\D",
         @"(\d+'\d{2})\D",
         @"(\d+\D\d{2})\D",
         @"(\d+.\d{3},\d{2})",
         @"(\d+,\d{2})",
         @"(\d+'\d{2})",
         @"(\d+\D\d{2})"
        };

        public List<string> GeneralIBANExpressions { get; set; } = new List<string>()
        { @"\s+", @"\s+.\s+", @"\s+\w+\s+", @"\s+\w+\s+\w+\s+", @"\s+\w+\s+\w+\s+\w+\s+", @".+\s+", @".+\s+\w+", @".+\s+\w+\s+", @".+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+", @".+\s+\w+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+\w+\s+", @".+\/" };

        public List<string> SpecificIBANExpressions { get; set; } = new List<string>()
        {
        @"([a-zA-Z]{2}\d{2}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{2})"
        };

        public List<string> GeneralAnchorlessIBANExpressions { get; set; } = new List<string>() { string.Empty };

        public List<string> SpecificAnchorlessIBANExpressions { get; set; } = new List<string>()
        {
        @"([a-zA-Z]{2}\d{2}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{4}\s?[0-9a-zA-Z]{2})"
        };

        public List<string> GeneralVatIdExpressions { get; set; } = new List<string>()
        { @"\s+", @"\s+.\s+", @"\s+\w+\s+", @"\s+\w+\s+\w+\s+", @"\s+\w+\s+\w+\s+\w+\s+", @".+\s+", @".+\s+\w+", @".+\s+\w+\s+", @".+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+", @".+\s+\w+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+\w+\s+", @".+\/" };

        public List<string> SpecificVatIdExpressions { get; set; } = new List<string>()
        {
        @"([a-zA-Z]{2}\s?[0-9a-zA-Z]{3}\s?[0-9]{3}\s?[0-9a-zA-Z]{3,4})\s",
        @"([a-zA-Z]{2}\s?[0-9a-zA-Z]{3}\s?[0-9]{3}\s?[0-9a-zA-Z]{3,4})"
        };
        
        public List<string> GeneralTermExpressions { get; set; } = new List<string>()
        { @"\s+", @".\s+", @"\s+.\s+", @"\s+\w+\s+",@".+?\s+",@".+?\s+?",@".+?\s+?.+?\s+?",@".+?\s+?.+?\s+?.+?\s+?",@".+?\s+?.+?\s+?.+?\s+?.+?\s+?",@".+?\s+?.+?\s+?.+?\s+?.+?\s+?.+?\s+?",
            @"\s+\w+\s+\w+\s+", @"\s+\w+\s+\w+\s+\w+\s+", @".+\s+", @".+\s+\w+", @".+\s+\w+\s+", @".+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+", @".+\s+\w+\s+\w+\s+\w+", @".+\s+\w+\s+\w+\s+\w+\s+", @".+\/" };

        public List<string> SpecificTermExpressions { get; set; } = new List<string>()
        {
         @"(.+?)\s",
         @"(.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",    
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s",
         @"(.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?\s.+?)\s"
        
        };

    }
}
