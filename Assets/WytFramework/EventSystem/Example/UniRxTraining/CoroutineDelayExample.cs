using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;

namespace WytFramework.EventSystem.Example.UniRxTraining
{
    public class CoroutineDelayExample : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(DelayTimer(5, DoSomething));

            Observable.Timer(TimeSpan.FromSeconds(5))
                .Subscribe(_ =>
                {
                    /* do SomeThing*/
                })
                .AddTo(this);
        }

        private void DoSomething()
        {
            Debug.Log("DoSomething");
        }

        IEnumerator  DelayTimer(float seconds, Action callback)
        {
            yield return new WaitForSeconds(seconds);
            callback();
        }
        
    }
}