using System;
using System.Collections;
using Animation;
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
        private bool _isHoldingShoot;
        private BulletData _primaryBulletData;
        private BulletData _secondaryBulletData;
        [SerializeField] private float cooldownBonus = 1;


        private void Awake()
        {
            _canShoot = false;
		    _isHoldingShoot = true;
        }
        
        private void OnEnable()
        {
            WarningEnd.IntroEndedEventHandler += EnableInput;
        }
        private void OnDisable()
        {
            WarningEnd.IntroEndedEventHandler -= EnableInput;
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
            if (context.performed)
            {
                _isHoldingShoot = true;
            }
            else if (context.canceled)
            {
                _isHoldingShoot = false;
            }
            StartCoroutine(Shoot(_primaryBulletData, PrimaryWeapon));
        }
    
        public void ShootSecondaryWeapon(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _isHoldingShoot = true;
            }
            else if (context.canceled)
            {
                _isHoldingShoot = false;
            }
            StartCoroutine(Shoot(_secondaryBulletData, SecondaryWeapon));
        }

        private IEnumerator Shoot(BulletData bullet, Transform[] spawnPoints)
        {
            while (_isHoldingShoot)
            {
                yield return null;
                if (!_canShoot) continue;
                foreach (var spawnPoint in spawnPoints)
                {
                    Instantiate(bullet.BulletObject, spawnPoint.position, spawnPoint.rotation);
                }
                StartCoroutine(CountCooldown(bullet.BulletSo.Cooldown));
            }
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
        
        private void EnableInput(object sender, EventArgs eventArgs)
        {
            _canShoot = true;
        }
    }
}
