using EF.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Test.WebClient.Models
{
    public class TestContext:ContextBase
    {
        public DbSet<TestUser> TestUser { get; set; }

        public DbSet<TestStringKey> TestStringKey { get; set; }

        public DbSet<PcPurchaseDetail> PcPurchaseDetail { get; set; }

        public DbSet<PcPurchaseManage> PcPurchaseManage { get; set; }    
    }
}