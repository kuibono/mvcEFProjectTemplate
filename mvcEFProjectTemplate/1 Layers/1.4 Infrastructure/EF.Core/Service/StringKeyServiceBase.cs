using EF.Core.Domain;
using EF.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EF.Core.Service
{
    public class StringKeyServiceBase<T> : ServiceBase<T>
        where T : StringKeyEntity, new()
    {

        public override void Create(T t)
        {
            if (string.IsNullOrEmpty(t.Id))
            {
                t.Id = GenerateKey();
            }
            base.Create(t);
        }

        public void Save(T t)
        {

            Save(t, t.Id);
        }

        public void Save(List<T> ts)
        {
            ts.ForEach(t =>
            {
                if (t._state == "added")
                {
                    if (string.IsNullOrEmpty(t.Id))
                    {
                        t.Id = GenerateKey();
                    }
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

        public string GenerateKey()
        {
            lock(Set)
            {
                string format = "yyyyMMdd#######";

                var v = (KeyFormatAttribute[])typeof(T).GetCustomAttributes(typeof(KeyFormatAttribute), false);
                if (v == null || v.Count() == 0)
                {

                }
                else
                {
                    format = v[0].Format;
                }

                string result = format;

                #region yyyy
                if (format.Contains("yyyy"))
                {
                    result = result.Replace("yyyy", DateTime.Now.Year.ToString());
                }
                #endregion

                #region MM
                if (format.Contains("MM"))
                {
                    if (DateTime.Now.Month < 10)
                    {
                        result = result.Replace("MM", "0" + DateTime.Now.Month.ToString());
                    }
                    else
                    {
                        result = result.Replace("MM", DateTime.Now.Month.ToString());
                    }
                }
                #endregion

                #region dd
                if (format.Contains("dd"))
                {
                    if (DateTime.Now.Day < 10)
                    {
                        result = result.Replace("dd", "0" + DateTime.Now.Day.ToString());
                    }
                    else
                    {
                        result = result.Replace("dd", DateTime.Now.Day.ToString());
                    }
                }
                #endregion

                #region HH
                if (format.Contains("HH"))
                {
                    if (DateTime.Now.Hour < 10)
                    {
                        result = result.Replace("HH", "0" + DateTime.Now.Hour.ToString());
                    }
                    else
                    {
                        result = result.Replace("HH", DateTime.Now.Hour.ToString());
                    }
                }
                #endregion

                #region mm
                if (format.Contains("mm"))
                {
                    if (DateTime.Now.Minute < 10)
                    {
                        result = result.Replace("mm", "0" + DateTime.Now.Minute.ToString());
                    }
                    else
                    {
                        result = result.Replace("mm", DateTime.Now.Minute.ToString());
                    }
                }
                #endregion mm

                #region ss
                if (format.Contains("ss"))
                {
                    if (DateTime.Now.Second < 10)
                    {
                        result = result.Replace("ss", "0" + DateTime.Now.Second.ToString());
                    }
                    else
                    {
                        result = result.Replace("ss", DateTime.Now.Second.ToString());
                    }
                }
                #endregion mm

                #region fff
                if (format.Contains("fff"))
                {
                    if (DateTime.Now.Millisecond < 10)
                    {
                        result = result.Replace("fff", "00" + DateTime.Now.Minute.ToString());
                    }
                    else if (DateTime.Now.Millisecond < 100)
                    {
                        result = result.Replace("fff", "0" + DateTime.Now.Minute.ToString());
                    }
                    else
                    {
                        result = result.Replace("fff", DateTime.Now.Minute.ToString());
                    }
                }
                #endregion

                //去掉#
                result = result.Replace("#", "");

                var sharpCount = format.ToCharArray().Count(p => p == '#');
                var number = FixChar(GetMaxId(result), '0', sharpCount);

                result += number;
                return result;
            }
            

        }


        private long GetMaxId(string pre)
        {
            var objList = Set.Where(p => p.Id.StartsWith(pre)).OrderByDescending(p => p.Id);
            if (objList.Count() == 0)
            {
                return 1;
            }
            else
            {
                var maxnumber = objList.First().Id.Replace(pre, "");
                return Convert.ToInt64(maxnumber) + 1;
            }
        }

        private string FixChar(long num, char c, int length)
        {
            var result = num.ToString();

            var charNumber = length - result.Length;
            for (int i = 0; i < charNumber; i++)
            {
                result = c + result;
            }
            return result;
        }
    }
}
