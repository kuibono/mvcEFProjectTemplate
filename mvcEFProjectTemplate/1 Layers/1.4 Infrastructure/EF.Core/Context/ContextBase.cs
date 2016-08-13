using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Context
{
    public class ContextBase:DbContext
    {
        public ContextBase()
            : base("DefaultConnection")
        {

        }
    }
}
