using NUnit.Framework;
using UnityEngine;
using WytFramework.Singleton;


namespace WytFramework.Tests
{
    public class _MonoSingletonTests
    {
        public class MonoClassA : MonoSingleton<MonoClassA>
        {
            
        }

        [Test]
        public void _01_MonoSinglton_AreSame_Test()
        {
            var objA = MonoClassA.Instance;
            var objB = MonoClassA.Instance;
            Assert.AreSame(objA, objB);
        
            //测试可以找到MonoClass
            var monoClass = GameObject.Find("MonoClassA");
            Assert.IsNotNull(monoClass);
            Object.Destroy(monoClass);
        }
    }
}