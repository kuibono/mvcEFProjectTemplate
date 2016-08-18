using EF.Core.Context;
using EF.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Dynamic;
using System.Reflection;
using EF.Core.Extensions;
using System.Data.Entity.Infrastructure;

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

            PropertyInfo[] ps = typeof(T).GetProperties();

            List<object> queryParam = new List<object>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < param.Count; i++)
            {
                var key = param.Keys.ToArray()[i];
                var val = param[key];


                //从对象T中找到 名字与key相同的对象，并且根据Attribute找到对比类型，进行筛选
                var p = ps.Where(x => x.Name == key).FirstOrDefault();
                if (p != null)
                {
                    var v = (QueryTypeAttribute[])p.GetCustomAttributes(typeof(QueryTypeAttribute), false);
                    if (v != null && v.Count() > 0)
                    {
                        var qType = v.First().QType;

                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        switch (qType)
                        {
                            case EnumQueryType.Contains:
                                sb.AppendFormat("{0}.Contains(@{1})", p.Name, i);
                                break;
                            case EnumQueryType.EndWith:
                                sb.AppendFormat("{0}.EndWith(@{1})", p.Name, i);
                                break;
                            case EnumQueryType.Equals:
                                sb.AppendFormat("{0}=@{1}", p.Name, i);
                                break;
                            case EnumQueryType.GET:
                                sb.AppendFormat("{0}>=@{1}", p.Name, i);
                                break;
                            case EnumQueryType.GT:
                                sb.AppendFormat("{0}>@{1}", p.Name, i);
                                break;
                            case EnumQueryType.LET:
                                sb.AppendFormat("{0}<=@{1}", p.Name, i);
                                break;
                            case EnumQueryType.LT:
                                sb.AppendFormat("{0}<@{1}", p.Name, i);
                                break;
                            case EnumQueryType.StartWith:
                                sb.AppendFormat("{0}.StartWith(@{1})", p.Name, i);
                                break;
                        }


                        queryParam.Add(val);
                    }


                }

            }
            query = Set.Where(sb.ToString(), queryParam.ToArray()).AsQueryable();


            //排序规则
            if(string.IsNullOrEmpty(param.sortField))
            {
                param.sortField = "Id";
            }
            if (string.IsNullOrEmpty(param.sortOrder))
            {
                param.sortOrder = "Desc";
            }
            query = query.OrderBy(param.sortField, param.sortOrder);


            var result = new PagedResult<T>
            {
                data = query.Skip(param.pageIndex * param.pageSize).Take(param.pageSize).ToList(),
                total = query.Count(),
                summary = new Dictionary<string, double>()
            };

            if (param.ShowSummary)
            {
                foreach (var p in ps)
                {
                    var v = (SummaryTypeAttribute[])p.GetCustomAttributes(typeof(SummaryTypeAttribute), false);
                    if (v != null && v.Count() > 0)
                    {
                        double sum = 0;
                        var sumType = v.First().SumType;
                        //var sumItem = query.Select(p.Name) as IQueryable<int>;
                        switch (sumType)
                        {
                            case EnumSumType.Avg:
                                sum = Convert.ToDouble(query.Average(p.Name));
                                break;
                            case EnumSumType.Count:
                                sum = query.Count();
                                break;
                            case EnumSumType.Max:
                                sum = Convert.ToDouble(query.Max(p.Name));
                                break;
                            case EnumSumType.Min:
                                sum = Convert.ToDouble(query.Min(p.Name));
                                break;
                            case EnumSumType.Sum:
                                sum = Convert.ToDouble(query.Sum(p.Name));
                                break;
                            default:
                                sum = 0;
                                break;

                        }

                        result.summary.Add(p.Name, sum);
                    }
                }
            }
            //Summary

            return result;
        }

    }
}
