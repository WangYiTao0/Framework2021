using System.Collections.Generic;
using UnityEngine;

namespace WytFramework.ResourceKit
{
    public class ResLoader
    {

        private Dictionary<string, Res> _loadedResources = new Dictionary<string, Res>();

        public T Load<T>(string assetPathOrName) where T : Object
        {
            Res res = null;
            //先判断当前脚本有没有加载过资源，加载过则直接返回
            if (_loadedResources.TryGetValue(assetPathOrName, out res))
            {
                return res.Asset as T;
            }
            
            //如果没有在当前叫本加载过，则判断资源共享池中是否加载过(其他叫本是否正在使用资源)
            if (ResMgr.Instance.LoadedResources.TryGetValue(assetPathOrName, out res))
            {
                res.Retain();
                //记录到当前的脚本记录中
                _loadedResources.Add(res.Name,res);
                return res.Asset as T;
            }
        
            //如果都未记录，则创建Res
            res = new Res()
            {
                Name = assetPathOrName
            };
            //做加载操作
            res.Load();
            //记录到资源共享池中
            ResMgr.Instance.LoadedResources.Add(res.Name,res);
            res.Retain();
            
            //记录到当前脚本记录中
            _loadedResources.Add(res.Name,res);
            return res.Asset as T;
        }

        public void UnloadAllAssets()
        {
            foreach (var resKeyValue in _loadedResources)
            {
                resKeyValue.Value.Release();
            }
            _loadedResources.Clear();
        }
    }
}