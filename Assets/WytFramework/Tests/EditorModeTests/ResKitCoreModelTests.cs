using System;
using NUnit.Framework;
using UnityEngine;
using WytFramework.ResourceKit;


namespace WytFramework.Tests
{
    public class ResKitCoreModelTests
    {
        class TestRes : Res
        {
            public override void Load()
            {
                State = ResState.Loaded;
            }
            
            public override void UnLoad()
            {
                State = ResState.NotLoad;
                DispatchOnLoadEvent(true);
            }

            public override void LoadAsync(Action<bool, Res> onLoad)
            {
                State = ResState.Loading;
                onLoad(true, this);
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
        public void _03_ResLoaderTest()
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

        [Test]
        public void _04_ResourcesResTest()
        {
            var resloader = new ResLoader();
            var audioClip = resloader.Load<AudioClip>("resources://Simple Swish 1");
            
            Assert.IsNotNull(audioClip);
            var audioClipRes = resloader.LoadRes("resources://Simple Swish 1");
            
            Assert.AreEqual(1,audioClipRes.RefCount);
            Assert.AreEqual(ResState.Loaded,audioClipRes.State);

            resloader.UnloadAllAssets();
            Assert.AreEqual(0,audioClipRes.RefCount);
            Assert.AreEqual(ResState.NotLoad,audioClipRes.State);

            resloader = null;
        }

        [Test]
        public void _05_GetWrongTypeBugTest()
        {
            var resLoader = new ResLoader();
            var coinGetTextAsset = resLoader.Load<TextAsset>("resources://Simple Swish 1");

            Assert.IsNotNull(coinGetTextAsset);

            var coinGetAudioClip = resLoader.Load<AudioClip>("resources://Simple Swish 1");

            Assert.IsNotNull(coinGetAudioClip);
        }
    }
}
