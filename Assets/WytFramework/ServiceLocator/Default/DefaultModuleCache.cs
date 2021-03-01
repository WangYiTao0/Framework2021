using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WytFramework.ServiceLocator.Default
{
    public class DefaultModuleCache  : IModuleCache
    {
        private Dictionary<Type, List<object>> _modulesByType = new Dictionary<Type, List<object>>();


        public object GetModule(ModuleSearchKeys keys)
        {
            List<object> output = null;
            if (_modulesByType.TryGetValue(keys.Type, out output))
            {
                return output.FirstOrDefault();
            }

            return null;
        }

        public object GetAllModules()
        {
            //  SelectMany 可以理解成 二维遍历
            return _modulesByType.Values.SelectMany(list => list);
        }

        public void AddModule(ModuleSearchKeys keys, object module)
        {
            if (_modulesByType.ContainsKey(keys.Type))
            {
                _modulesByType[keys.Type].Add(module);
            }
            else
            {
                _modulesByType.Add(keys.Type, new List<object>() {module});
            }
        }
    }
}