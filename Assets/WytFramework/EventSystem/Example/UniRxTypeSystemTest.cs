using System;
using UniRx;
using UnityEngine;

namespace WytFramework.EventSystem.Example
{
    public class UniRxTypeSystemTest : MonoBehaviour
    {
        class A
        {
        }

        class B
        {
            public int    Age;
            public string Name;
        }

        private IDisposable _eventADisposable;
    

        private void Start()
        {
            _eventADisposable = UniRxTypeEventSystem.GetEvent<A>()
                .Subscribe(ReceiveA); // 可以获取 IDisposable 对象

            UniRxTypeEventSystem.GetEvent<B>()
                .Subscribe(ReceiveB)
                .AddTo(this); // 可以绑定
        }

        void ReceiveA(A a)
        {
            Debug.Log("received A");
        }

        void ReceiveB(B b)
        {
            Debug.LogFormat("received B:{0} {1}", b.Name, b.Age);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                UniRxTypeEventSystem.Send(new A());
            }

            if (Input.GetMouseButtonDown(1))
            {
                UniRxTypeEventSystem.Send(new B()
                {
                    Age = 10,
                    Name = "wyt"
                });
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                _eventADisposable.Dispose();
            }
        }
    }
}