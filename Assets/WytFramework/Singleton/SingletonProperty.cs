﻿namespace WytFramework.Singleton
{
    public class SingletonProperty <T> where T : class, ISingleton
    {
        private static T _instance;
        private static readonly object _lock = new object();

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

        public static void Dispose()
        {
            _instance = null;
        }
    }
}