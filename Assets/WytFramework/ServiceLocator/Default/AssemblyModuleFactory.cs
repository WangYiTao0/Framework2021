using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WytFramework.ServiceLocator.Default
{
    public class AssemblyModuleFactory : IModuleFactory
    {
        private readonly List<Type> _concreteTypeCache;

        /// <summary>
        /// 抽象类型和具体类型 对应的字典
        /// </summary>
        private Dictionary<Type, Type> _abstractToConcrete = new Dictionary<Type, Type>();
        
        public AssemblyModuleFactory(Assembly assembly, Type baseModuleType)
        {
            _concreteTypeCache = assembly
                .GetTypes()
                .Where(t => baseModuleType.IsAssignableFrom(t) && !t.IsAbstract)
                .ToList();
            
            // 具体类型的父接口类型
            foreach (var type in _concreteTypeCache)
            {
                var interfaces = type.GetInterfaces();

                foreach (var @interface in interfaces)
                {
                    // 不是 Module 接口的父类型
                    if (baseModuleType.IsAssignableFrom(@interface) && @interface != baseModuleType)
                    {
                        _abstractToConcrete.Add(@interface, type);
                    }
                }
            }
        }


        public object CreateModule(ModuleSearchKeys keys)
        {
            if (keys.Type.IsAbstract)
            {
                if (_abstractToConcrete.ContainsKey(keys.Type))
                {
                    return _abstractToConcrete[keys.Type].GetConstructors().First().Invoke(null);
                }
            }
            else
            {
                if (_concreteTypeCache.Contains((keys.Type)))
                {
                    return keys.Type.GetConstructors().First().Invoke(null);
                }
            }

            return null;
        }

        public object CreateAllModules()
        {
            return _concreteTypeCache.Select(t => t.GetConstructors().First().Invoke(null));
        }
    }
}