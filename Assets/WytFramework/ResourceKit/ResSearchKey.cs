using System;

namespace WytFramework.ResourceKit
{
    public class ResSearchKey
    {
        /// <summary>
        /// 资源地址(前缀 + 资源路径)
        /// </summary>
        public string Address { get; private set; }
        
        /// <summary>
        /// 资源的类型
        /// </summary>
        public Type ResType { get; private set; }

        public ResSearchKey(string address, Type resType)
        {
            ResType = resType;
            Address = address;
        }
    }
}