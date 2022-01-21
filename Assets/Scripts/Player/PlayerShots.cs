using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Player
{
    public class PlayerShots : MonoBehaviour
    {
        [SerializeField] private GameObject primaryBullet;
        [SerializeField] private GameObject secondaryBullet;
        [SerializeField] private Transform[] primaryWeapon;
        [SerializeField] private Transform[] secondaryWeapon;

        public void ShootPrimaryWeapon(InputAction.CallbackContext context)
        {
            Shoot(PrimaryBullet, PrimaryWeapon);
        }
    
        public void ShootSecondaryWeapon(InputAction.CallbackContext context)
        {
            Shoot(SecondaryBullet, SecondaryWeapon);
        }

        private static void Shoot(GameObject bulletSo, Transform[] spawnPoints)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                Instantiate(bulletSo, spawnPoint);
            }
        }
        
        public GameObject PrimaryBullet => primaryBullet;
        public GameObject SecondaryBullet => secondaryBullet;
        public Transform[] PrimaryWeapon => primaryWeapon;
        public Transform[] SecondaryWeapon => secondaryWeapon;
    }
}
