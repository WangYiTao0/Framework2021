using System;
using System.Reflection;

namespace WytFramework.Singleton
{
    public class SingletonCreator
    {
        public static T CreateSingleton<T>() where T : class, ISingleton
        {
            //获取所以私有构造函数
            var constructors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            //获取无参构造函数
            var constructor = Array.Find(constructors, c => c.GetParameters().Length == 0);

            if (constructor == null)
            {
                throw new Exception("Non-Public Constructor() not found! in " + typeof(T));
            }
            
            //通过构造函数，实现实例
            var refInstance =  constructor.Invoke(null) as T;
            refInstance.OnSingletonInit();

            return refInstance;
        }
    }
}