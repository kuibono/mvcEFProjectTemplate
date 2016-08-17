using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Extensions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PagedQueryInterfaceAttribute : Attribute
    {
        public PagedQueryInterfaceAttribute()
        {

        }
    }
}
