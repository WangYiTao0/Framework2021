using UnityEngine;

namespace WytFramework.ServiceLocator.LayerdArchitectureExample
{
    public interface IMissionSystem : ISystem
    {
        void OnEvent(string eventName);
    }

    public class MissionSystem : IMissionSystem
    {
        private int jumpCount
        {
            get { return PlayerPrefs.GetInt("JUMP_COUNT"); }
            set { PlayerPrefs.SetInt("JUMP_COUNT", value); }
        }
        
        
        public void OnEvent(string eventName)
        {
            if (eventName == "JUMP")
            {
                jumpCount++;
                if (jumpCount == 1)
                {
                    Debug.Log("第一次跳躍任務完成");
                }
                if (jumpCount == 5)
                {
                    Debug.Log("第5次跳躍任務完成");
                }
                if (jumpCount == 10)
                {
                    Debug.Log("第10次跳躍任務完成");
                }
            }
        }
    }
}