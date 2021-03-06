using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace WytFramework.EventSystem.Example.UniRxTraining
{
    public class UniRx02 : MonoBehaviour
    {
        [SerializeField] private Button _buttonA;
        [SerializeField] private Button _buttonB;
        [SerializeField] private Button _buttonC;

        private void Start()
        {
            var buttonAStream = _buttonA.OnClickAsObservable().Select(_ =>"A");
            var buttonBStream = _buttonB.OnClickAsObservable().Select(_ =>"B");
            var buttonCStream = _buttonC.OnClickAsObservable().Select(_ =>"C");

            Observable.Merge(buttonAStream, buttonBStream, buttonCStream)
                .First()
                .Subscribe(buttonId =>
                {
                    if (buttonId == "A")
                    {
                        // Button A Clicked
                    }
                    else if (buttonId == "B")
                    {
                        // Button B Clicked
                    }
                    else if (buttonId == "C")
                    {
                        // Button C Clicked
                    }
                });
        }
    }
}
