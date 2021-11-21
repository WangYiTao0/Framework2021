using System.Collections;
using UnityEngine;

namespace WytFramework.ResourceKit
{
    public class ResourcesRes : Res
    {
        public const string PREFIX = "resources://";
        public override void Load()
        {
            var resourceName = Name.Remove(0, ResourcesRes.PREFIX.Length);
			
            // 添加了 ResType
            Asset = Resources.Load(resourceName,ResType);
			
            State = ResState.Loaded;
			
            DispatchOnLoadEvent(true);
        }

    

        public override void LoadAsync()
        {
            State = ResState.Loading;
			
            // 存储异步任务。
            _loadAsyncTask = CoroutineRunner.Instance.StartCoroutine(DoLoadAsync());
        }

        private IEnumerator DoLoadAsync()
        {
            var resourceName = Name.Remove(0, ResourcesRes.PREFIX.Length);

            // 添加了 ResType
            var loadRequest = Resources.LoadAsync(resourceName,ResType);

            yield return loadRequest;

            if (loadRequest.asset)
            {
                Asset = loadRequest.asset;

                State = ResState.Loaded;

                DispatchOnLoadEvent(true);
            }
            else
            {
                State = ResState.NotLoad;
				
                DispatchOnLoadEvent(false);
            }

            // 异步任务完成之后，需要置空
            _loadAsyncTask = null;
        }
        public override void UnLoad()
        {
            // 卸载操作
            Resources.UnloadAsset(Asset);

            State = ResState.NotLoad;
        }
   
    }
}