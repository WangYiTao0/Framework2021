using UniRx;
using UnityEngine;

namespace Example.TimerApp
{
    public interface IStoraageService
    {
        ReactiveProperty<int> CreateIntReactiveProperty(string key, int defaultValue = 0);
    }
    
    public class CounterAppStorageService : IStoraageService
    {
        public ReactiveProperty<int> CreateIntReactiveProperty(string key, int defaultValue = 0)
        {
            var initValue = PlayerPrefs.GetInt(key,defaultValue);

            var property = new ReactiveProperty<int>(initValue);

            property.Subscribe(value =>
            {
                PlayerPrefs.SetInt(key, value);
            });

            return property;
        }
    }
}