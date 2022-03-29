using UnityEngine;

namespace Weapons
{
    [System.Serializable]
    public class WeaponShooters
    {
        [SerializeField] private Transform[] shootersTransforms;

        public Transform[] ShootersTransforms
        {
            get => shootersTransforms;
            set => shootersTransforms = value; }
    }
}