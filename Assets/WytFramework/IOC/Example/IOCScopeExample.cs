using QFramework;
using UnityEngine;

namespace WytFramework.IOC.Example
{       
    public class SomeService 
    {
        public void Description()
        {
            Debug.Log("SomeService:" + this.GetHashCode());
        }
    }

    public class SomeObject
    {
        public void Description()
        {
            Debug.Log("SomeObject:" + this.GetHashCode());
        }
    }
    public class IOCScopeExample : MonoBehaviour
    {
        [Inject]
        public SomeObject ObjA {get;set;}

        [Inject]
        public SomeObject ObjB {get;set;}

        [Inject]
        public SomeObject ObjC {get;set;}


        [Inject]
        public SomeService ServiceA {get;set;}

        [Inject]
        public SomeService ServiceB {get;set;}

        void Start()
        {
            var container = new QFrameworkContainer();

            // 每次注入都创建新的实例
            container.Register<SomeObject>();

            // 每次注入都使用同一个实例
            container.RegisterInstance(new SomeService());

            // 注入
            container.Inject(this);
            
            ObjA.Description();
            ObjB.Description();
            ObjC.Description();
            ServiceA.Description();
            ServiceB.Description();
        }
    }
}