using UnityEngine;

namespace WytFramework.ServiceLocator.ModuleManagementExample
{
    public interface IEventManager : IModule
    {
        void DoSomething();
    }

    public class EventManager : IEventManager
    {
        private IPoolManager mPoolManager { get; set; }

        public void DoSomething()
        {
            Debug.Log("EventManager DoSomeThing");
        }

        public void InitModule()
        {
            mPoolManager = ModuleManagementConfig.Container.GetModule<IPoolManager>();
        }
    }
}