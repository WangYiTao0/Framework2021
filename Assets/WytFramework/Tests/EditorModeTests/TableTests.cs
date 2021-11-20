using System.Linq;
using NUnit.Framework;
using UnityEngine;
using WytFramework.DataStructure;

namespace WytFramework.Tests
{
    public class TableTests 
    {
        public class TestDataItem
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        [Test]
        public void TableAddGetTest()
        {
            var table = new Table<TestDataItem>();

            for (int i = 0; i < 10; i++)
            {
                table.Add(new TestDataItem()
                {
                    Name = "名字" + i,
                    Age = i,
                });
            }

            var resuilt = table.Get(item => item.Age < 5);
            
            Assert.AreEqual(5,resuilt.Count());
        }
    }
}