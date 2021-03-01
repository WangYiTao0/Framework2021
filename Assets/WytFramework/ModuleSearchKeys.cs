using System;
using System.Collections;
using System.Collections.Generic;

namespace WytFramework
{
    public class ModuleSearchKeys
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        
        // 私有构造 防止用户自己new
        private ModuleSearchKeys(){}
        
        //默认为10个容量
        private static Stack<ModuleSearchKeys> mPool = new Stack<ModuleSearchKeys>(10);

        public static ModuleSearchKeys Allocate<T>()
        {
            ModuleSearchKeys outputKeys = null;

            outputKeys = mPool.Count != 0 ? mPool.Pop() : new ModuleSearchKeys();

            outputKeys.Type = typeof(T);

            return outputKeys;
        }
        
        public void Release2Pool()
        {
            Type = null;
            Name = null;

            mPool.Push(this);
        }
    }
}