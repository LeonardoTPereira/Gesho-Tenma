using System.Collections;
using UnityEngine;

namespace Boss
{
    public class BossPhaseOne : MonoBehaviour
    {
        [SerializeField] private GameObject[] typeOfShoots;
        [SerializeField] private Transform[] spawnPoints;

        private bool _canShoot = true;
        private bool _canShootExtra = true;

        [SerializeField] private float primaryBulletCooldown = 0.45f;
        [SerializeField] private float followStraitBulletCooldown = 1f;
        [SerializeField] private float secondaryBulletCooldown = 0.01f;
        [SerializeField] private float semiCircleBulletCooldown = 0.02f;

        private static void BossShoot(GameObject bulletSo, Transform spawnPoint)
        {
            Instantiate(bulletSo, spawnPoint.position, spawnPoint.rotation);
        }

        public void ShootPrimaryShot()
        {
            if (!_canShoot) return;
            for (int i = 0; i < 4; i++)
            {
                BossShoot(typeOfShoots[0], spawnPoints[i]);
            }
            StartCoroutine(CountCooldown(primaryBulletCooldown));
        }

        public void ShootFollowStraightShot()
        {
            if (!_canShootExtra) return;
            BossShoot(typeOfShoots[3], spawnPoints[4]);
            BossShoot(typeOfShoots[3], spawnPoints[5]);
            StartCoroutine(CountCooldownExtra(followStraitBulletCooldown));
        }

        public void ShootSecondaryShot()
        {
            if (!_canShoot) return;
            BossShoot(typeOfShoots[1], spawnPoints[2]);                
            BossShoot(typeOfShoots[1], spawnPoints[3]);                
            StartCoroutine(CountCooldown(secondaryBulletCooldown));
        }

        public void ShootSemiCircleShot()
        {
            if (!_canShoot) return;
            BossShoot(typeOfShoots[2], spawnPoints[2]);
            BossShoot(typeOfShoots[2], spawnPoints[3]);
            StartCoroutine(CountCooldown(semiCircleBulletCooldown));
        }

        private IEnumerator CountCooldown(float bulletCooldown)
        {
            _canShoot = false;
            yield return new WaitForSeconds(bulletCooldown);
            _canShoot = true;
        }

        private IEnumerator CountCooldownExtra(float bulletCooldown)
        {
            _canShootExtra = false;
            yield return new WaitForSeconds(bulletCooldown);
            _canShootExtra = true;
        }

        /*
                 private void InicializeBulletSO(Transform[] typeOfShoots)
        {
            for (int i = 0; i < typeOfShoots.Length; i++)
            {
                spawnPointsSO[i] = typeOfShoots[i].GetComponent<BulletController>().Bullet;
            }
        }
        */
    }
}
