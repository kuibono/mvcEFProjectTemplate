using EF.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Extensions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PagedQueryInterfaceAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public PagedQueryInterfaceAttribute()
        {

        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var q = actionContext.ActionArguments.First().Value as QueryObject;

            var frm = System.Web.HttpContext.Current.Request.Form;
            for (int i = 0; i < frm.AllKeys.Count(); i++)
            {
                if (frm.AllKeys[i] != "pageIndex" &&
                    frm.AllKeys[i] != "pageSize" &&
                    frm.AllKeys[i] != "sortField" &&
                    frm.AllKeys[i] != "sortOrder"&&
                    frm.AllKeys[i] != "ShowSummary"
                    )
                {
                    q.Add(frm.AllKeys[i], frm[i]);
                }
            }

            base.OnActionExecuting(actionContext);
        }
    }
}
