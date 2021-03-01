using UnityEngine;

namespace WytFramework.ServiceLocator.ModuleManagementExample
{
    public interface IEventManager : IModule
    {
        void DoSomething();
    }

    public class EventManager : IEventManager
    {
        public IPoolManager PoolManager { get; set; }

        public void DoSomething()
        {
            Debug.Log("EventManager DoSomeThing");
        }

        public void InitModule()
        {
            
        }
    }
}