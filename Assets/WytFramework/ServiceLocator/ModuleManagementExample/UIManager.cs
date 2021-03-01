using UnityEngine;

namespace WytFramework.ServiceLocator.ModuleManagementExample
{
    public interface IUIManager : IModule
    {
        void DoSomething();
    }
    public class UIManager : IUIManager
    {
        public IResManager ResManager { get; set; }
        public IEventManager EventManager { get; set; }
        
        public void DoSomething()
        {
            Debug.Log("UIManager DoSomething");
            
            ResManager.DoSomething();
            EventManager.DoSomething();
        }

        public void InitModule()
        {
            
        }
    }
}