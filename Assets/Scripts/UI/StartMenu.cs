using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine;

namespace StartMenu { 
    public class StartMenu : MonoBehaviour
    {
        public void ExitGame(InputAction.CallbackContext context)
        {
            Debug.Log("Exit button pressed");
            Application.Quit();
        }
    }
}

