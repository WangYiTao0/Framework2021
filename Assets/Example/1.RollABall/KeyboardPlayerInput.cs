


using System;
using UnityEngine;

namespace WytFramework.FullStack.Example.RollABall
{
    public class KeyboardPlayerInput  :IPlayerInput
    {
        public event Action<PlayerInputData> OnInput = (data) => { };
        // Update is called once per frame
        public void  Update()
        {
            var axisX = Input.GetAxis("Horizontal");
            var axisY = Input.GetAxis("Vertical");

            if (axisX != 0 || axisY != 0)
            {
                OnInput(new PlayerInputData()
                {
                    AxisX = axisX,
                    AxisY = axisY
                });
            }
        }
    }

    public class PlayerInputData
    {
        public float AxisX { get; set; }
        public float AxisY { get; set; }

    }
}