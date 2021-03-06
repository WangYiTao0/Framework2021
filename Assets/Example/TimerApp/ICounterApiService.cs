using System;
using UniRx;

namespace Example.TimerApp
{
    public interface ICounterApiService
    {
        void RequestSomeData(Action<string> onResponse);
    }
    
    public class CounterApiService : ICounterApiService
    {
        public void RequestSomeData(Action<string> onResponse)
        {
            Observable.Timer(TimeSpan.FromSeconds(1.0f)).Subscribe(_ =>
            {
                onResponse("数据请求成功");
            });
        }
    }
}