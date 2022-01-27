using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Boss
{
    public class BossMovement : MonoBehaviour
    {
        private Transform playerPosition;
        private bool isMovingRight;

        [SerializeField]private float speed;

        private void Awake()
        {
            isMovingRight = true;
            playerPosition = null;
        }

        void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            
            if (player != null)
            {
                playerPosition = player.GetComponent<Transform>();
            }
        }

        public void FollowPlayerXAxis()
        {
            if (playerPosition != null)
            {
                Vector3 target = new Vector3(playerPosition.position.x, transform.position.y, 0);
                transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
            }
        }

        public void MoveLeftToRight()
        {
            if (transform.position.x >= 4.0f)
            {
                isMovingRight = false;
            }
            else if (transform.position.x <= -4.0f) 
            {
                isMovingRight = true;
            }

            transform.position = isMovingRight
                ? new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z)
                : new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        public float Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
    }
}
