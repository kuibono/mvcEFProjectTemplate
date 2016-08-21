using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Domain
{
    public class MasterWithExamineEntity : StringKeyEntity
    {
        [StringLength(10)]
        [Column("if_examine")]
        public virtual string IfExamine { get; set; }

        [Column("examine_date")]
        public DateTime? ExamineDate { get; set; }

        [StringLength(50)]
        [Column("operator")]
        public string Operator { get; set; }

        [Column("operator_date")]
        public DateTime? OperatorDate { get; set; }
    }
}
