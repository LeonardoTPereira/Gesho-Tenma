using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Weapons
{
    [CreateAssetMenu(fileName = "Bullets", menuName = "Scriptable Objects/Bullet", order = 0)]
    public class BulletSo : ScriptableObject
    {
        [SerializeField] private string bulletName;
        [SerializeField] private float xSpeed;
        [SerializeField] private float ySpeed;
        [SerializeField] private AbstractBulletMovement bulletMovement;

        public string Name
        {
            get => bulletName;
            set => bulletName = value;
        }

        public float XSpeed
        {
            get => xSpeed;
            set => xSpeed = value;
        }

        public float YSpeed
        {
            get => ySpeed;
            set => ySpeed = value;
        }
        
        public AbstractBulletMovement BulletMovement
        {
            get => bulletMovement;
            set => bulletMovement = value;
        }
    }
}
