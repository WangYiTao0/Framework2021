using System;
using UnityEngine;

namespace WytFramework.ServiceLocator.LayerdArchitectureExample
{
    public interface IAccountSystem : ISystem
    { 
        bool IsLogin { get; }
        void Login(string username, string password, Action<bool> onLogin);
        void Logout(Action onLogOut);
    }

    public class AccountSystem : IAccountSystem
    {
        public bool IsLogin { get; private set; }
        public void Login(string username, string password, Action<bool> onLogin)
        {
            PlayerPrefs.SetString("username", username);
            PlayerPrefs.SetString("password", password);
            IsLogin = true;
            onLogin?.Invoke(true);
        }

        public void Logout(Action onLogOut)
        {
            PlayerPrefs.SetString("username", String.Empty);
            PlayerPrefs.SetString("password", string.Empty);
            IsLogin = false;
        }
    }
}