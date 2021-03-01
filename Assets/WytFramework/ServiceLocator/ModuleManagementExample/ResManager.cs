using UnityEngine;

namespace WytFramework.ServiceLocator.ModuleManagementExample
{
    public class ResManager
    {
        
        public PoolManager PoolManager { get; private set; }
        public ResManager(PoolManager poolManager)
        {
            PoolManager = poolManager;
        }

        public void DoSomething()
        {
            var poolManager = new PoolManager();

            Debug.Log("ResManager DoSomething");
        }
    }
}