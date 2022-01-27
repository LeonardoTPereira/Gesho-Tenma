using System;
using Scenes;
using UnityEngine;

namespace UI
{
    public class WarningAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject warning;
        public GameObject Warning => warning;

        private void OnEnable()
        {
            BattleScene.BattleStartEventHandler += ShowGameOver;
        }    
    
        private void OnDisable()
        {
            BattleScene.BattleStartEventHandler -= ShowGameOver;
        }

        private void ShowGameOver(object sender, EventArgs eventArgs)
        {
            Warning.SetActive(true);
        }
    }
}