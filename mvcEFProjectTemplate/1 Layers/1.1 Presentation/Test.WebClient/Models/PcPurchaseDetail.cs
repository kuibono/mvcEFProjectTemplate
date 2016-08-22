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
    [Table("pc_purchase_detail")]
    [KeyFormat(Format = "22yyyyMMddHHmmss######")]
    public class PcPurchaseDetail : DetailEntity
    {
        [Column("sys_guid")]
        public override string Id
        {
            get;
            set;
        }
        [Column("pc_number")]
        public override string MasterKey
        {
            get;
            set;
        }
        [Column("goods_code")]
        [StringLength(50)]
        public string goods_code { get; set; }
    }
}