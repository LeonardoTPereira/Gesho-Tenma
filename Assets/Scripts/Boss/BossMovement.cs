using UnityEngine;

namespace Boss
{
    public class BossMovement : MonoBehaviour
    {
        private Transform _playerPosition;
        [SerializeField] private float speed;

        private void Awake()
        {
            _playerPosition = null;
        }

        private void Start()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            
            if (player != null)
            {
                _playerPosition = player.GetComponent<Transform>();
            }
        }

        public void FollowPlayerXAxis()
        {
            if (_playerPosition == null) return;
            var position = transform.position;
            var target = new Vector3(_playerPosition.position.x, position.y, 0);
            position = Vector3.Lerp(position, target, speed * Time.deltaTime);
            transform.position = position;
        }

        public void MoveHorizontallyAroundCenter()
        {
            if (Mathf.Abs(transform.position.x) > 4)
            {
                Speed = -1 * Speed;
            }
            var bossTransform = transform;
            var position = bossTransform.position;
            bossTransform.position = new Vector3(position.x + Speed * Time.deltaTime, position.y, position.z);
        }

        public float Speed
        {
            get => speed;
            set => speed = value;
        }
    }
}
