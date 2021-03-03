using UnityEngine;

namespace WytFramework.ServiceLocator.LayerdArchitectureExample
{
    public interface ILoginController :ILogicController
    {
        void Login();
    }

    public class LoginController : ILoginController
    {
        public void Login()
        {
            Debug.Log("登录成功");
        }
    }
}