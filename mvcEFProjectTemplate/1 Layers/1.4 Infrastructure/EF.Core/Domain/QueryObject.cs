using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Domain
{
    public class QueryObject : IDictionary<string, string>
    {
        public int pageIndex { get; set; }

        public int pageSize { get; set; }

        public string sortField { get; set; }

        public string sortOrder { get; set; }

        public bool ShowSummary { get; set; }


        private Dictionary<string, string> queryObjects = new Dictionary<string, string>();

        public string this[string key]
        {
            get
            {
                if (queryObjects.ContainsKey(key))
                {
                    return queryObjects[key];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (queryObjects.ContainsKey(key))
                {
                    queryObjects[key] = value;
                }
                else
                {
                    queryObjects.Add(key, value);
                }
            }
        }

        public void Add(string key, string value)
        {
            queryObjects.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return queryObjects.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get
            {
                return queryObjects.Keys;
            }
        }

        public bool Remove(string key)
        {
            return queryObjects.Remove(key);
        }

        public bool TryGetValue(string key, out string value)
        {
            try
            {
                value = queryObjects[key];
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }

        public ICollection<string> Values
        {
            get {
                return queryObjects.Values;
            }
        }

        public void Add(KeyValuePair<string, string> item)
        {
            queryObjects.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            queryObjects.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return queryObjects.ContainsKey(item.Key) && queryObjects.ContainsValue(item.Value);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            queryObjects = new Dictionary<string, string>();
            foreach(var item in array)
            {
                queryObjects.Add(item.Key, item.Value);
            }
        }

        public int Count
        {
            get { return queryObjects.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            return queryObjects.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return queryObjects.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return queryObjects.GetEnumerator();
        }
        
    }
}
