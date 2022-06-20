using System;
using System.Collections.Generic;
using System.Linq;
using MyBox;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Game.LevelSelection
{
    public class LevelSelectManager : MonoBehaviour
    {
        [field: SerializeField] public SelectedLevels Selected { get; set; }
        [field: SerializeField] public List<LevelSelectItem> LevelItems { get; set; }

        [field: SerializeField] public SceneReference BattleScene { get; private set; }
        [field: SerializeField] public SceneReference BossSelection { get; private set; }
        [field: SerializeField] public SceneReference EndGame { get; private set; }
        public static event EventHandler CompletedAllLevelsEventHandler;
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }

        private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != BossSelection.SceneName) return;
            if (AllLevelsCompleted())
            {
                CompletedAllLevelsEventHandler?.Invoke(null, EventArgs.Empty);
                SceneManager.LoadScene(EndGame.SceneName);
            }
            //((ISoundEmitter)this).OnSoundEmitted(this, new PlayBgmEventArgs(AudioManager.BgmTracks.LevelSelectTheme));
        }

        private bool AllLevelsCompleted()
        {
            return LevelItems.All(level => level.Level.HasCompleted());
        }

        public void ConfirmStageSelection(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            Debug.Log("Selected Level");
            for (var i = 0; i < LevelItems.Count; ++i)
            {
                if (!LevelItems[i].IsSelected) continue;
                Selected.SelectLevel(i);
                SceneManager.LoadScene(BattleScene.SceneName);
                return;
            }
        }
    }
}