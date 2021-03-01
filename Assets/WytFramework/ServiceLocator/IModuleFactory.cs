using System;
using System.Collections;
using System.Collections.Generic;

namespace WytFramework.ServiceLocator
{
    public interface IModuleFactory
    {
        object CreateModuleByName(string name);
        object CreateModuleByType(Type type);
        object CreateModulesByName(string name);
        object CreateModulesByType(Type type);
    }
}