using System;
using UnityEngine;

namespace WytFramework.EventSystem.Example.UniRxTraining
{
    public class CommonDelayExample : MonoBehaviour
    {
        private float _startTime;

        private void Start()
        {
            _startTime = Time.time;
        }

        private void Update()
        {
            if (Time.time - _startTime > 5)
            {
                DoSomeThing();
                //避免再次执行
                _startTime = float.MaxValue;
            }
        }

        private void DoSomeThing()
        {
            Debug.Log("DoSomething");
        }
    }
}