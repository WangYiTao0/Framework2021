using UnityEngine;

namespace WytFramework.ServiceLocator.ModuleManagementExample
{
    public class UIManager
    {
        public ResManager ResManager { get; private set; }
        public EventManager EventManager { get; private set; }
        public UIManager(ResManager resManager, EventManager eventManager)
        {
            ResManager = resManager;
            EventManager = eventManager;
        }

        public void DoSomething()
        {

            Debug.Log("UIManager DoSomething");
        }
    }
}