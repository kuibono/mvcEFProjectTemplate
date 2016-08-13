using EF.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Service
{
    public class IdentityServiceBase<T> : ServiceBase<T>
        where T : IdentityEntity, new()
    {
        public void Save(T t)
        {
            Save(t, t.Id);
        }

        public void Save(List<T> ts)
        {
            ts.ForEach(t => {
                if (t._state == "added")
                {
                    Set.Add(t);
                }
                else if (t._state == "modified")
                {
                    var itemInDb = Get(t.Id);
                    itemInDb = t;
                    CurrentContext.Entry(itemInDb).State = EntityState.Modified;
                   
                }
                else if (t._state == "removed")
                {
                    Set.Remove(Get(t.Id));
                }
            });

            CurrentContext.SaveChanges();
        }
    }
}
