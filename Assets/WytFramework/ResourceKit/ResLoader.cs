using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace WytFramework.ResourceKit
{
    /// <summary>
    /// Res 的服务类,主要面向客户 停工简化的资源加载和卸载API
    /// </summary>
    public class ResLoader
    {

        private Dictionary<string, Res> _loadedResources = new Dictionary<string, Res>();

        public T Load<T>(string assetPathOrName) where T : Object
        {
            Res res = LoadRes(assetPathOrName);
            if (res == null)
            {
                Debug.LogError($"不存在的资源类型 : {assetPathOrName}");
                return null;
            }

            return res.Asset as T;
        }

        public void LoadAsync(string address, Action<bool, Res> onload)
        {
            LoadResAsync(address, onload);
        }

        /// <summary>
        /// 从Cache中获得资源
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        Res GetResFromCache(string address)
        {
            Res res = null;
            //先判断当前脚本有没有加载过资源，加载过则直接返回
            if (_loadedResources.TryGetValue(address, out res))
            {
                return res;
            }
            
            //如果没有在当前叫本加载过，则判断资源共享池中是否加载过(其他叫本是否正在使用资源)
            res = ResMgr.Instance.GetRes(address);
            if (res != null)
            {
                res.Retain();
                //记录到当前的脚本记录中
                _loadedResources.Add(res.Name,res);
                
                return res;
            }

            return null;
        }

        void Add2LoadedResources(Res res)
        {
            res.Retain();
            _loadedResources.Add(res.Name,res);
        }
        
        public Res LoadRes(string address)
        {
            var res = GetResFromCache(address);
            if (res != null)
            {
                return res;
            }
            
            //如果都未记录，则通过ResFactory.Create 创建资源
            res = ResFactory.Create(address);

            if (res == null) return null;
            
            //做加载操作
            res.Load();
            //记录到资源共享池中
            ResMgr.Instance.AddRes(res);

            //添加到ResLoader已加载的列表
            Add2LoadedResources(res);
            
            res.Load();
            
            return res;
        }

        public void LoadResAsync(string address, Action<bool, Res> onLoad)
        {
            var res = GetResFromCache(address);
            if (res != null)
            {
                onLoad(true, res);
                return;
            }
            
            //如果都未记录，则通过ResFactory.Create 船舰资源
            res = ResFactory.Create(address);
            if (res == null)
            {
                onLoad(false, null);
                return;
            }
            //记录到资源共享池中
            ResMgr.Instance.AddRes(res);
            //添加到ResLoader以加载的列表
            Add2LoadedResources(res);
            //做加载操作
            res.LoadAsync(onLoad);
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