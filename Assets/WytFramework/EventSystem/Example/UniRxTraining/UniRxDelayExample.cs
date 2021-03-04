using System;
using System.Timers;
using UniRx;
using UnityEngine;

namespace WytFramework.EventSystem.Example.UniRxTraining
{
    public class UniRxDelayExample : MonoBehaviour
    {
        private void Start()
        {
            //订阅可观察的计时器
            //Observable 可观察的  后边Timer是可观察的  Timer是发布者 事件的发送方
            Observable.Timer(TimeSpan.FromSeconds(2.0f))
                //订阅者， 订阅前面的Timer 事件的接收方
                .Subscribe(_ =>
                {
                    Debug.Log("Delay 2 Seconds");
                })
                //生命周期函数进行绑定
                .AddTo(this);

            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        //do something
                    }
                }).AddTo(this);
            
            //EveryUpdate 是事件的发布者。它会每帧发一个事件过来。
            //Subscribe 是事件的接收者，接收的是 EveryUpdate 发送的事件。
            //Where 则是在事件发布者和接收者之间的一个过滤操作。会过滤掉不满足条件的事件。
            Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonUp(0))
                .Subscribe(_ =>
                {
                    //do something
                }).AddTo(this);
            
            Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonUp(0))
                //获取第一个通过的事件。
                .First()
                .Subscribe(_ => { /* do something  */ })
                .AddTo(this);
            
            Observable.EveryUpdate()
                .First(_ => Input.GetMouseButtonUp(0))
                .Subscribe(_ => { /* do something */  })
                .AddTo(this);
        }
    }
}