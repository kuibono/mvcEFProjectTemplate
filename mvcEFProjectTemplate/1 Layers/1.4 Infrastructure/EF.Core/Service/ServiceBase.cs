using EF.Core.Context;
using EF.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF.Core.Service
{
    public class ServiceBase<T> where T : EntityBase
    {

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

        public DbSet<T> Set
        {
            get
            {
                return CurrentContext.Set<T>();
            }
        }

        public T Get(object key)
        {
            return Set.Find(key);
        }

        public void Create(T t)
        {
            Set.Add(t);
            CurrentContext.SaveChanges();
        }

        public void Delete(object key)
        {
            Set.Remove(Get(key));
            CurrentContext.SaveChanges();
        }

        public void Save(T t, object key)
        {
            var itemInDb = Get(key);

            itemInDb = t;

            CurrentContext.Entry(itemInDb).State = EntityState.Modified;

            CurrentContext.SaveChanges();
        }

    }
}
