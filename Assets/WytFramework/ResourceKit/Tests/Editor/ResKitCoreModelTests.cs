using NUnit.Framework;

namespace WytFramework.ResourceKit.Tests
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
            Assert.AreEqual(ResState.Loaded,customRes.State);
        }

        /// <summary>
        /// C create
        /// U update
        /// R retrive 获取
        /// D Delete
        /// </summary>
        [Test]
        public void _02_ResMgrCURDTest()
        {
            var customRes = new TestRes()
            {
                Name = "amazon",
            };

            var resMgr = ResMgr.Instance;
            resMgr.LoadedResources.Add(customRes.Name,customRes);
            
            Assert.IsTrue(resMgr.LoadedResources.ContainsKey(customRes.Name));
            Assert.AreSame(resMgr.LoadedResources[customRes.Name], customRes);

            resMgr.LoadedResources.Remove(customRes.Name);
            Assert.IsFalse(resMgr.LoadedResources.ContainsKey(customRes.Name));

        }
    }
}
