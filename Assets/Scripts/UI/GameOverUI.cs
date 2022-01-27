using System;
using Player;
using UnityEngine;

namespace UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverText;
        public GameObject GameOverText => gameOverText;

        private void OnEnable()
        {
            PlayerController.PlayerDiedEventHandler += ShowGameOver;
        }    
    
        private void OnDisable()
        {
            PlayerController.PlayerDiedEventHandler -= ShowGameOver;
        }

        private void ShowGameOver(object sender, EventArgs eventArgs)
        {
            GameOverText.SetActive(true);
        }
    }
}