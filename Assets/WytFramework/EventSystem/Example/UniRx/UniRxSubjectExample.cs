using System;
using UniRx;
using UnityEngine;

namespace WytFramework.EventSystem.Example.UniRx
{
    public class UniRxSubjectExample : MonoBehaviour
    {
        private void Start()
        {
            var subject = new Subject<int>();
            subject.Subscribe(number =>
            {
                Debug.Log(number);
            });
            
            subject.OnNext(1);
            subject.OnNext(2);
            subject.OnNext(3);

        }
    }
}