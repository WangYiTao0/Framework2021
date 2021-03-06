using QFramework;
using UnityEngine;

namespace Example.TimerApp
{
    public class CounterApp : MonoBehaviour,ISingleton
    {
        public static QFrameworkContainer Container
        {
            get
            {
                return _app._container;
            }
        }

        private QFrameworkContainer _container;

        private static CounterApp _app
        {
            get
            {
                return MonoSingletonProperty<CounterApp>.Instance;
            }
        }
        
        public void OnSingletonInit()
        {
            _container = new QFrameworkContainer();
            
            _container.RegisterInstance(new CounterAppWithQFModel());
            _container.Register<ICounterApiService, CounterApiService>();
        }
    }
}