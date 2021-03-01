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
            var moduleSearchKeys = new ModuleSearchKeys(){ Type = typeof(T)};
            var module = _moduleCache.GetModule(moduleSearchKeys);

            if (module == null)
            {
                module = _moduleFactory.CreateModule(moduleSearchKeys);

                _moduleCache.AddModule(moduleSearchKeys, module);
            }

            return module as T;
        }
        
        public IEnumerable<T> GetModules<T>() where T : class
        {
            var moduleSearchKeys = new ModuleSearchKeys(){ Type = typeof(T)};
            var modules = _moduleCache.GetModules(moduleSearchKeys) as IEnumerable<object>;

            if (modules == null)
            {
                modules = _moduleFactory.CreateModules(moduleSearchKeys) as IEnumerable<object>;

                _moduleCache.AddModules(moduleSearchKeys, modules);
            }

            return modules.Select(m => m as T);
        }
        
     
    }
}
