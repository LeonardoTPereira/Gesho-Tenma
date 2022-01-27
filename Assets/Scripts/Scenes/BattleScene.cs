using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class BattleScene : MonoBehaviour
    {
        public static event EventHandler BattleStartEventHandler;
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        
        private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            BattleStartEventHandler?.Invoke(null, EventArgs.Empty);
        }
    }
}