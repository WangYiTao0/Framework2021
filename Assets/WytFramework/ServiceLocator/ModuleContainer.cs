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
            // 申请对象
            var moduleSearchKeys = ModuleSearchKeys.Allocate<T>();
            
            var module = _moduleCache.GetModule(moduleSearchKeys);

            if (module == null)
            {
                module = _moduleFactory.CreateModule(moduleSearchKeys);

                _moduleCache.AddModule(moduleSearchKeys, module);
            }

            // 回收对象
            moduleSearchKeys.Release2Pool();
            return module as T;
        }
        
        public IEnumerable<T> GetAllModules<T>() where T : class
        {
            // 申请对象
            var moduleSearchKeys = ModuleSearchKeys.Allocate<T>();
            
            var modules = _moduleCache.GetAllModules() as IEnumerable<object>;

            if (modules == null|| !modules.Any())
            {
                modules = _moduleFactory.CreateAllModules() as IEnumerable<object>;

                foreach (var module in modules)
                {
                    _moduleCache.AddModule(moduleSearchKeys, module);
                }
            }
            // 回收对象
            moduleSearchKeys.Release2Pool();
            
            return modules.Select(m => m as T);
        }
        
     
    }
}
