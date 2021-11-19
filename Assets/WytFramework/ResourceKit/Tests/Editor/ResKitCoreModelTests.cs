using NUnit.Framework;
using UnityEngine;

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
            resMgr.AddRes(customRes);
            
            Assert.IsNotNull(resMgr.GetRes(customRes.Name));
            Assert.AreSame(resMgr.GetRes(customRes.Name), customRes);

            resMgr.RemoveRes(customRes.Name);
            Assert.IsNull(resMgr.GetRes(customRes.Name));
        }

        [Test]
        public void ResLoaderTest()
        {
            //注册自定义类型的Res
            ResFactory.RegisterCustomRes((address) =>
            {
                if (address.StartsWith("test://"))
                {

                    return new TestRes()
                    {
                        Name = address
                    };
                }

                return null;
            });

            //测试
            var resLoader = new ResLoader();
            var iconTextureRes = resLoader.LoadRes("test://amazon1");
            
            Assert.IsTrue(iconTextureRes is TestRes);
            Assert.AreEqual(1,iconTextureRes.RefCount);
            Assert.AreEqual(ResState.Loaded,iconTextureRes.State);
            resLoader.UnloadAllAssets();

            Assert.AreEqual(0,iconTextureRes.RefCount);
            Assert.AreEqual(ResState.NotLoad,iconTextureRes.State);
            resLoader = null;
        }
    }
}
