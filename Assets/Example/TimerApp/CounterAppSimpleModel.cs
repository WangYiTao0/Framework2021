using System;
using UniRx;

namespace Example.TimerApp
{
    public class CounterAppSimpleModel
    {
        public  IntReactiveProperty Count = new IntReactiveProperty();
    }
}