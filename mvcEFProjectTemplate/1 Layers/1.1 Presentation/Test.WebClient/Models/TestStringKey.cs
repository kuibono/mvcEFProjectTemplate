using EF.Core.Domain;
using EF.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.WebClient.Models
{
    [KeyFormat( Format="21yyyyMMddHHmmssfff####")]
    public class TestStringKey:StringKeyEntity
    {
        public string Name { get; set; }
    }
}