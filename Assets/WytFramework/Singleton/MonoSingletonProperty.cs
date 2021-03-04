using UnityEngine;

namespace WytFramework.Singleton
{
    public class MonoSingletonProperty<T> where T : MonoBehaviour, ISingleton
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = MonoSingletonCreator.CreateMonoSingleton<T>();
                }

                return _instance;
            }
        }
        
        public static void Dispose()
        {
            Object.Destroy(_instance.gameObject);

            _instance = null;
        }
    }
}