using UnityEngine;
using WytFramework.Singleton.Example;

namespace WytFramework.Singleton.BestSingleton
{
    /// <summary>
    /// 严格控制对外暴露的API 与外界交互只通过静态方法
    /// 严格控制单例的使用范围 不要让单例类的职责太多
    /// 严格控制单例对象的生命周期
    /// </summary>
    public class GameManager : MonoBehaviour, ISingleton
    {
        private static GameManager _instance
        {
            get { return MonoSingletonProperty<GameManager>.Instance; }
        }

        void ISingleton.OnSingletonInit() { }

        private int _Score = 0;
        private int _Health = 0;

        public static void Init()
        {
            _instance._Score = 0;
            _instance._Health = 0;
            //do something
        }
        
        public static void Play(int addScore, int addHealth)
        {
            _instance._Score += addScore;
            _instance._Health += addHealth;
            
            //do something
        }

        public static void Pause() { }

        public static void Resume() { }

        public static void GameOver() { }
    }
}