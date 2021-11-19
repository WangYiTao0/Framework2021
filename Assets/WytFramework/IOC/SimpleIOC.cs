using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace AsFramework.Utils
{
    public class SimpleIOCInject : Attribute {}
    public class SimpleIOC : ISimpleIOC
    {
        //HashSet中储存的是不重复的内容
        private HashSet<Type> _registeredType = new HashSet<Type>();
        
        // 用来存储 Instance 的字典
        Dictionary<Type,object> _instances = new Dictionary<Type, object>();

        private Dictionary<Type, Type> _dependency = new Dictionary<Type, Type>();
        
        public void Register<T>()
        {
            _registeredType.Add(typeof(T));
        }
        public void RegisterInstance<T>(object instance)
        {
            var type = typeof(T);
            
            _instances.Add(type,instance);
        }
        public void RegisterInstance(object instance)
        {
            var type = instance.GetType();
            _instances.Add(type,instance);
        }
        public void Register<TBase, TConcrete>() where TConcrete : TBase
        {
            var concreteObj = typeof(TConcrete);
            var baseObj = typeof(TBase);
            
            _dependency.Add(baseObj,concreteObj);
        }
        
        public T Resolve<T>() where T : class
        {
            var type = typeof(T);

            return Resolve(type) as T;
        }

        // 把原来的 T Resolve<T>() 中的根据类型创建实例的部分提取了出来，提供给 Inject 调用
        object Resolve(Type type)
        {
            if (_instances.ContainsKey(type))
            {
                return _instances[type];
            }

            if (_dependency.ContainsKey(type))
            {
                // 转换 BaseType 为 ConcreteType
                return Activator.CreateInstance(_dependency[type]);
            }

            if (_registeredType.Contains(type))
            {
                return Activator.CreateInstance(type);
            }

            return default;
        }

        public void Inject(object obj)
        {
            foreach (var propertyInfo in obj.GetType().GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(SimpleIOCInject)).Any()))
            {
                var instance = Resolve(propertyInfo.PropertyType);

                if (instance != null)
                {
                    propertyInfo.SetValue(obj, instance);
                }
                else
                {
                    Debug.LogErrorFormat("不能获取类型为:{0} 的对象", propertyInfo.PropertyType);
                }
            }
        }

        public void Clear()
        {
            _registeredType.Clear();
            _dependency.Clear();
            _instances.Clear();
        }
    }
}