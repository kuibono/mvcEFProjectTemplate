using EF.Core.Domain;
using EF.Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.WebClient.Models
{
    public class TestUser:IdentityEntity
    {
        [StringLength(100)]
        [QueryType(EnumQueryType.Contains)]
        public string Name { get; set; }

        [StringLength(100)]
        [QueryType(EnumQueryType.Equals)]
        public string Password { get; set; }

        [SummaryType(EnumSumType.Sum)]
        public int LoginCount { get; set; }
    }
}