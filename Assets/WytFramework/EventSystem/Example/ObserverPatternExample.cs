using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace WytFramework.EventSystem.Example
{
    public class ObserverPatternExample : MonoBehaviour
    {
        /// <summary>
        /// 通知消息
        /// </summary>
        class NotifyEvent
        {
            
        }

        /// <summary>
        /// 主题
        /// </summary>
        class Subject
        {
            public void DoObserverInterestedThings()
            {
                Notify();
            }

            private void Notify()
            {
                TypeEventSystem.Send(new NotifyEvent());
            }
        }
        
        /// <summary>
        /// 观察者 
        /// </summary>
        class Observer
        {
            public Observer()
            {
                Subscribe();
            }

            private void Subscribe()
            {
                TypeEventSystem.Register<NotifyEvent>(Update);
            }

            private void Update(NotifyEvent obj)
            {
                Debug.Log("Received Notification");
            }

            public void Dispose()
            {
                TypeEventSystem.UnRegister<NotifyEvent>(Update);
            }
        }

        private void Start()
        {
            var subject = new Subject();
            var observerA = new Observer();
            var observerB = new Observer();

            subject.DoObserverInterestedThings();
        }
    }
}