using WytFramework.ServiceLocator.Default;

namespace WytFramework.ServiceLocator.LayerdArchitectureExample
{    public interface ILogicController
    {
    }

    public class LogicLayer : AbstractModuleLayer, ILogicLayer
    {
        protected override AssemblyModuleFactory _factory
        {
            get { return new AssemblyModuleFactory(typeof(ILogicController).Assembly, typeof(ILogicController)); }
        }
    }
}