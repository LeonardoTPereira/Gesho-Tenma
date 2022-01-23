using System.Collections;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "SineBulletBehavior", menuName = "Scriptable Objects/Sine Bullet", order = 0)]
    public class SineBullet : AbstractBulletMovement
    {
        private float _angle;
        public override IEnumerator Move(Vector2 speed, BulletController bulletController)
        {
            var bulletTransformPosition = bulletController.transform.position;
            var directionX = bulletTransformPosition.x + SinMovement();
            var directionY = 1;

            var moveDirection = new Vector3(directionX, directionY, 0f);
            var direction = (moveDirection - bulletTransformPosition).normalized;

            _angle =(_angle+10f)%360f;

            bulletController.RigidBody.velocity = direction*speed;
            
            yield return new WaitForSeconds(0.1f);
        }

        private float SinMovement()
        {
            return Mathf.Sin(((_angle + 180f) * Mathf.PI) / 180f);
        }
        private float CosMovement()
        {
            return Mathf.Cos(((_angle + 180f) * Mathf.PI) / 180f);
        }
    }
}
