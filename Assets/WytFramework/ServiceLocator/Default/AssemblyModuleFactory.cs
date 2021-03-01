using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WytFramework.ServiceLocator.Default
{
    public class AssemblyModuleFactory : IModuleFactory
    {
        private readonly List<Type> _typeCache;
        
        public AssemblyModuleFactory(Assembly assembly, Type baseModuleType)
        {
            _typeCache = assembly
                .GetTypes()
                .Where(t => baseModuleType.IsAssignableFrom(t) && !t.IsAbstract)
                .ToList();
        }


        public object CreateModule(ModuleSearchKeys keys)
        {
            if (_typeCache.Contains(keys.Type))
            {
                return keys.Type.GetConstructors().First().Invoke(null);
            }

            return null;
        }

        public object CreateModules(ModuleSearchKeys keys)
        {
            return _typeCache.Select(t => t.GetConstructors().First().Invoke(null));
        }
    }
}