using System;
using Object = UnityEngine.Object;

namespace WytFramework.ResourceKit
{
    public enum ResState
    {
        /// <summary>
        /// 未加载
        /// </summary>
        NotLoad = 0,
        /// <summary>
        /// 正在加载
        /// </summary>
        Loading = 1,
        /// <summary>
        /// 已加载好
        /// </summary>
        Loaded = 2,
    }
    
    /// <summary>
    /// 资源基类 负责存储资源状态,复制加载和卸载资源
    /// </summary>
    public abstract class Res : SimpleRC
    {
        /// <summary>
        /// 资源状态
        /// </summary>
        public ResState State { get; protected set; }

        /// <summary>
        /// 资源名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 加载的资源
        /// </summary>
        public Object Asset { get; set; }

        public abstract void Load();

        public abstract void UnLoad();

        public abstract void LoadAsync(Action<bool, Res> onLoad);
        
        protected override void OnZeroRef()
        {
            //自动触发卸载操作
            UnLoad();
            //删除掉 ResMgr 中的共享资源
            ResMgr.Instance.RemoveRes(Name);
        }

    }
}