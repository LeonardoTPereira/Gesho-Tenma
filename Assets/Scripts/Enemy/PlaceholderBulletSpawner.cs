using System;
using System.Collections;
using UnityEngine;
using Weapons;

namespace Enemy
{
    public class PlaceholderBulletSpawner : MonoBehaviour
    {
        private struct BulletData
        {
            public GameObject BulletObject;
            public BulletSo BulletSo;
        }
        
        [SerializeField] private GameObject primaryBullet;
        private BulletData _primaryBulletData;
        private void Start()
        {
            _primaryBulletData.BulletObject = primaryBullet;
            _primaryBulletData.BulletSo = primaryBullet.GetComponent<BulletController>().Bullet;
            StartCoroutine(Shoot());
        }
        
        private IEnumerator Shoot()
        {
            while (gameObject.activeSelf)
            {
                Instantiate(_primaryBulletData.BulletObject, transform);
                yield return new WaitForSeconds(_primaryBulletData.BulletSo.Cooldown);
            }
        }
    }
}
