using EF.Core.Context;
using EF.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Dynamic;

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

        public PagedResult<T> Query(QueryObject param)
        {
            IQueryable<T> query = Set;
            for(int i=0;i<param.Count;i++)
            {
                var key = param.Keys.ToArray()[i];
                var val = param[key];

                //从对象T中找到 名字与key相同的对象，并且根据Attribute找到对比类型，进行筛选
                
               
            }

            query = query.OrderBy(param.sortField,param.sortOrder);

            return new PagedResult<T>
            {
                data = query.Skip(param.pageIndex * param.pageSize).Take(param.pageSize).ToList(),
                total = query.Count()
            };
        }

    }
}
