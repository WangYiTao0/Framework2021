using UniRx;
using UnityEngine;

namespace WytFramework.EventSystem.Example.UniRx
{
    public class UniRxBasicUsage : MonoBehaviour
    {
        private void Start()
        {
            //每 5 帧 输出一次
            Observable.EveryUpdate()
                .Where(_ => Time.frameCount % 5 == 0)
                .Subscribe(_ => Debug.Log("hello"));
        }
    }
}
