using System;
using System.Collections;
using System.Collections.Generic;

namespace WytFramework.ServiceLocator
{
    public interface IModuleFactory
    {
        object CreateModule(ModuleSearchKeys keys);
        object CreateModules(ModuleSearchKeys keys);
    }
}