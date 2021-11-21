using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WytFramework.DataStructure
{
    public abstract class Table<TDataItem> : IEnumerable where TDataItem : class
    {
        List<TDataItem> _items = new List<TDataItem>();

        public void Add(TDataItem item)
        {
            _items.Add(item);

            OnAdd(item);
        }

        public void Remove(TDataItem item)
        {
            _items.Remove(item);

            OnRemove(item);
        }
        
        public void Clear()
        {
            _items.Clear();
			
            OnClear();
        }


        // 改，由于 TDataItem 是引用类型，所以直接改值即可。
        public void Update()
        {
        }

        protected abstract void OnAdd(TDataItem item);
        protected abstract void OnRemove(TDataItem item);
        protected abstract void OnClear();
        public IEnumerable<TDataItem> Get(Func<TDataItem, bool> condition)
        {
            return _items.Where(condition);
        }
        
        // 新增
        public IEnumerator<TDataItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        
        // 新增
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}