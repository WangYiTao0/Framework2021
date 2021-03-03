using System;
using UnityEngine;

namespace WytFramework.Singleton
{
    public class MonoSingleton<T> : MonoBehaviour,ISingleton where T: MonoSingleton<T>
    {
        protected static T _instance;

        protected static bool _onApplicationQuit = false;

        public static T Instance
        {
            get
            {
                if (_instance == null && !_onApplicationQuit)
                {
                    _instance = MonoSingletonCreator.CreateMonoSingleton<T>();
                }

                return _instance;
            }
        }

        public static bool IsApplicationQuit
        {
            get { return _onApplicationQuit; }
        }

        public virtual void OnSingletonInit()
        {
            
        }

        protected void OnApplicationQuit()
        {
            _onApplicationQuit = true;
            if (_instance == null) return;
            Destroy(_instance.gameObject);
            _instance = null;
        }

        public virtual void Dispose()
        {
            Destroy(gameObject);
        }

        protected void OnDestroy()
        {
            _instance = null;
        }
    }
}