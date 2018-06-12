using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokuExtractorCore.Model
{
    /// <summary>
    /// Indicates the type of the conditional field. Not evaluated within DokuExtractor itself. Can be used to provide additional information to external programs.
    /// </summary>
    public enum ConditionalFieldType
    {
        Text,
        Bool,
        Number,
        Date,
        UserId,
        UserGroupId,
        UserOrUserGroupId
    }
}
