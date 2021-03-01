using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace WytFramework.ServiceLocator.Patern.Example
{
    /// <summary>
    ///自定义 InitialContext
    /// </summary>
    public class Example : MonoBehaviour
    {
        public class InitialContext : AbstractInitialContext
        {
            //获得Example 所在的 service
            public override IService LookUp(string name)
            {
                IService service = null;

                if (name == "bluetooth")
                {
                    service = new BluetoothService();
                }

                return service;
            }
        }
        /// <summary>
        /// 蓝牙服务
        /// </summary>
        public class BluetoothService : IService
        {
            /// <summary>
            /// 服务名
            /// </summary>
            public string Name
            {
                get { return "bluetooth"; }
            }

            public void Excute()
            {
                Debug.Log("蓝牙服务启动");
            }
        }

        private void Start()
        {
            var context = new InitialContext();

            var serviceLocator = new ServiceLocator(context);

            var bluetoothService = serviceLocator.GetService("bluetooth");

            bluetoothService.Excute();

        }
    }
}