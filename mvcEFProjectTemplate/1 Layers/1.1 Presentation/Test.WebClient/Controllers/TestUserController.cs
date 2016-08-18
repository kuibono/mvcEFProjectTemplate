using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.WebClient.Models;

namespace Test.WebClient.Controllers
{
    public class TestUserController : APIControllerBase<TestUser>
    {
        public TestUserController()
        {
            this.svc.CurrentContext = new TestContext();
        }

    }

}