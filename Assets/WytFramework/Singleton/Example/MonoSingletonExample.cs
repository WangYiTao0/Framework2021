using System;
using UnityEngine;

namespace WytFramework.Singleton.Example
{
    public class MonoSingletonExample : MonoBehaviour
    {
        public class GameManager : MonoSingleton<GameManager>
        {
            public override void OnSingletonInit()
            {
                Debug.Log("GameManager Init");
            }
        }
        private void Start()
        {
            var instance = GameManager.Instance;
            var instance1 = GameManager.Instance;

            Debug.Log(instance.GetHashCode() == instance1.GetHashCode());
        }
    }
}