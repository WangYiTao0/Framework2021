using System.Collections.Generic;
using WytFramework.Singleton;

namespace WytFramework.ResourceKit
{
    public class ResMgr : Singleton <ResMgr>
    {
        public ResMgr()
        {
            
        }

        private Dictionary<string, Res> _loadedResources = new Dictionary<string, Res>();

        public Dictionary<string, Res> LoadedResources
        {
            get { return _loadedResources; }
        }

        public void OnResUnloaded(string name)
        {
            _loadedResources.Remove(name);
        }
    }
}