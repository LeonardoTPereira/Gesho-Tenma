using System.Collections;
using Events;
using UnityEngine;

namespace Weapons
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private BulletSo bullet;
        [SerializeField] private float timeToDieOutScreen = 0.5f;
        public static event BulletHitEventHandler EnemyHitEventHandler;
        public static event BulletHitEventHandler PlayerHitEventHandler;

        public Rigidbody2D RigidBody { get; set; }
        
        private void Start()
        {
            RigidBody = GetComponent<Rigidbody2D>();
            StartCoroutine(Bullet.BulletMovement.Move(new Vector2(Bullet.XSpeed, Bullet.YSpeed), this));
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (CompareTag("PlayerBullet"))
            {
                if (!col.gameObject.CompareTag("Enemy")) return;
                EnemyHitEventHandler?.Invoke(null, new BulletHitEventArgs(Bullet));
                DestroyBullet();
            }
            else if (CompareTag("EnemyBullet"))
            {
                if (!col.gameObject.CompareTag("Player")) return;
                Debug.Log("EnemyShot Collided with Player");
                PlayerHitEventHandler?.Invoke(null, new BulletHitEventArgs(Bullet));
                DestroyBullet();
            }
        }

        private void DestroyBullet()
        {
            //TODO play sfx with a Coroutine and kill after it finishes
            Destroy(gameObject);
        }
        
        public BulletSo Bullet
        {
            get => bullet;
            set => bullet = value;
        }

        private void OnBecameInvisible()
        {
            StartCoroutine(CountCooldown());
            DestroyBullet();
        }
        
        private IEnumerator CountCooldown()
        {
            yield return new WaitForSeconds(TimeToDieOutScreen);
        }
        
        public float TimeToDieOutScreen => timeToDieOutScreen;

    }
}
