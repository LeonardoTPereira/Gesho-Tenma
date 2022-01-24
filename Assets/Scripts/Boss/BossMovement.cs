using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossMovement : MonoBehaviour
    {
        private Transform playerPosition;

        public float speed;

        void Start()
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        public void FollowPlayerYAxis()
        {
            Vector3 target = new Vector3(playerPosition.position.x, transform.position.y, 0);
            transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        }
    }
}
