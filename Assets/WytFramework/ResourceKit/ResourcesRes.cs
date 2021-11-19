using UnityEngine;

namespace WytFramework.ResourceKit
{
    public class ResourcesRes : Res
    {
        public const string PREFIX = "resources://";

        public override void Load()
        {
            var resourceName = Name.Remove(0, ResourcesRes.PREFIX.Length);
            Asset = Resources.Load(resourceName);
            State = ResState.Loaded;
        }

        public override void UnLoad()
        {
            //卸载操作
            Resources.UnloadAsset(Asset);
            State = ResState.NotLoad;
        }
    }
}