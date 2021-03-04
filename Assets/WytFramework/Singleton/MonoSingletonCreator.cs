using System.Linq;
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
            // 尝试根据 MonoSingletonPath 去创建单例
            var info = typeof(T);
            instance = info.GetCustomAttributes(false)
                .Cast<MonoSingletonPath>()
                .Select(monoSingletonPath => CreateSingletonWithPath<T>(monoSingletonPath.PathInHierarchy, true))
                .FirstOrDefault();
            
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

        /// <summary>
        /// 根据 Path 去创建 Singleton
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dontDestroy"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T CreateSingletonWithPath<T>(string path, bool dontDestroy) where T : MonoBehaviour
        {
            var gameObj = GetOrCreateGameObjectWithPath(path, true, dontDestroy);
            if (!gameObj)
            {
                gameObj = new GameObject("Singleton of " + typeof(T).Name);

                if (dontDestroy)
                {
                    Object.DontDestroyOnLoad(gameObj);
                }
            }

            return gameObj.AddComponent<T>();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="build"></param>
        /// <param name="dontDestroy"></param>
        /// <returns></returns>
        private static GameObject GetOrCreateGameObjectWithPath(string path, bool build, bool dontDestroy)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            var subPath = path.Split('/');
            if (subPath.Length == 0)
            {
                return null;
            }

            return GetOrCreateObjectWithPathArray(null, subPath, 0, build, dontDestroy);
        }
        /// <summary>
        /// 递归找到叶子 GameObject节点
        /// </summary>
        /// <param name="parentGameObj"></param>
        /// <param name="subPath"></param>
        /// <param name="index"></param>
        /// <param name="build"></param>
        /// <param name="dontDestroy"></param>
        /// <returns></returns>
        private static GameObject GetOrCreateObjectWithPathArray(GameObject parentGameObj, string[] subPath,
            int index, bool build, bool dontDestroy)
        {
            while (true)
            {
                GameObject currentGameObj = null;

                if (!parentGameObj)
                {
                    currentGameObj = GameObject.Find(subPath[index]);
                }
                else
                {
                    var child = parentGameObj.transform.Find(subPath[index]);
                    if (child != null)
                    {
                        currentGameObj = child.gameObject;
                    }
                }

                if (!currentGameObj)
                {
                    if (build)
                    {
                        currentGameObj = new GameObject(subPath[index]);
                        if (parentGameObj != null)
                        {
                            currentGameObj.transform.SetParent(parentGameObj.transform);
                        }

                        if (dontDestroy && index == 0)
                        {
                            Object.DontDestroyOnLoad(currentGameObj);
                        }
                    }
                }

                if (!currentGameObj)
                {
                    return null;
                }

                // 如果是叶子节点这直接返回
                if (++index == subPath.Length) return currentGameObj;
                parentGameObj = currentGameObj;
            }
        }
    }
}