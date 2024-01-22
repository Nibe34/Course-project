using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_library_owner_handbook
{
    internal interface IStringConvertible
    {
        string ToStringForFile();
        string ToStringForWrite();
    }
}
