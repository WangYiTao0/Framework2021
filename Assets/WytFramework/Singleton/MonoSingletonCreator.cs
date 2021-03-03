using UnityEngine;

namespace WytFramework.Singleton
{
    public  abstract class MonoSingletonCreator
    {
        public static T CreateMonoSingleton<T>() where T : MonoBehaviour, ISingleton
        {
            //尝试获取场景内的T脚本
            var instance = Object.FindObjectOfType<T>();
            // 如果存在则直接返回
            if (instance)
            {
                instance.OnSingletonInit();
                return instance;
            }
            // 创建实例
            if (!instance)
            {
                var gameObj = new GameObject(typeof(T).Name);
                Object.DontDestroyOnLoad(gameObj);
                instance = gameObj.AddComponent<T>();
            }
            instance.OnSingletonInit();
            return instance;
        }
    }
}