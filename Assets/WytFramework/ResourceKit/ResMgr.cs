using System.Collections.Generic;
using WytFramework.Singleton;

namespace WytFramework.ResourceKit
{
    public class ResMgr : Singleton <ResMgr>
    {
        private ResMgr()
        {
            
        }
        
        private Dictionary<string, Res> _loadedResources = new Dictionary<string, Res>();

        public void AddRes(Res res)
        {
            _loadedResources.Add(res.Name,res);
        }

        public void RemoveRes(string resName)
        {
            _loadedResources.Remove(resName);
        }

        public Res GetRes(string resName)
        {
            Res retRes = null;
            if (_loadedResources.TryGetValue(resName, out retRes))
            {
                return retRes;
            }

            return null;
        }

 
    }
}