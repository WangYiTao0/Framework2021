using System;
using System.Collections.Generic;
using System.Linq;

namespace WytFramework.DataStructure
{
    public class TestDataItem
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    
    public class Table<TDataItem> where TDataItem : TestDataItem
    {
        private List<TDataItem> _items = new List<TDataItem>();
        
        TableIndex<string, TDataItem> _nameIndex = new TableIndex<string, TDataItem>(item => item.Name);

        TableIndex<int, TDataItem> _ageIndex = new TableIndex<int, TDataItem>(item => item.Age);
        
        public void Add(TDataItem item)
        {
            _items.Add(item);

            _nameIndex.Add(item);
            _ageIndex.Add(item);
        }

        public void Remove(TDataItem item)
        {
            _items.Remove(item);
            
            _nameIndex.Remove(item);
            _ageIndex.Remove(item);
        }

        public void Update()
        {
            
        }

        public IEnumerable<TDataItem> Get(Func<TDataItem, bool> condition)
        {
            return _items.Where(condition);
        }
        
        public IEnumerable<TDataItem> GetByName(string name)
        {
           
            return _nameIndex.Get(name);
        }

        public IEnumerable<TDataItem> GetByAge(int age)
        {
            return _ageIndex.Get(age);
        }
    }
}