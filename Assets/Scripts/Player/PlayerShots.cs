using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Player
{
    public class PlayerShots : MonoBehaviour
    {
        private struct BulletData
        {
            public GameObject BulletObject;
            public BulletSo BulletSo;
        }
        
        [SerializeField] private GameObject primaryBullet;
        [SerializeField] private GameObject secondaryBullet;
        [SerializeField] private Transform[] primaryWeapon;
        [SerializeField] private Transform[] secondaryWeapon;

        private bool _canShoot;
        private BulletData _primaryBulletData;
        private BulletData _secondaryBulletData;
        [SerializeField] private float cooldownBonus = 1;


        private void Awake()
        {
            _canShoot = true;
        }

        private void Start()
        {
            _primaryBulletData.BulletObject = primaryBullet;
            _primaryBulletData.BulletSo = primaryBullet.GetComponent<BulletController>().Bullet;
            _secondaryBulletData.BulletObject = secondaryBullet;
            _secondaryBulletData.BulletSo = secondaryBullet.GetComponent<BulletController>().Bullet;
        }

        public void ShootPrimaryWeapon(InputAction.CallbackContext context)
        {
            Shoot(_primaryBulletData, PrimaryWeapon);
        }
    
        public void ShootSecondaryWeapon(InputAction.CallbackContext context)
        {
            Shoot(_secondaryBulletData, SecondaryWeapon);
        }

        private void Shoot(BulletData bullet, Transform[] spawnPoints)
        {
            if (!_canShoot) return;
            foreach (var spawnPoint in spawnPoints)
            {
                Instantiate(bullet.BulletObject, spawnPoint);
            }
            StartCoroutine(CountCooldown(bullet.BulletSo.Cooldown));
        }

        private IEnumerator CountCooldown(float bulletCooldown)
        {
            _canShoot = false;
            yield return new WaitForSeconds(bulletCooldown / CooldownBonus);
            _canShoot = true;
        }
        
        public GameObject PrimaryBullet => primaryBullet;
        public GameObject SecondaryBullet => secondaryBullet;
        public Transform[] PrimaryWeapon => primaryWeapon;
        public Transform[] SecondaryWeapon => secondaryWeapon;
        
        public float CooldownBonus
        {
            get => cooldownBonus;
            set => cooldownBonus = value;
        }
    }
}
