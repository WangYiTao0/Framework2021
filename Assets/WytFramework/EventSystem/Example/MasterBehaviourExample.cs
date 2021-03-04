using System;
using UnityEngine;

namespace WytFramework.EventSystem.Example
{
    public class MasterBehaviourExample : MonoBehaviour
    {
        public class EventA {}
        public class EventB {}

        // 创建服务
        EventService mEventService = new EventService();
        
        // Use this for initialization
        void Start()
        {
            mEventService.Register<EventA>(OnEventAReceive);
            // 由于可以一次全部注销的原因
            // 注册支持用 lambda 表达式
            mEventService.Register<EventB>((EventB=>{
                Debug.Log("On Event B Receive");
            }));
        }

        void OnEventAReceive(EventA eventA)
        {
            Debug.Log("On Event A Receive");
        }
        
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mEventService.Send<EventA>(new EventA());
                mEventService.Send<EventB>(new EventB());
            }

            if (Input.GetMouseButtonDown(1))
            {
                mEventService.UnRegister<EventA>(OnEventAReceive); // 注销多次测试
                mEventService.UnRegisterAll();
              
            }
        }

        private void OnDestroy()
        {
            mEventService.UnRegisterAll();
            mEventService = null; 
        }
    }
}