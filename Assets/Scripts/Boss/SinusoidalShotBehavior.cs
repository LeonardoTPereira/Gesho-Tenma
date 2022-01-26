using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class SinusoidalShotBehavior : StateMachineBehaviour
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

            bossMovement.FollowPlayerXAxis();
            boss.ShootSecondaryShot();

            if (boss.Health <= 66)
            {
                animator.SetTrigger("Circle");
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