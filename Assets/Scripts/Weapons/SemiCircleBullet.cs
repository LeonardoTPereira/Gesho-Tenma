using System.Collections;
using UnityEngine;


namespace Weapons
{
    [CreateAssetMenu(fileName = "SemiCircleBulletBehavior", menuName = "Scriptable Objects/Semi Circle Bullet", order = 0)]
    public class SemiCircleBullet : AbstractBulletMovement
    {
        private int _bulletAmount;
        private float _angle;
        private float _startAngle, _endAngle;

        private void Awake()
        {
            _angle = _startAngle;
            _startAngle = 0;
            _endAngle = 270;
            _bulletAmount = 8;
        }

        public override IEnumerator Move(Vector2 speed, BulletController bulletController)
        {

            float angleStep = (_endAngle - _startAngle) / _bulletAmount;
            for (int i = 0; i < _bulletAmount; i++)
            {
                var bulletTransformPosition = bulletController.transform.position;
                float directionX = bulletTransformPosition.x + SinMovement();
                float directionY = bulletTransformPosition.y + CosMovement(); 
                var moveDirection = new Vector3(directionX, -directionY, 0f);
                var direction = (moveDirection - bulletTransformPosition).normalized;

                bulletController.RigidBody.velocity = direction * speed;
                _angle = _angle + angleStep;
            }
            

            yield return new WaitForSeconds(1f);
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