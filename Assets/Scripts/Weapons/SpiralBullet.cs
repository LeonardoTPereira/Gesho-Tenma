using System.Collections;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "SpiralBulletBehavior", menuName = "Scriptable Objects/Spiral Bullet", order = 0)]
    public class SpiralBullet : AbstractBulletMovement
    {
        public override IEnumerator Move(Vector2 speed, BulletController bulletController)
        {
            var angle = 0.0f;
            var angleStep = 10f;
            while (bulletController!=null)
            {
                var directionX = bulletController.transform.position.x + SinMovement(angle);
                var directionY = bulletController.transform.position.y + CosMovement(angle);

                var moveDirection = new Vector3(directionX, directionY, 0f).normalized;

                angleStep *= Mathf.Pow(-1, (float)((int)angle / 360));
                angle += angleStep;   

                bulletController.RigidBody.velocity = moveDirection*speed;
            
                yield return new WaitForSeconds(0.1f);
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
