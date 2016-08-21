using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Extensions
{
    public class QueryTypeAttribute : Attribute
    {
        public QueryTypeAttribute(EnumQueryType qType)
        {
            this.QType = qType;
        }
        public virtual EnumQueryType QType { get; set; }
    }

    public enum EnumQueryType
    {
        Equals,
        GT,
        GET,
        LT,
        LET,
        Contains,
        StartWith,
        EndWith
    }
}
