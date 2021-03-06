using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Example.TimerApp
{
    public class CounterAppSimpleController : MonoBehaviour
    {
        private CounterAppSimpleView _view;
        private CounterAppSimpleModel _model = new CounterAppSimpleModel();

        // Start is called before the first frame update
        void Start()
        {
            //绑定更新(表现逻辑)
            _model.Count.Select(count => count.ToString()).SubscribeToText(_view.NumberText).AddTo(this);

            _view = GetComponent<CounterAppSimpleView>();

            // 处理用户输入（交互逻辑）
            _view.BtnAdd.onClick.AddListener(() => { _model.Count.Value++; });

            _view.BtnSub.onClick.AddListener(() => { _model.Count.Value--; });
        }
    }
}
