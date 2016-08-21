using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Domain.Authorize
{
    public class MenuItem : IdentityEntity
    {
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Target { get; set; }

         [StringLength(2048)]
        public string Url { get; set; }

        [StringLength(255)]
         public string Icon { get; set; }
    }
}
