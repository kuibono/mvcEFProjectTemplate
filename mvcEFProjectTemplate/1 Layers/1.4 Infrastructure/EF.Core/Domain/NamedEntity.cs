using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Domain
{
    public class NamedEntity:IdentityEntity
    {
        [StringLength(255)]
        public string Name { get; set; }
    }
}
