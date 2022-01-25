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

        public float bulletCooldown = 0.5f;
        public int health;

        void Start()
        {
            health = 200;
        }

        private static void BossShoot(GameObject bulletSo, Transform spawnPoint)
        {
            Instantiate(bulletSo, spawnPoint);
        }

        public void ShootPrimaryShot()
        {
            if (_canShoot)
            {
                foreach (Transform spawnPoint in spawnPoints)
                {
                    BossShoot(typeOfShoots[0], spawnPoint);
                }
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
