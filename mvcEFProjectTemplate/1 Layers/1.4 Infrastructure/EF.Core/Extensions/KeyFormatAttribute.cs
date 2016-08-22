using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Extensions
{
    public class KeyFormatAttribute:Attribute
    {
        public string Format { get; set; }
    }
}
