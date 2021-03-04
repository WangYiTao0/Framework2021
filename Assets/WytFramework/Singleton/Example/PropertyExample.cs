using System;
using UnityEngine;

namespace WytFramework.Singleton.Example
{
    public class PropertyExample : MonoBehaviour
    {
        /// <summary>
        /// 基类定义
        /// </summary>
        public class BaseManager : MonoBehaviour
        {
            
        }
        /// <summary>
        ///  定义实现类
        /// </summary>
        public class GameManager : BaseManager, ISingleton
        {
            public static GameManager Instance
            {
                get { return MonoSingletonProperty<GameManager>.Instance; }
            }
            public void OnSingletonInit()
            {
                Debug.Log("GameManager Init");
            }
        }

        /// <summary>
        /// 基类
        /// </summary>
        public class BaseService
        {
            
        }

        public class BluetoothService : BaseService, ISingleton
        {
            private BluetoothService()
            {
                
            }

            public static BluetoothService Instance
            {
                get { return SingletonProperty<BluetoothService>.Instance; }
            }
            public void OnSingletonInit()
            {
                Debug.Log("BluetoothService Init");
            }
        }

        private void Start()
        {
            var instance1 = GameManager.Instance;
            var instance2 = GameManager.Instance;

            Debug.Log(instance1.GetHashCode() == instance2.GetHashCode());

            var service1 = BluetoothService.Instance;
            var service2 = BluetoothService.Instance;

            Debug.Log(service1.GetHashCode() == service2.GetHashCode());
        }
    }
}