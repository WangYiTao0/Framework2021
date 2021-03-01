using System;
using System.Collections;
using System.Collections.Generic;

namespace WytFramework.ServiceLocator
{
    public interface IModuleCache
    {
        object GetModule(ModuleSearchKeys keys);

        object GetModules(ModuleSearchKeys keys);

        void AddModule(ModuleSearchKeys keys, object module);

        void AddModules(ModuleSearchKeys keys, object modules);


    }
}