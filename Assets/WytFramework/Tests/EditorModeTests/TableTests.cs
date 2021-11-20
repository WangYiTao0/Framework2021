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
        // public class TestDataItem
        // {
        //     public string Name { get; set; }
        //     public int Age { get; set; }
        // }

        [Test]
        public void _01_TableAddGetTest()
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


        [Test]
        public void _02_TableQuerySpeedTest()
        {
            var table = new Table<TestDataItem>();

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
            for (var i = 0; i < 10000; i++)
            {
                foreach (var testDataItem in table.GetByAge(150).Where(item => item.Name == "名字:150"))
                {

                }
            }

            var newTime = stopWatch.ElapsedMilliseconds;
            Debug.Log(newTime);
        }
    }
}