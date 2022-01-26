using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossPhaseOne : MonoBehaviour
    {

        [SerializeField] private GameObject[] typeOfShoots;
        [SerializeField] private Transform[] spawnPoints;

        private bool _canShoot = true;

        public float primaryBulletCooldown = 0.45f;
        public float secondaryBulletCooldown = 0.01f;
        public int health;

        void Start()
        {
            health = 100;
        }

        private static void BossShoot(GameObject bulletSo, Transform spawnPoint)
        {
            Instantiate(bulletSo, spawnPoint.position, spawnPoint.rotation);
        }

        public void ShootPrimaryShot()
        {
            if (_canShoot)
            {
                foreach (Transform spawnPoint in spawnPoints)
                {
                    BossShoot(typeOfShoots[0], spawnPoint);
                }
                StartCoroutine(CountCooldown(primaryBulletCooldown));
            }
        }

        public void ShootSecondaryShot()
        {
            if (_canShoot)
            {
                BossShoot(typeOfShoots[2], spawnPoints[2]);                
                StartCoroutine(CountCooldown(secondaryBulletCooldown));
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
