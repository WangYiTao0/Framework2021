using System;

namespace Example.TimerApp
{
    public class CounterAppSimpleModel
    {
        private int _count;

        public int Count
        {
            get { return _count; }
            set
            {
                if (_count != null)
                {
                    _count = value;
                    OnCountChanged(_count);
                }
            }
        }

        public event Action<int> OnCountChanged = (_) => { };
}
}