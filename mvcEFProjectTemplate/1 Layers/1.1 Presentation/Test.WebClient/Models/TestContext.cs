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
    }
}