using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WytFramework.ServiceLocator.Default
{
    public class AssemblyModuleFactory : IModuleFactory
    {
        private readonly List<Type> mConcreteTypeCache;

        /// <summary>
        /// 抽象类型和具体类型 对应的字典
        /// </summary>
        private Dictionary<Type, Type> mAbstractToConcrete = new Dictionary<Type, Type>();
        
        public AssemblyModuleFactory(Assembly assembly, Type baseModuleType)
        {
            mConcreteTypeCache = assembly
                .GetTypes()
                .Where(t => baseModuleType.IsAssignableFrom(t) && !t.IsAbstract)
                .ToList();
            
            // 具体类型的父接口类型
            foreach (var type in mConcreteTypeCache)
            {
                var interfaces = type.GetInterfaces();

                foreach (var @interface in interfaces)
                {
                    // 不是 Module 接口的父类型
                    if (baseModuleType.IsAssignableFrom(@interface) && @interface != baseModuleType)
                    {
                        mAbstractToConcrete.Add(@interface, type);
                    }
                }
            }
        }


        public object CreateModule(ModuleSearchKeys keys)
        {
            if (keys.Type.IsAbstract)
            {
                if (mAbstractToConcrete.ContainsKey(keys.Type))
                {
                    return mAbstractToConcrete[keys.Type].GetConstructors().First().Invoke(null);
                }
            }
            else
            {
                if (mConcreteTypeCache.Contains((keys.Type)))
                {
                    return keys.Type.GetConstructors().First().Invoke(null);
                }
            }

            return null;
        }

        public object CreateAllModules()
        {
            return mConcreteTypeCache.Select(t => t.GetConstructors().First().Invoke(null));
        }
    }
}