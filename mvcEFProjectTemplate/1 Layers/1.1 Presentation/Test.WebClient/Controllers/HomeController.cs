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
            //var svc = new StringKeyServiceBase<TestStringKey>();
            //svc.CurrentContext = new TestContext();
            //var item = new TestStringKey();
            //item.Name = "Test1";

            //svc.Create(item);


            var svc = new MasterWithExamineService<PcPurchaseManage, PcPurchaseDetail>();
            svc.CurrentContext = new TestContext();

            var m = new PcPurchaseManage();
            m.en_code = "0001";
            m.sup_code = "1234";

            var ds = new List<PcPurchaseDetail>();
            ds.Add(new PcPurchaseDetail() { 
             goods_code="1001"
            });
            ds.Add(new PcPurchaseDetail()
            {
                goods_code = "1002"
            });

            svc.Save(m, ds);

            return Json(m.Id, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Examine(string id)
        {
            var svc = new MasterWithExamineService<PcPurchaseManage, PcPurchaseDetail>();
            svc.CurrentContext = new TestContext();
            svc.Examine(id, "张三");
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Terminate(string id)
        {
            var svc = new MasterWithExamineService<PcPurchaseManage, PcPurchaseDetail>();
            svc.CurrentContext = new TestContext();
            svc.Terminate(id, "张三");
            return Json(id, JsonRequestBehavior.AllowGet);
        }
    }
}