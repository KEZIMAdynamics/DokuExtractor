using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Indicates the type of data that the regex expression shall match. Different types (e.g. dates and currencies) are matched with different regex expressions. Calculations can also only be done with currency type data fields. Therefore it is important to specify the correct type.
    /// </summary>
    public enum DataFieldTypes
    {
        Text,
        Date,
        Currency,
        IBAN,
        AnchorLessIBAN,
        VatId,
        Term
    }
}
