using System;
using System.Collections.Generic;
using System.Text;

namespace DokuExtractorCore.Model
{
    public class DocumentBaseTemplate
    {
        /// <summary>
        /// Key words are matched against the input text to check if the template is the right one. Each string has to be present in the input text for a successfull match (AND condition).
        /// Each string may consist of a group of several words, seperated by '|' (pipe). It is enough for one word of the group to be present in the input text (OR condition).
        /// If a group of words must not be in the template in order match, a '!' can be added in front of the group.
        /// </summary>
        public List<string> KeyWords { get; set; } = new List<string>();


    }
}
