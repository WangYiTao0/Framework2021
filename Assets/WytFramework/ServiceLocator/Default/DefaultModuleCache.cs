using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WytFramework.ServiceLocator.Default
{
    public class DefaultModuleCache  : IModuleCache
    {
        private Dictionary<Type, List<object>> _modulesByType = new Dictionary<Type, List<object>>();

        private Dictionary<string, List<object>> _mdulesByName = new Dictionary<string, List<object>>();

        public object GetModuleByName(string name)
        {
            List<object> output = null;
            if (_mdulesByName.TryGetValue(name, out output))
            {
                return output.FirstOrDefault();
            }

            return null;
        }

        public object GetModuleByType(Type type)
        {
            List<object> output = null;
            if (_modulesByType.TryGetValue(type, out output))
            {
                return output.FirstOrDefault();
            }

            return null;
        }

        public object GetModulesByName(string name)
        {
            List<object> output = null;
            if (_mdulesByName.TryGetValue(name, out output))
            {
                
            }

            return output;
        }

        public object GetModulesByType(Type type)
        {
            List<object> output = null;
            if (_modulesByType.TryGetValue(type, out output))
            {
             
            }

            return output;
        }

        public void AddModuleByName(string name, object module)
        {
            if (_mdulesByName.ContainsKey(name))
            {
                _mdulesByName[name].Add(module);
            }
            else
            {
                _mdulesByName.Add(name, new List<object>(){module});
            }
        }

        public void AddModuleByType(Type type, object module)
        {
            if (_modulesByType.ContainsKey(type))
            {
                _modulesByType[type].Add(module);
            }
            else
            {
                _modulesByType.Add(type, new List<object>(){module});
            }
        }

        public void AddModulesByName(string name, object modules)
        {
            var moduleCollection = (IEnumerable<object>) modules;
            
            if (_mdulesByName.ContainsKey(name))
            {
                _mdulesByName[name].AddRange(moduleCollection);
            }
            else
            {
                _mdulesByName.Add(name, moduleCollection.ToList());
            }
        }

        public void AddModulesByType(Type type, object modules)
        {
            var moduleCollection = (IEnumerable<object>) modules;
            
            if (_modulesByType.ContainsKey(type))
            {
                _modulesByType[type].AddRange(moduleCollection);
            }
            else
            {
                _modulesByType.Add(type, moduleCollection.ToList());
            }
        }
    }
}