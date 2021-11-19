using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using WytFramework.ResourceKit;


namespace WytFramework.Tests
{
    public class _ResKitPlayModeTest
    {

        [UnityTest]
        public IEnumerator _01_ResourceResLoadAsyncTest()
        {
            var resLoader = new ResLoader();

            var loaded = false;
            AudioClip clip = null;
            //异步记载一个资源
            resLoader.LoadAsync("resources://Simple Swish 1", (succeed,res) =>
            {
                if (succeed)
                {
                    clip = res.Asset as AudioClip;
                    loaded = true;
                }
                else
                {
                    loaded = true;
                }
            });

            while (!loaded)
            {
                yield return null;
            }
            
            Assert.IsNotNull(clip);
        }

        [UnityTest]
        public IEnumerator _02_LoadAsyncTwiceTest()
        {
            var resLoader = new ResLoader();
            resLoader.LoadAsync("resources://Simple Swish 1",(b,res)=>{});
            resLoader.LoadAsync("resources://Simple Swish 1",(b,res)=>{});

            Assert.Pass();
            yield return null;
        }
    }
}