using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private float _inputX;
        private float _inputY;
        [SerializeField] private float moveSpeed;
        public float MoveSpeed => moveSpeed;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = new Vector2(_inputX * MoveSpeed, _inputY * MoveSpeed);
        }

        public void Move(InputAction.CallbackContext context)
        {
            _inputX = context.ReadValue<Vector2>().x;
            _inputY = context.ReadValue<Vector2>().y;
        }
    }

}
