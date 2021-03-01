using UnityEngine;

namespace WytFramework.ServiceLocator.ModuleManagementExample
{
    public class EventManager
    {
        public PoolManager PoolManager { get; private set; }
        public EventManager(PoolManager poolManager)
        {
            PoolManager = poolManager;
        }

        public void DoSomething()
        {
            // 依赖 PoolManager
            var poolManager = new PoolManager();

            Debug.Log("EventManager DoSomeThing");
        }
    }
}