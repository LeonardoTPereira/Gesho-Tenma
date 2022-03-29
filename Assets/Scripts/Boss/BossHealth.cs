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
        [SerializeField] private int health;
        public int MaxHealth { get; } = 300;
        private const float InvincibilityCooldown = 0.1f;
        private ParticleSystem _damageParticleSystem;
        [SerializeField] private GameObject damageParticle;

        public GameObject DamageParticle => damageParticle;

        private void Awake()
        {
            CanTakeDamage = true;
            Health = MaxHealth;
        }

        private void Start()
        {
            _damageParticleSystem = DamageParticle.GetComponent<ParticleSystem>();
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
            _damageParticleSystem.Play();
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