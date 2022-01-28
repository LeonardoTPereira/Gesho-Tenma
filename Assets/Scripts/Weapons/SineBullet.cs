using System.Collections;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "SineBulletBehavior", menuName = "Scriptable Objects/Sine Bullet", order = 0)]
    public class SineBullet : AbstractBulletMovement
    {
        public override IEnumerator Move(Vector2 speed, BulletController bulletController)
        {
            var angle = 0.0f;
            var angleStep = 10f;
            while (bulletController!=null)
            {
                var directionX = SinMovement(angle);
                var directionY = 1;

                var moveDirection = new Vector3(directionX, directionY, 0f);


                angleStep *= Mathf.Pow(-1, angle / 360);
                angle += angleStep;
                

                bulletController.RigidBody.velocity = moveDirection*speed;
            
                yield return new WaitForSeconds(0.05f);
            }

            yield return null;
        }

        private float SinMovement(float angle)
        {
            return Mathf.Sin(angle * Mathf.PI / 180f);
        }
        private float CosMovement(float angle)
        {
            return Mathf.Cos(((angle + 180f) * Mathf.PI) / 180f);
        }
    }
}
