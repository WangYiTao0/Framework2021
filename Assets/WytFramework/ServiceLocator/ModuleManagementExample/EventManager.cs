using UnityEngine;

namespace WytFramework.ServiceLocator.ModuleManagementExample
{
    public interface IEventManager : IModule
    {
        void DoSomething();
    }

    public class EventManager : IEventManager
    {
        public PoolManager PoolManager { get; set; }

        public void DoSomething()
        {
            // 依赖 PoolManager
            var poolManager = new PoolManager();

            Debug.Log("EventManager DoSomeThing");
        }

        public void InitModule()
        {
            
        }
    }
}