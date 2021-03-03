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
            var accountSystem = ArchitectureConfig.Architecture.BusinessModuleLayer.GetModule<IAccountSystem>();
            
            accountSystem.Login("hello","abc",(succeed)=>
            {
                if (succeed)
                {
                    Debug.Log("登录成功");
                }
            });
        }
    }
}