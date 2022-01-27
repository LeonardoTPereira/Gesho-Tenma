using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class CircleShotBehavior : StateMachineBehaviour
    {
        public float timer = 3f;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            timer = 3f;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            BossPhaseOne boss = animator.GetComponent<BossPhaseOne>();
            BossMovement bossMovement = animator.GetComponent<BossMovement>();

            //bossMovement.MoveLeftToRight();
            boss.ShootSemiCircleShot();

            if (boss.Health <= 0)
            {
                animator.SetTrigger("Death");
            }
        }
        public float Timer(ref float timer, Animator animator)
        {
            if (timer <= 0)
            {
                Debug.Log("Do something");
            }
            else
            {
                timer -= Time.deltaTime;
            }
            return timer;
        }
    }
}