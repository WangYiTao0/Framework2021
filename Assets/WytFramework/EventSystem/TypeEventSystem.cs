using System;
using System.Collections.Generic;

namespace WytFramework.EventSystem
{
    public class TypeEventSystem
    {
        
        /// <summary>
        /// 只负责存储在字典中
        /// </summary>
        public interface IRegisterations
        {
        
        }

        /// <summary>
        /// 多个注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class Registerations<T> : IRegisterations
        {

            /// <summary>
            /// 委托本身可以一对多注册
            /// </summary>
            public Action<T> OnReceive = obj => { };
        }

        /// <summary>
        /// 定义字典
        /// </summary>
        private static Dictionary<Type, IRegisterations> _typeEventDic = new Dictionary<Type, IRegisterations>();

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="OnReceive"></param>
        /// <typeparam name="T"></typeparam>
        public static void Register<T>(System.Action<T> OnReceive)
        {
            var type = typeof(T);
            IRegisterations registerations = null;

            //已经有同一个类型的注册了
            //只需要在增加委托即可
            if (_typeEventDic.TryGetValue(type, out registerations))
            {
                var reg = registerations as Registerations<T>;
                reg.OnReceive += OnReceive;
            }
            //从没注册过该类型
            //需要创建一个该类型的注册对象
            else
            {
                var reg = new Registerations<T>();
                reg.OnReceive += OnReceive;
                _typeEventDic.Add(type,reg);
            }
        }

        /// <summary>
        /// 注销事件
        /// </summary>
        /// <param name="onReceive"></param>
        /// <typeparam name="T"></typeparam>
        public static void UnRegister<T>(System.Action<T> onReceive)
        {
            var type = typeof(T);

            IRegisterations registerations = null;

            if (_typeEventDic.TryGetValue(type, out registerations))
            {
                var reg = registerations as Registerations<T>;
                reg.OnReceive -= onReceive;
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

            if (_typeEventDic.TryGetValue(type, out registerations))
            {
                var reg = registerations as Registerations<T>;
                reg.OnReceive(t);
            }
        }
    }
}