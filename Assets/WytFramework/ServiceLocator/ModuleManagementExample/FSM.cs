using UnityEngine;

namespace WytFramework.ServiceLocator.ModuleManagementExample
{
    public interface IFSM : IModule
    {
        void DoSomething();
    }
    public class FSM : IFSM
    {
        
        public void DoSomething()
        {
            Debug.Log("FSM DoSomething");
        }

        public void InitModule()
        {
            
        }
    }
}