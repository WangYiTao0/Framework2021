// Use the Assert class to test conditions.
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace WytFramework.Singleton.Tests
{
    public class MonoSingletonTests
    {
        public class MonoClass : MonoSingleton<MonoClass>
        {
            
        }

        [Test]
        public void _2_MonoSinglton_AreSame_Test()
        {
            var objA = MonoClass.Instance;
            var objB = MonoClass.Instance;
            Assert.AreSame(objA, objB);
        
            //测试可以找到MonoClass
            var monoClass = GameObject.Find("MonoClassA");
            Assert.IsNotNull(monoClass);
            Object.Destroy(monoClass);
        }
    }
}