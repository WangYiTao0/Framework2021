using System.Collections.Generic;
using WytFramework.Singleton;

namespace WytFramework.ResourceKit
{
    /// <summary>
    /// Res管理类 负责提供对Res的增删改查
    /// </summary>
    public class ResMgr : Singleton <ResMgr>
    {

        private ResMgr()
        {
            
        }
        
        private Dictionary<string, Res> _loadedReses = new Dictionary<string, Res>();

        public Res GetRes(ResSearchKey resSearchKey)
        {
            //TODO
            return null;
        }

        public void AddRes(Res res)
        {
            _loadedReses.Add(res.Name,res);
        }

        public void RemoveRes(string resName)
        {
            _loadedReses.Remove(resName);
        }

        public Res GetRes(string resName)
        {
            Res retRes = null;
            if (_loadedReses.TryGetValue(resName, out retRes))
            {
                return retRes;
            }

            return null;
        }

  
    }
}