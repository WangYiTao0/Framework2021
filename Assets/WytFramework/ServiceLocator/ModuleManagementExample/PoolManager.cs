using UnityEngine;

namespace WytFramework.ServiceLocator.ModuleManagementExample
{
    public interface IPoolManager : IModule
    {
        void DoSomething();
    }
    public class PoolManager : IPoolManager
    {

        public void DoSomething()
        {
            Debug.Log("PoolManager DoSomething");
        }

        public void InitModule()
        {
            
        }
    }
}