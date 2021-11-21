using System;

namespace WytFramework.ResourceKit
{
    /// <summary>
    /// 用于创建Res,可以更具不同的地址返回不同的Res,支持Res扩展
    /// </summary>
    public class ResFactory
    {
        private static Func<ResSearchKeys, Res> _resCreator = s => null;

        /// <summary>
        /// 根据地址加载资源
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static Res Create(ResSearchKeys resSearchKeys)
        {
            if (resSearchKeys.Address.StartsWith(ResourcesRes.PREFIX))
            {
                return new ResourcesRes()
                {
                    Name = resSearchKeys.Address,
                    ResType = resSearchKeys.ResType
                };
            }
            return _resCreator.Invoke(resSearchKeys);
        }
        
        /// <summary>
        /// 注册自定义的资源的创建功能
        /// </summary>
        /// <param name="customResCreator"></param>
        public static void RegisterCustomRes(Func<ResSearchKeys, Res> customResCreator)
        {
            _resCreator = customResCreator;
        }
    }
}