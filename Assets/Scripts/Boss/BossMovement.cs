using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Boss
{
    public class BossMovement : MonoBehaviour
    {
        private Transform playerPosition;
        private PixelPerfectCamera pixelPerfectCamera;

        public float speed;

        void Start()
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        public void FollowPlayerXAxis()
        {
            Vector3 target = new Vector3(playerPosition.position.x, transform.position.y, 0);
            transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        }

        public void ShotInRandomPositions() 
        {
            List<float> positions = new List<float>();
            for (int i = 0; i < 3; i++)
            {
                float position = (pixelPerfectCamera.refResolutionX / pixelPerfectCamera.assetsPPU)*Random.Range(1,10);

            }
            Vector3 target = new Vector3(positions[Random.Range(1, 4)], transform.position.y, 0);
            transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        }
    }
}
