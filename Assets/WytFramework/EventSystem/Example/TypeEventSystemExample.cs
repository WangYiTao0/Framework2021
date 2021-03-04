using System;
using UnityEngine;

namespace WytFramework.EventSystem.Example
{
    public class TypeEventSystemExample : MonoBehaviour
    {
        class A
        {
            
        }

        class B
        {
            
        }

        private void Start()
        {
            TypeEventSystem.Register<A>(ReceiveA);
            
            TypeEventSystem.Register<B>(ReceiveB);
        }
        
        void ReceiveA(A a)
        {
            Debug.Log("received A");
        }

        void ReceiveB(B b)
        {
            Debug.Log("received B");
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                TypeEventSystem.Send(new A());
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                TypeEventSystem.Send(new B());
            }
            
            if (Input.GetKeyDown(KeyCode.U))
            {
                TypeEventSystem.UnRegister<A>(ReceiveA);
                TypeEventSystem.UnRegister<B>(ReceiveB);
            }
            
        }
    }
}