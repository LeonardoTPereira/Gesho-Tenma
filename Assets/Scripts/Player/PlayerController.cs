using System;
using System.Collections;
using Events;
using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public static event InitializeHealthEventHandler InitializePlayerHealthEventHandler;
        public static event TakeDamageEventHandler PlayerTakeDamageEventHandler;
        [SerializeField] private bool canTakeDamage;
        [SerializeField] private int health = 5;
        [SerializeField] private int maxHealth = 5;
        private readonly float invincibilityCooldown = 0.5f;

        private void Awake()
        {
            CanTakeDamage = true;
        }

        private void Start()
        {
            InitializePlayerHealthEventHandler?.Invoke(this, new InitializeHealthEventArgs(maxHealth));
        }

        private void OnEnable()
        {
            BulletController.PlayerHitEventHandler += TakeDamage;
        }

        private void OnDisable()
        {
            BulletController.PlayerHitEventHandler -= TakeDamage;
        }

        private void TakeDamage(object sender, BulletHitEventArgs eventArgs)
        {
            if (!CanTakeDamage) return;
            Health -= eventArgs.Bullet.Damage;
            PlayerTakeDamageEventHandler?.Invoke(this, new TakeDamageEventArgs(eventArgs.Bullet.Damage));
            StartCoroutine(CountInvincibilityCooldown());
            Debug.Log($"$Player now has {Health} health points.");
        }
        
        private IEnumerator CountInvincibilityCooldown()
        {
            CanTakeDamage = false;
            yield return new WaitForSeconds(invincibilityCooldown);
            CanTakeDamage = true;
        }
        
        public bool CanTakeDamage
        {
            get => canTakeDamage;
            set => canTakeDamage = value;
        }
        
        public int Health
        {
            get => health;
            set => health = value;
        }
    }
}
