using System;
using WytFramework.ServiceLocator.Default;

namespace WytFramework.ServiceLocator.LayerdArchitectureExample
{
    public interface ISystem
    {
        
    }

    public class BussinessModuleLayer : AbstractModuleLayer, IBusinessModuleLayer
    {
        protected override AssemblyModuleFactory _factory
        {
            get { return new AssemblyModuleFactory(typeof(ISystem).Assembly, typeof(ISystem)); }
        }
    }
}