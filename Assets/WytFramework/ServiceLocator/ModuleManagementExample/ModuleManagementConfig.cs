using System;
using UnityEngine;
using WytFramework.ServiceLocator.Default;

namespace WytFramework.ServiceLocator.ModuleManagementExample
{
    public class ModuleManagementConfig : MonoBehaviour
    {
        public static ModuleContainer Container = null;
        private void Awake()
        {
            var baseType = typeof(IModule);
            var cache = new DefaultModuleCache();
            var factory = new AssemblyModuleFactory(baseType.Assembly,baseType);

            Container = new ModuleContainer(cache, factory);
            //主动去创建对象
            var poolManager = Container.GetModule<PoolManager>();
            var fsm = Container.GetModule<FSM>();
            var resManager = Container.GetModule<ResManager>();
            var eventManager = Container.GetModule<EventManager>();
            var uiManager = Container.GetModule<UIManager>();
            
            //设置依赖关系
            uiManager.EventManager = eventManager;
            uiManager.ResManager = resManager;
            eventManager.PoolManager = poolManager;
            resManager.PoolManager = poolManager;
            
            //初始化模块
            foreach (var module in Container.GetModules<IModule>())
            {
                module.InitModule();
            }
        }

        private void Start()
        {
            var uiManager = ModuleManagementConfig.Container.GetModule<UIManager>();

            uiManager.DoSomething();
        }
    }
}