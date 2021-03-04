using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WytFramework.EventSystem.Example.UniRxTraining
{
    public class UniRxUGUI : MonoBehaviour
    {
        private Button _button;
        private Toggle _toggle;
        private Image _image;
        private UnityEvent _event;
        private void Start()
        {
            _button.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    //do something
                });
            
            _toggle.OnValueChangedAsObservable()
                .Where(on=>on)
                .Subscribe(on =>
                {
                    // do some thing
                });
            
            _image.OnBeginDragAsObservable().Subscribe(_=>{});
            _image.OnDragAsObservable().Subscribe(eventArgs=>{});
            _image.OnEndDragAsObservable().Subscribe(_=>{});
            
            _event.AsObservable()
                .Subscribe(_ =>
                {
                    //process event;
                });
        }
    }
}