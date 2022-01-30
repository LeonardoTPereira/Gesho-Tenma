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
            BattleScene.BattleStartEventHandler += ShowWarning;
        }    
    
        private void OnDisable()
        {
            BattleScene.BattleStartEventHandler -= ShowWarning;
        }

        private void ShowWarning(object sender, EventArgs eventArgs)
        {
            Warning.SetActive(true);
        }
    }
}