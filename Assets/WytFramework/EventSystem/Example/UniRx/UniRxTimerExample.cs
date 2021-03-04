using System;
using UniRx;
using UnityEngine;

namespace WytFramework.EventSystem.Example.UniRx
{
    public class UniRxTimerExample : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("Now : " + DateTime.Now);

            Observable.Timer(TimeSpan.FromSeconds(2.0f))
                .Subscribe(_ => Debug.Log("Now : " + DateTime.Now))
                .AddTo(this); // 绑定生命周期 防止销毁 空指针
            
            Observable.Timer(TimeSpan.FromSeconds(0.5f))
                .Subscribe(_=> Destroy(gameObject));
        }
    }
}