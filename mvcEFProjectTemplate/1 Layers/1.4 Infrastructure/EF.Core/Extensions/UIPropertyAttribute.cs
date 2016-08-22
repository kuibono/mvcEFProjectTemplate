using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Extensions
{
    public class UIPropertyAttribute:Attribute
    {

        public string Title { get; set; }
        public bool Visible { get; set; }

        public string Default { get; set; }

        public bool EnableSearch { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }

        public string Url { get; set; }

        public bool Required { get; set; }

        public string VType { get; set; }

        public string OnValueChanged { get; set; }

        public int? MaxLength { get; set; }

        public string Extend { get; set; }

        public bool ShowInPrint { get; set; }

        public bool ShowInExport { get; set; }
    }
}
