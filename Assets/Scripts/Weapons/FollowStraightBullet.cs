using Player;
using System.Collections;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "FollowStraightBulletBehavior", menuName = "Scriptable Objects/Follow Straight Bullet", order = 0)]
    public class FollowStraightBullet : AbstractBulletMovement
    {
        private Transform _playerPosition;
        public override IEnumerator Move(Vector2 speed, BulletController bulletController)
        {
            PlayerController playerControl = FindObjectOfType<PlayerController>();
            if (playerControl != null)
            {
                var playerPosition = playerControl.transform.position;
                var direction = (playerPosition - bulletController.transform.position).normalized;
                bulletController.RigidBody.velocity = direction * speed;
                yield return null;
            }
        }
    }
}
