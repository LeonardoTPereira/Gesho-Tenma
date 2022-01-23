using System.Collections;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "StraightBulletBehavior", menuName = "Scriptable Objects/Straight Bullet", order = 0)]
    public class StraightBullet : AbstractBulletMovement
    {
        public override IEnumerator Move(Vector2 speed, BulletController bulletController)
        {
            bulletController.RigidBody.velocity = speed;
            yield return null;
        }
    }
}
