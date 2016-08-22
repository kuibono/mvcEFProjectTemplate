using EF.Core.Context;
using EF.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Service
{
    public class MasterDetailService<TM, TD>
        where TM : StringKeyEntity, new()
        where TD : DetailEntity, new()
    {
        public StringKeyServiceBase<TM> TMService = new StringKeyServiceBase<TM>();
        private StringKeyServiceBase<TD> TDService = new StringKeyServiceBase<TD>();

        private ContextBase _CurrentContext = new ContextBase();
        public ContextBase CurrentContext
        {

            get
            {
                return _CurrentContext;
            }
            set
            {
                _CurrentContext = value;
            }
        }

        public TM Get(string id)
        {
            return TMService.Get(id);
        }

        public virtual void Save(TM m, List<TD> ds)
        {
            var set = CurrentContext.Set<TM>();
            var tDSet = CurrentContext.Set<TD>();
            if (string.IsNullOrEmpty(m.Id))
            {
                m.Id = TMService.GenerateKey();
            }

            if (m._state != "modified")
            {
                set.Add(m);
            }

            ds.ForEach(d =>
            {
                switch (d._state)
                {
                    case "added":
                        {
                            if (string.IsNullOrEmpty(d.Id))
                            {
                                d.Id = TDService.GenerateKey();
                                tDSet.Add(d);
                            }
                        }
                        break;
                    case "modified":
                        {
                            var itemInDb = tDSet.Find(d.Id);
                            itemInDb = d;
                            CurrentContext.Entry(itemInDb).State = System.Data.Entity.EntityState.Modified;
                        }
                        break;
                    case "removed":
                        set.Remove(set.Find(d.Id));
                        break;
                }
            });

            CurrentContext.SaveChanges();
        }

        public virtual List<TD> GetDetails(string key)
        {
            var set = CurrentContext.Set<TD>();
            return set.Where(p => p.MasterKey == key).ToList();
        }
    }
}
