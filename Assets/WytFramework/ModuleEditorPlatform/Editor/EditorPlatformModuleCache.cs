using System;
using System.Collections;
using System.Collections.Generic;
using WytFramework.ServiceLocator;

namespace WytFramework
{
    public class EditorPlatformModuleCache : IModuleCache
    {
        private IEnumerable<IEditorPlatformModule> mModules;
        
        public object GetModuleByName(string name)
        {
            throw new NotImplementedException();
        }

        public object GetModuleByType(Type type)
        {
            throw new NotImplementedException();
        }

        public object GetModulesByName(string name)
        {
            throw new NotImplementedException();
        }

        public object GetModulesByType(Type type)
        {
            return mModules;
        }

        public void AddModuleByName(string name, object module)
        {
            throw new NotImplementedException();
        }

        public void AddModuleByType(Type type, object module)
        {
            throw new NotImplementedException();
        }

        public void AddModulesByName(string name, object modules)
        {
            throw new NotImplementedException();
        }

        public void AddModulesByType(Type type, object modules)
        {
            mModules = modules as IEnumerable<IEditorPlatformModule>;
        }
    }
}