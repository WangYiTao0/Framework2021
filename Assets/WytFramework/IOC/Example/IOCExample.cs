// using System;
// using UnityEngine;
//
// namespace WytFramework.IOC.Example
// {   
//     public class ServiceA
//     {
//         public void Say()
//         {
//             Debug.Log("I am ServiceA:" + this.GetHashCode());
//         }
//     }
//     public class IOCExample : MonoBehaviour
//     {
//         [Inject] public ServiceA A { get; set; }
//
//         private void Start()
//         {
//             //创建实例容器
//             var contrainer = new QFrameworkContainer();
//             
//             //注册类型
//             contrainer.Register<ServiceA>();
//             //注入对象(会自动查找 Inject Atrribute 的对象)
//             contrainer.Inject(this);
//             //注入对象后，就可以直接使用A对象了
//             A.Say();
//         }
//     }
// }
