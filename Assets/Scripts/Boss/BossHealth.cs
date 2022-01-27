using System.Collections;
using Events;
using UnityEngine;
using Weapons;

namespace Boss
{
    public class BossHealth : MonoBehaviour
    {
        public static event InitializeHealthEventHandler InitializeBossHealthEventHandler;
        public static event TakeDamageEventHandler BossTakeDamageEventHandler;
        [SerializeField] private bool canTakeDamage;
        [SerializeField] private int health = 5;
        public int MaxHealth { get; } = 300;
        private const float InvincibilityCooldown = 0.1f;

        private void Awake()
        {
            CanTakeDamage = true;
            Health = MaxHealth;
        }

        private void Start()
        {
            InitializeBossHealthEventHandler?.Invoke(this, new InitializeHealthEventArgs(MaxHealth));
        }
        
        private void OnEnable()
        {
            BulletController.EnemyHitEventHandler += TakeDamage;
        }

        private void OnDisable()
        {
            BulletController.EnemyHitEventHandler -= TakeDamage;
        }

        private void TakeDamage(object sender, BulletHitEventArgs eventArgs)
        {
            if (!CanTakeDamage) return;
            Health -= eventArgs.Bullet.Damage;
            BossTakeDamageEventHandler?.Invoke(this, new TakeDamageEventArgs(eventArgs.Bullet.Damage));
            StartCoroutine(CountInvincibilityCooldown());
        }
        
        private IEnumerator CountInvincibilityCooldown()
        {
            CanTakeDamage = false;
            yield return new WaitForSeconds(InvincibilityCooldown);
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