using System;
using UniRx;
using UnityEngine;

namespace WytFramework.EventSystem.Example.UniRxTraining
{
    public class UniRxReactiveProperty : MonoBehaviour
    {
        // 每次值改变可以订阅事件
        public ReactiveProperty<int> Age = new ReactiveProperty<int>();

        private void Start()
        {
            Age.Subscribe(age =>
            {
                //do age
            });

            Age.Value = 1;
        }
    }
}