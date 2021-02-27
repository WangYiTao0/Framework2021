using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WytFramework.FullStack.Example.RollABall
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        IPlayerInput m_Input = new KeyboardPlayerInput();

        private void Awake()
        {
            GameConfig.Config();
            m_Input = GameConfig.PlayerInput;
            m_Input.OnInput += OnInput;
        }

        // Update is called once per frame
        void Update()
        {
            m_Input.Update();
        }

        private void OnInput(PlayerInputData data)
        {
            transform.localPosition = transform.localPosition + Vector3.right * data.AxisX * speed * Time.deltaTime;
            transform.localPosition = transform.localPosition + Vector3.forward * data.AxisY * speed * Time.deltaTime;
        }
    }
}
