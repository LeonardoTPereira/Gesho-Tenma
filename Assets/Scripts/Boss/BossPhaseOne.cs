using System.Collections;
using UnityEngine;
using Weapons;

namespace Boss
{
    public class BossPhaseOne : MonoBehaviour
    {
        [SerializeField] private WeaponEnumToPrefab shots;
        [SerializeField] private WeaponShooterToTransform weaponShooters;

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
            foreach (var weaponTransform in weaponShooters[WeaponShooter.Left].ShootersTransforms)
            {
                BossShoot(shots[Weapons.Weapons.Straight], weaponTransform);
            }
            foreach (var weaponTransform in weaponShooters[WeaponShooter.Right].ShootersTransforms)
            {
                BossShoot(shots[Weapons.Weapons.Straight], weaponTransform);
            }
            foreach (var weaponTransform in weaponShooters[WeaponShooter.Front].ShootersTransforms)
            {
                BossShoot(shots[Weapons.Weapons.Straight], weaponTransform);
            }
            StartCoroutine(CountCooldown(primaryBulletCooldown));
        }

        public void ShootFollowStraightShot()
        {
            if (!_canShootExtra) return;
            foreach (var weaponTransform in weaponShooters[WeaponShooter.Back].ShootersTransforms)
            {
                BossShoot(shots[Weapons.Weapons.FollowStraight], weaponTransform);
            }
            StartCoroutine(CountCooldownExtra(followStraitBulletCooldown));
        }

        public void ShootSecondaryShot()
        {
            if (!_canShoot) return;
            foreach (var weaponTransform in weaponShooters[WeaponShooter.Left].ShootersTransforms)
            {
                BossShoot(shots[Weapons.Weapons.Sine], weaponTransform);
            }
            foreach (var weaponTransform in weaponShooters[WeaponShooter.Right].ShootersTransforms)
            {
                BossShoot(shots[Weapons.Weapons.Sine], weaponTransform);
            }               
            StartCoroutine(CountCooldown(secondaryBulletCooldown));
        }

        public void ShootSpiralShot()
        {
            if (!_canShootExtra) return;
            foreach (var weaponTransform in weaponShooters[WeaponShooter.Left].ShootersTransforms)
            {
                BossShoot(shots[Weapons.Weapons.Spiral], weaponTransform);
            }
            foreach (var weaponTransform in weaponShooters[WeaponShooter.Right].ShootersTransforms)
            {
                BossShoot(shots[Weapons.Weapons.Spiral], weaponTransform);
            }
            StartCoroutine(CountCooldownExtra(followStraitBulletCooldown));
        }

        public void ShootSemiCircleShot()
        {
            if (!_canShoot) return;
            foreach (var weaponTransform in weaponShooters[WeaponShooter.Left].ShootersTransforms)
            {
                BossShoot(shots[Weapons.Weapons.SemiCircle], weaponTransform);
            }
            foreach (var weaponTransform in weaponShooters[WeaponShooter.Right].ShootersTransforms)
            {
                BossShoot(shots[Weapons.Weapons.SemiCircle], weaponTransform);
            }
            StartCoroutine(CountCooldown(semiCircleBulletCooldown));
        }

        public void DestroyBoss()
        {
            Destroy(this.gameObject);
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
    }
}
