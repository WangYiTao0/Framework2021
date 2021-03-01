using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WytFramework.ServiceLocator;

namespace WytFramework
{
    public class ModuleContainer
    {
        private readonly IModuleCache _moduleCache;
        private readonly IModuleFactory _moduleFactory;

        public ModuleContainer(IModuleCache cache, IModuleFactory moduleFactory)
        {
            _moduleCache = cache;
            _moduleFactory = moduleFactory;
        }

        public T GetModule<T>() where T : class
        {
            var moduleType = typeof(T);
            var module = _moduleCache.GetModuleByType(moduleType);

            if (module == null)
            {
                module = _moduleFactory.CreateModuleByType(moduleType);
                _moduleCache.AddModuleByType(moduleType,module);
            }

            return module as T;
        }

        public object GetModule(string name)
        {
            var moduleName = name;
            var module = _moduleCache.GetModuleByName(moduleName);

            if (module == null)
            {
                module = _moduleFactory.CreateModuleByName(moduleName);
                _moduleCache.AddModuleByName(moduleName,module);
            }
            return module;
        }

        public IEnumerable<T> GetModules<T>() where T : class
        {
            var moduleType = typeof(T);
            var modules = _moduleCache.GetModulesByType(moduleType) as IEnumerable<object>;
            if (modules == null)
            {
                modules = _moduleFactory.CreateModulesByType(moduleType)as IEnumerable<object>;
                _moduleCache.AddModulesByType(moduleType,modules);
            }

            return modules.Select(m => m as T);
        }
        
        public IEnumerable<object> GetModules(string name)
        {
            var moduleName = name;
            var modules = _moduleCache.GetModulesByName(moduleName)as IEnumerable<object>;

            if (modules == null || !modules.Any())
            {
                modules = _moduleFactory.CreateModulesByName(moduleName)as IEnumerable<object>;;

                _moduleCache.AddModulesByName(moduleName, modules);
            }

            return modules;
        }
    }
}
