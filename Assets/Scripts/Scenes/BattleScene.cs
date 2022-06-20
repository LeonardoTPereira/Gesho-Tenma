using System;
using Boss;
using Game.LevelSelection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class BattleScene : MonoBehaviour
    {
        public static event EventHandler BattleStartEventHandler;
        public static event EventHandler BattleWonEventHandler;
        [field: SerializeField] public SelectedLevels Levels { get; set; }
        [field: SerializeField] public GameObject Scenario { get; set; }

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

        private void Start()
        {
            Scenario.GetComponent<SpriteRenderer>().sprite = Levels.GetCurrentLevel().Scenario.Scenario;
            var boss = Instantiate(Levels.GetCurrentLevel().Boss.BossPrefab);
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