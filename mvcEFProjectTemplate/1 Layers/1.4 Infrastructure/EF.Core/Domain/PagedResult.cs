using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Domain
{
    public class PagedResult<T>  where T : EntityBase
    {
        public int total { get; set; }

        public IList<T> data { get; set; }

        public Dictionary<string, double> summary { get; set; }


    }
}
