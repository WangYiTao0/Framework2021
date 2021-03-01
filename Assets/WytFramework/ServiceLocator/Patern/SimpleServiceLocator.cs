using System;
using System.Collections.Generic;
using UnityEngine;

namespace WytFramework.ServiceLocator.Patern
{
    public class SimpleServiceLocator
    {
        private Dictionary<Type, Func<object>> mSeriviceFactorys = new Dictionary<Type, Func<object>>();

        public T GetService<T>() where T : class
        {
            return mSeriviceFactorys[typeof(T)].Invoke() as T;
        }
        public void AddService<T>(Func<object> factory) where T : class
        {
            mSeriviceFactorys.Add(typeof(T),factory);
        }
    }
}