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
                var assembly = typeof(Example).Assembly;

                var serviceType = typeof(IService);

                //获取所有实现IService接口的类型
                var service = assembly.GetTypes()
                    // 获取所有实现 IService 接口的类型
                    .Where(t=>serviceType.IsAssignableFrom(t)&&!t.IsAbstract)
                    // 创建实例
                    .Select(t => t.GetConstructors().First<ConstructorInfo>().Invoke(null))
                    // 转型为 IService
                    .Cast<IService>()
                    // 获取符合条件的 Service 对象
                    .SingleOrDefault(s => s.Name == name);

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