﻿using System;
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
        
        public object CreateModuleByName(string name)
        {
            return null;
        }

        public object CreateModuleByType(Type type)
        {
            if (_typeCache.Contains(type))
            {
                return type.GetConstructors().First().Invoke(null);
            }

            return null;
        }

        public object CreateModulesByName(string name)
        {
            return null;
        }

        public object CreateModulesByType(Type type)
        {
            return _typeCache.Select(t => t.GetConstructors().First().Invoke(null));
        }
    }
}