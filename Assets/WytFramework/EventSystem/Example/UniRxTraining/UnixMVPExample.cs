using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace WytFramework.EventSystem.Example.UniRxTraining
{
    public class Enemy
    {
        public ReactiveProperty<long> CurrentHp { get; private set; }
        public IReadOnlyReactiveProperty<bool> IsDead { get; private set; }

        public Enemy(int initialHp)
        {
            CurrentHp = new ReactiveProperty<long>(initialHp);
            IsDead = CurrentHp.Select(x => x <= 0)
                .ToReactiveProperty();
        }
    }
    
    public class UnixMVPExample : MonoBehaviour
    {
        public Button _button;
        public Toggle _toggle;
        public InputField _InputField;
        public Text _text;
        public Slider _slider;

        private Enemy _enemy = new Enemy(200);
        private void Start()
        {
            // _toggle.OnValueChangedAsObservable().SubscribeToInteractable(_button);
            //
            // _InputField.OnValueChangedAsObservable()
            //     .Where(x => x != null)
            //     .SubscribeToText(_text);
            //
            // _slider.OnValueChangedAsObservable()
            //     .SubscribeToText(_text, x => Math.Round(x, 2).ToString());
            
            _button.OnClickAsObservable().Subscribe(_ => _enemy.CurrentHp.Value -= 99);
            _enemy.CurrentHp.SubscribeToText(_text);
            _enemy.IsDead.Where(isDead => isDead)
                .Subscribe(_=>
                {
                    _toggle.interactable = _button.interactable = false;
                });
        }
    }
}