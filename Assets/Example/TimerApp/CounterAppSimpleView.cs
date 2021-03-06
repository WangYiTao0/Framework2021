using UnityEngine;
using UnityEngine.UI;

namespace Example.TimerApp
{
    public class CounterAppSimpleView : MonoBehaviour
    {
        [HideInInspector] public  Text NumberText;

        [HideInInspector] public  Button BtnAdd;
        [HideInInspector] public  Button BtnSub;

        void Start()
        {
            NumberText = transform.Find("Number").GetComponent<Text>();
            BtnAdd = transform.Find("BtnAdd").GetComponent<Button>();
            BtnSub = transform.Find("BtnSub").GetComponent<Button>();
        }

    }
}