using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Domain
{
    public class StringKeyEntity:EntityBase
    {
        [Key]
        [StringLength(50)]
        public virtual string Id { get; set; }
    }
}
