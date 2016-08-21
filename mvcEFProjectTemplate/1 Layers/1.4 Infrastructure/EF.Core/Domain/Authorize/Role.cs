using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Domain.Authorize
{
    public class Role : IdentityEntity
    {
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
