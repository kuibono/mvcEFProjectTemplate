using EF.Core.Domain;
using EF.Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test.WebClient.Models
{
    [Table("pc_purchase_manage")]
    [KeyFormat(Format = "21yyyyMMdd#######")]
    public class PcPurchaseManage:MasterWithExamineEntity
    {
        [Column("pc_number")]
        public override string Id
        {
            get;
            set;
        }

        [Column("sup_code")]
        [StringLength(50)]
        public string sup_code { get; set; }

        [Column("en_code")]
        [StringLength(50)]
        public string en_code { get; set; }


    }
}