using EF.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Service
{
    public class MasterDetailService<TM,TD> 
        where TM:StringKeyEntity ,new()
        where TD:DetailEntity,new()
    {
        private StringKeyServiceBase<TM>  TMService = new StringKeyServiceBase<TM>();
        private StringKeyServiceBase<TD> TDService = new StringKeyServiceBase<TD>();

        public TM Get(string id)
        {
            return TMService.Get(id);
        }

        public void Save(TM m,List<TD> ds)
        {

        }
    }
}
