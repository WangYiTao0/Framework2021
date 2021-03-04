using System;
using UniRx;
using UnityEngine;

namespace WytFramework.EventSystem.Example.UniRx
{
    public class UniRxReactiveProperty : MonoBehaviour
    {
        private ReactiveProperty<int> _age = new ReactiveProperty<int>();

        private void Start()
        {
            _age.Skip(1)
                .Subscribe(age => Debug.Log(age));

            _age.Value = 10;
            _age.Value = 10;
            _age.Value = 10;
            _age.Value = 11;

        }
    }
}