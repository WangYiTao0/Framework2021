using WytFramework.ServiceLocator.Default;

namespace WytFramework.ServiceLocator.LayerdArchitectureExample
{
    public abstract class AbstractModuleLayer
    {
        private ModuleContainer _container = null;

        // 在子类中提供
        protected abstract AssemblyModuleFactory _factory { get; }

        public AbstractModuleLayer()
        {
            _container = new ModuleContainer(new DefaultModuleCache(), _factory);
        }

        public T GetModule<T>() where T : class
        {
            return _container.GetModule<T>();
        }
    }
}