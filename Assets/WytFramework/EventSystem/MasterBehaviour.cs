using System;
using System.Collections.Generic;
using UnityEngine;

namespace WytFramework.EventSystem
{
    public abstract class MasterBehaviour : MonoBehaviour
    {
        private List<System.Action> _unRegisterEventActions = new List<System.Action>();
        public void Register<T>(Action<T> onReceive)
        {
            TypeEventSystem.Register<T>(onReceive);
            
            _unRegisterEventActions.Add(()=>{
                TypeEventSystem.UnRegister<T>(onReceive);
            });
        }
        
        public void Send<T>(T eventKey)
        {
            TypeEventSystem.Send<T>(eventKey);
        }

        public void UnRegister<T>(Action<T> onReceive)
        {
            TypeEventSystem.UnRegister<T>(onReceive);
        }
        public  void UnRegisterAll()
        {
            _unRegisterEventActions.ForEach(action=>action());
            _unRegisterEventActions.Clear();
        }
    }
}