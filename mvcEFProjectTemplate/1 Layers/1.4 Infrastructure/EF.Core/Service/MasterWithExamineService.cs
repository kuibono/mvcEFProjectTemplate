using EF.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Service
{
    public class MasterWithExamineService<TM, TD>:MasterDetailService<TM,TD>
        where TM : MasterWithExamineEntity, new()
        where TD : DetailEntity, new()
    {
        public override void Save(TM m, List<TD> ds)
        {
            m.IfExamine = "-1";
            //m.Operator = "";
            m.OperatorDate = DateTime.Now;
            base.Save(m, ds);
        }

        public virtual void Examnite(string id,string Operator)
        {
            var m = TMService.Get(id);
            m.IfExamine="1";
            m.Operator=Operator;
            m.ExamineDate=DateTime.Now;
            m.OperatorDate=DateTime.Now;
            TMService.Save(m);
        }
        public virtual void Terminate(string id, string Operator)
        {
            var m = TMService.Get(id);
            m.IfExamine = "-1";
            m.Operator = Operator;
            //m.ExamineDate = DateTime.Now;
            m.OperatorDate = DateTime.Now;
            TMService.Save(m);
        }

    }
}
