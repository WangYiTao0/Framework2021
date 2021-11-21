using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using WytFramework.DataStructure;
using Debug = UnityEngine.Debug;

namespace WytFramework.Tests
{
    public class TableTests 
    {
        public class TestDataItem
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        
        /// <summary>
        /// 自定义的 TestDataTable
        /// </summary>
        public class TestDataTable : Table<TestDataItem>
        {
            public TestDataTable()
            {
                NameIndex = new TableIndex<string, TestDataItem>(item => item.Name);
                AgeIndex = new TableIndex<int, TestDataItem>(item => item.Age);
            }

            public TableIndex<string, TestDataItem> NameIndex { get; private set; }
            public TableIndex<int, TestDataItem> AgeIndex { get; private set; }

            protected override void OnAdd(TestDataItem item)
            {
                NameIndex.Add(item);
                AgeIndex.Add(item);
            }

            protected override void OnRemove(TestDataItem item)
            {
                NameIndex.Remove(item);
                AgeIndex.Remove(item);
            }

            protected override void OnClear()
            {
                NameIndex.Clear();
                AgeIndex.Clear();
            }
        }

        [Test]
        public void _01_TableAddGetTest()
        {
            var table = new TestDataTable();

            for (var i = 0; i < 10; i++)
            {
                table.Add(new TestDataItem
                {
                    Name = "名字" + i,
                    Age = i
                });
            }

            var result = table.Get(item => item.Age < 5);

            Assert.AreEqual(5, result.Count());
        }


        [Test]
        public void _02_TableQuerySpeedTest()
        {
            var table = new TestDataTable();
            //生成300个数据
            for (int i = 0; i < 300; i++)
            {
                table.Add(new TestDataItem()
                {
                    Name = $"名字:{i}",
                    Age = i,
                });

            }
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            // 查询 10000 次
            for (var i = 0; i < 10000; i++)
            {
                foreach (var testDataItem in table.Get(item => item.Age == 150 && item.Name == "名字:150"))
                {
					
                }
            }

            var oldTime = stopWatch.ElapsedMilliseconds;
			
            Debug.Log(oldTime);
			
            // 追加代码
            stopWatch.Reset();
            stopWatch.Start();
			
            // 查询 10000 次
            for (var i = 0; i < 100000; i++)
            {
                foreach (var testDataItem in table.AgeIndex.Get(150).Where(item => item.Name == "名字:150"))
                {

                }
            }

            var newTime = stopWatch.ElapsedMilliseconds;
            Debug.Log(newTime);
        }
    }
}