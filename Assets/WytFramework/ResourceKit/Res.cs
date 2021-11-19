using UnityEngine;

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
    
    public class Res : SimpleRC
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

        public virtual void Load()
        {
            Asset = Resources.Load(Name);
        }

        public virtual void UnLoad()
        {
            //卸载操作
            Resources.UnloadAsset(Asset);
        }

        protected override void OnZeroRef()
        {
            //自动触发卸载操作
            UnLoad();
            //删除掉 ResMgr 中的共享资源
            ResMgr.Instance.RemoveRes(Name);
        }
    }
}