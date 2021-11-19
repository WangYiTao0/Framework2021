using System;
using System.Collections;
using NUnit.Framework;
using UnityEditor;
using Assert = UnityEngine.Assertions.Assert;

namespace WytFramework.EventSystem.Tests.Editor
{
    public class TestEventSystemTests
    {
        [Test]
        public void _1_TypeEventSystem_RegisterTest()
        {
            string receivedMsg = string.Empty;

            Action<string> onReceive = (msg) => { receivedMsg = msg; };
            
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Send("Hello");
            Assert.AreEqual(receivedMsg,"Hello");
            
            TypeEventSystem.UnRegister(onReceive);
        }

        [Test]
        public void _2_TypeEventSystem_SendTest()
        {
            var receivedCount = 0;
            Action<string> onReceive = (msg) => { receivedCount++; };
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);

            TypeEventSystem.Send("Hello");
            
            Assert.AreEqual(receivedCount,5);
            
            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);
        }
        
        [Test]
        public void _2_TypeEventSystem_UnRegisterTest()
        {
            var receivedCount = 0;
            Action<string> onReceive = (msg) => { receivedCount++; };
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);
            TypeEventSystem.Register(onReceive);
            
            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);

            TypeEventSystem.Send("Hello");
            
            Assert.AreEqual(receivedCount,2);
            

            TypeEventSystem.UnRegister(onReceive);
            TypeEventSystem.UnRegister(onReceive);

        }
    }
}