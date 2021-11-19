using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

namespace WytFramework.ResourceKit.Tests
{
    public class ResKitPlayModeTest
    {

        [UnityTest]
        public IEnumerator _01_ResourceResLoadAsyncTest()
        {
            var resLoader = new ResLoader();

            var loaded = false;
            AudioClip clip = null;
            //异步记载一个资源
            resLoader.LoadAsync("resources://amazon", (succeed,res) =>
            {
                if (succeed)
                {
                    clip = res.Asset as AudioClip;
                    loaded = true;
                }
                else
                {
                    loaded = false;
                }
            });

            while (!loaded)
            {
                yield return null;
            }
            
            Assert.IsNotNull(clip);
        }
    }
}