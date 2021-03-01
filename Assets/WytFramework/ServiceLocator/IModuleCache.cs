using System;
using System.Collections;
using System.Collections.Generic;

namespace WytFramework.ServiceLocator
{
    public interface IModuleCache
    {
        object GetModuleByName(string name);
        object GetModuleByType(Type type);
        object GetModulesByName(string name);
        object GetModulesByType(Type type);

        void AddModuleByName(string name, object module);

        void AddModuleByType(Type type, object module);
        
        void AddModulesByName(string name, object modules);
        
        void AddModulesByType(Type type, object modules);


    }
}