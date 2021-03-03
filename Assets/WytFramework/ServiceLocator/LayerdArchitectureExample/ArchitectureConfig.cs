using UnityEngine;

namespace WytFramework.ServiceLocator.LayerdArchitectureExample
{
    public class ArchitectureConfig : IArchitecture
    {
        public ILogicLayer LogicLayer { get; private set;}
        public IBusinessModuleLayer BusinessModuleLayer { get; private set; }
        public IPublichModuleLayer PublichModuleLayer { get; private set; }
        public IUtiltyLayer UtiltyLayer { get; private set;}
        public IBasicModuleLayer BasicModuleLayer { get; private set; }

        public static ArchitectureConfig Architecture = null;

        /// <summary>
        /// 项目启动时，自动执行
        /// </summary>
        /// <returns></returns>
        [RuntimeInitializeOnLoadMethod]

        static void Config()
        {
            Architecture = new ArchitectureConfig();
            //逻辑层配置
            Architecture.LogicLayer = new LogicLayer();
            //主动创建对象
            var LoginController = Architecture.LogicLayer.GetModule<ILogicController>();
            var userInputManager = Architecture.LogicLayer.GetModule<IUserInputManager>();
            //业务模块层配置
            Architecture.BusinessModuleLayer = new BussinessModuleLayer();
            
            var accountSystem = Architecture.BusinessModuleLayer.GetModule<IAccountSystem>();
            var missionSystem = Architecture.BusinessModuleLayer.GetModule<IMissionSystem>();
        }
    }
}