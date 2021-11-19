using UnityEngine.Assertions;
using WytFramework.ResourceKit;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using Assert = UnityEngine.Assertions.Assert;

namespace WytFramework
{
    public class ResKitCoreModelTests
    {
        class TestRes : Res
        {
            public override void Load()
            {
                base.Load();
                State = ResState.Loaded;
            }
            
            public override void UnLoad()
            {
                base.UnLoad();
                State = ResState.NotLoad;
            }
        }

        [Test]
        public void _01_CustomResTest()
        {
            var customRes = new TestRes()
            {
                Name = "amazon",
            };
            customRes.Load();
            Assert.IsNotNull(customRes.Asset);
        }
    }
}
