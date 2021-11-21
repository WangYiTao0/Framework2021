using System;
using System.Collections.Generic;
using System.Linq;

namespace WytFramework.DataStructure
{
    public class TableIndex<TKeyType, TDataItem>
    {
        private Dictionary<TKeyType, List<TDataItem>> _index = new Dictionary<TKeyType, List<TDataItem>>();

        private Func<TDataItem, TKeyType> _getKeyByDataItem = null;


        public TableIndex(Func<TDataItem, TKeyType> keyGetter)
        {
            _getKeyByDataItem = keyGetter;
        }

        public void Add(TDataItem dataItem)
        {
            var key = _getKeyByDataItem(dataItem);

            if (_index.ContainsKey(key))
            {
                _index[key].Add(dataItem);
            }
            else
            {
                _index.Add(key, new List<TDataItem>()
                {
                    dataItem
                });
            }
        }

        public void Remove(TDataItem dataItem)
        {
            var key = _getKeyByDataItem(dataItem);

            _index[key].Remove(dataItem);
        }

        public IEnumerable<TDataItem> Get(TKeyType key)
        {
            List<TDataItem> retList = null;

            if (_index.TryGetValue(key, out retList))
            {
                return retList;
            }

            // 返回一个空的集合
            return Enumerable.Empty<TDataItem>();
        }

        // 新增
        public void Clear()
        {
            _index.Clear();
        }
    }
}