using System;
using System.Collections;
using UnityEngine;

namespace WytFramework.ResourceKit
{
    /// <summary>
    /// 通过Resources 加载资源，前缀是 resources://
    /// </summary>
    public class ResourcesRes : Res
    {
        public const string PREFIX = "resources://";

        public override void Load()
        {
            var resourceName = Name.Remove(0, ResourcesRes.PREFIX.Length);
            Asset = Resources.Load(resourceName);
            State = ResState.Loaded;
        }


        public override void LoadAsync(Action<bool, Res> onLoad)
        {
            State = ResState.Loading;
            CoroutineRunner.Instance.StartCoroutine(DoLoadAsync(onLoad));
        }

        private IEnumerator DoLoadAsync(Action<bool, Res> onLoad)
        {
            var resourceName = Name.Remove(0, ResourcesRes.PREFIX.Length);
            var loadRequest = Resources.LoadAsync(resourceName);
            yield return loadRequest;
            if (loadRequest.asset)
            {
                Asset = loadRequest.asset;
                State = ResState.Loaded;
                onLoad(true, this);
            }
            else
            {
                State = ResState.NotLoad;
                onLoad(false, null);
            }
        }
        
        public override void UnLoad()
        {
            //卸载操作
            Resources.UnloadAsset(Asset);
            State = ResState.NotLoad;
        }

    }
}