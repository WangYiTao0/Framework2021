using UniRx;
using UnityEngine;

namespace Example.TimerApp
{
    public class CounterAppWithQFModel
    {
        public ReactiveProperty<int> Count = new ReactiveProperty<int>();
        public ReactiveProperty<string> SomeData = new ReactiveProperty<string>("");

        public CounterAppWithQFModel()
        {
            // 加载初始逻辑
            int initCount = PlayerPrefs.GetInt("count", 0);
            Count = new ReactiveProperty<int>(initCount);
            
            //订阅储存逻辑
            Count.Subscribe((count =>
            {
                PlayerPrefs.SetInt("count", count);
            }));
        }

    }
}