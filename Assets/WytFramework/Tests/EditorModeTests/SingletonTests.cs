using NUnit.Framework;
using WytFramework.Singleton;

namespace WytFramework.Tests
{
    public class SingletonTests
    {

        public class ClassA : Singleton<ClassA>
        {
            private ClassA()
            {
                
            }
        }

        [Test]
        public void _01_Singleton_SingltonTest()
        {
            var objA = ClassA.Instance;
            var objB = ClassA.Instance;
                
            Assert.AreSame(objA,objB);
        }

    }
}