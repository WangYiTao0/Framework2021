using System.Collections.Generic;
using System.Linq;
using WytFramework.Singleton;

namespace WytFramework.ResourceKit
{
    /// <summary>
    /// Res管理类 负责提供对Res的增删改查
    /// </summary>
    public class ResMgr : Singleton <ResMgr>
    {
        private ResMgr() { }

        private ResTable _loadedReses = new ResTable();
        
        public void AddRes(Res res)
        {
            _loadedReses.Add(res);
        }

        public void RemoveRes(string resName)
        {
            var res2Remove = _loadedReses.NameIndex.Get(resName).SingleOrDefault();
            _loadedReses.Remove(res2Remove);
        }

        public Res GetRes(ResSearchKeys resSearchKeys)
        {
            return _loadedReses.NameIndex.Get(resSearchKeys.Address)
                .FirstOrDefault(res => res.ResType == resSearchKeys.ResType);
        }
        public Res GetRes(string resName)
        {
            return _loadedReses.NameIndex.Get(resName).SingleOrDefault();
        }

  
    }
}