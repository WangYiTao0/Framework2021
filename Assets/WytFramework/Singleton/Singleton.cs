﻿namespace WytFramework.Singleton
{
    public abstract class Singleton<T> : ISingleton where T : Singleton<T>
    {
        protected static T _instance;

        private static object _lock = new object();

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = SingletonCreator.CreateSingleton<T>();
                    }
                }

                return _instance;
            }
        }

        public virtual void Dispose()
        {
            _instance = null;
        }

        public void OnSingletonInit()
        {
        }
    }
}