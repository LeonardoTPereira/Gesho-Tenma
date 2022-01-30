using System;
using Boss;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class BattleScene : MonoBehaviour
    {
        public static event EventHandler BattleStartEventHandler;
        public static event EventHandler BattleWonEventHandler;
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            BossAttackState.BossDeathEventHandler += CompleteStage;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            BossAttackState.BossDeathEventHandler -= CompleteStage;
        }
        
        private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            BattleStartEventHandler?.Invoke(null, EventArgs.Empty);
        }

        private static void CompleteStage(object sender, EventArgs eventArgs)
        {
            BattleWonEventHandler?.Invoke(null, EventArgs.Empty);
        }
    }
}