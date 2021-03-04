using System;
using System.Timers;
using UniRx;
using UnityEngine;

namespace WytFramework.EventSystem.Example.UniRx
{
    public class UniRxOnCompletedExample : MonoBehaviour
    {
        private void Start()
        {
            Observable.Timer(TimeSpan.FromSeconds(3.0f))
                .Subscribe(_ => Debug.Log("Delayed 3 seconds"), 
                    () => Debug.Log(("Completed")));
        }
    }
}