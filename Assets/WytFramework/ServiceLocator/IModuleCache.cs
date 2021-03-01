using System;
using System.Collections;
using System.Collections.Generic;

namespace WytFramework.ServiceLocator
{
    public interface IModuleCache
    {
        object GetModule(ModuleSearchKeys keys);

        object GetAllModules();

        void AddModule(ModuleSearchKeys keys, object module);
        


    }
}