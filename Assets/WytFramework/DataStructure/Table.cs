using System;
using System.Collections.Generic;
using System.Linq;

namespace WytFramework.DataStructure
{
    public class Table<TDataItem> where TDataItem : class
    {
        private List<TDataItem> _items = new List<TDataItem>();

        public void Add(TDataItem item)
        {
            _items.Add(item);
        }

        public void Remov(TDataItem item)
        {
            _items.Remove(item);
        }

        public void Update()
        {
            
        }

        public IEnumerable<TDataItem> Get(Func<TDataItem, bool> condition)
        {
            return _items.Where(condition);
        }
    }
}