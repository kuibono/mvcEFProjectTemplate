using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Domain
{
    public class DetailEntity:StringKeyEntity
    {
        public virtual string MasterKey { get; set; }
    }
}
