using System;
using UnityEngine;

namespace WytFramework.ServiceLocator.ModuleManagementExample
{
    public class ModuleManagerConfig : MonoBehaviour
    {
        private void Start()
        {
            var poolManager = new PoolManager();

            var resManager = new ResManager(poolManager);
            var eventManager = new EventManager(poolManager);

            var uiManager = new UIManager(resManager,eventManager);
        }
    }
}