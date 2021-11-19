using System;

namespace WytFramework.ResourceKit
{
    /// <summary>
    /// 用于创建Res,可以更具不同的地址返回不同的Res,支持Res扩展
    /// </summary>
    public class ResFactory
    {
        private static Func<string, Res> _resCreator = s => null;

        /// <summary>
        /// 根据地址加载资源
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static Res Create(string address)
        {
            if (address.StartsWith(ResourcesRes.PREFIX))
            {
                return new ResourcesRes()
                {
                    Name = address
                };
            }
            return _resCreator.Invoke(address);
        }
        
        /// <summary>
        /// 注册自定义的资源的创建功能
        /// </summary>
        /// <param name="customResCreator"></param>
        public static void RegisterCustomRes(Func<string, Res> customResCreator)
        {
            _resCreator = customResCreator;
        }
    }
}