﻿using UnityEngine;

namespace WytFramework.ServiceLocator.ModuleManagementExample
{
    public interface IResManager : IModule
    {
        void DoSomething();
    }
    public class ResManager : IResManager
    {
        public IPoolManager PoolManager { get; set; }

        public void DoSomething()
        {
            Debug.Log("ResManager DoSomething");
        }

        public void InitModule()
        {
            
        }
    }
}