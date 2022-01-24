using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossPhaseOne : MonoBehaviour
    {

        [SerializeField] private GameObject primaryBullet;
        [SerializeField] private Transform spawnPoint;
        private bool _canShoot = true;

        public float bulletCooldown = 1f;
        public int health;

        void Start()
        {
            health = 200;
        }

        void Update()
        {

        }

        private static void BossShoot(GameObject bulletSo, Transform spawnPoint)
        {
            Instantiate(bulletSo, spawnPoint);

        }

        public void ShootPrimaryShot()
        {
            if (_canShoot)
            {
                BossShoot(primaryBullet, spawnPoint);
                StartCoroutine(CountCooldown(bulletCooldown));
            }
        }

        private IEnumerator CountCooldown(float bulletCooldown)
        {
            _canShoot = false;
            yield return new WaitForSeconds(bulletCooldown);
            _canShoot = true;
        }
    }
}
