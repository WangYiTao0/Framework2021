using System;
using TMPro.EditorUtilities;
using UnityEngine;

namespace WytFramework.ServiceLocator.LayerdArchitectureExample
{
    public class LayerdArchitectureExample : MonoBehaviour
    {
        private ILoginController _loginController;
        private IUserInputManager _userInputManager;

        private void Start()
        {
            _loginController = ArchitectureConfig.Architecture.LogicLayer.GetModule<ILoginController>();
            _userInputManager = ArchitectureConfig.Architecture.LogicLayer.GetModule<IUserInputManager>();

            _loginController.Login();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _userInputManager.OnInput(KeyCode.Space);
            }
            
        }
    }
}