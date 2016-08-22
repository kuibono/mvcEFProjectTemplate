using EF.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.WebClient.Models;

namespace Test.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            var svc = new StringKeyServiceBase<TestStringKey>();
            svc.CurrentContext = new TestContext();
            var item = new TestStringKey();
            item.Name = "Test1";

            svc.Create(item);
            return Json(item.Id, JsonRequestBehavior.AllowGet);
        }
    }
}