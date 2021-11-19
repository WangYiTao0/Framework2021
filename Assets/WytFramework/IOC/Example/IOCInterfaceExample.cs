// using QFramework;
// using UnityEngine;
//
// namespace WytFramework.IOC.Example
// {
//     
//     public interface ILoginService
//     {
//         void Login();
//     }
//
//     public class LoginService : ILoginService
//     {
//         public void Login()
//         {
//             Debug.Log("登录成功");
//         }
//     }
//     public class IOCInterfaceExample : MonoBehaviour
//     {
//         [Inject]
//         public ILoginService LoginService {get;set;}
//
//         void Start () 
//         {
//             var container = new QFrameworkContainer();
//
//             container.RegisterInstance<ILoginService>(new LoginService());
//
//             // Register 也支持注册接口依赖
//             //container.Register<ILoginService,LoginService>();
//
//             container.Inject(this);
//
//             LoginService.Login();
//         }
//     }
// }