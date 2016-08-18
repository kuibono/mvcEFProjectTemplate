using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Extensions
{
    public class SummaryTypeAttribute : Attribute
    {
        public SummaryTypeAttribute(EnumSumType sumType)
        {
            SumType = sumType;
        }
        public virtual EnumSumType SumType { get; set; }
    }

    public enum EnumSumType
    {
        None,
        Sum,
        Avg,
        Max,
        Min,
        Count
    }
}
