using System;
using System.Collections.Generic;
using UniRx;

namespace WytFramework.EventSystem
{
    public class UniRxTypeEventSystem
    {
        /// <summary>
        /// 接口 只负责储存在字典
        /// </summary>
        interface IRegisterations
        {
            
        }
        /// <summary>
        /// 多个注册
        /// </summary>
        class Registerations<T> : IRegisterations
        {
            /// <summary>
            /// 不需要 List<Action<T>> 了
            /// 因为委托本身就可以一对多注册
            /// </summary>
            public Subject<T> Subject = new Subject<T>();
        }
        
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<Type, IRegisterations> _typeEventDict = new Dictionary<Type, IRegisterations>();


        /// <summary>
        /// 注册事件
        /// </summary>
        public static Subject<T> GetEvent<T>()
        {
            var type = typeof(T);

            IRegisterations registerations = null;

            if (_typeEventDict.TryGetValue(type, out registerations))
            {
                var reg = registerations as Registerations<T>;
                return reg.Subject;
            }
            else
            {
                var reg = new Registerations<T>();
                _typeEventDict.Add(type,reg);
                return reg.Subject;
            }
        }
        

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static void Send<T>(T t)
        {
            var type = typeof(T);

            IRegisterations registerations = null;

            if (_typeEventDict.TryGetValue(type, out registerations))
            {
                var reg = registerations as Registerations<T>;
                reg.Subject.OnNext(t);
            }
        }
    }
}