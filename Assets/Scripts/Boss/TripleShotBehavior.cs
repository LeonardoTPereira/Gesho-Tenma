using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class TripleShotBehavior : StateMachineBehaviour
    {
        public float timer = 3f;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            timer = 3f;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Timer(ref timer, animator);
            BossPhaseOne boss = animator.GetComponent<BossPhaseOne>();
            BossMovement bossMovement = animator.GetComponent<BossMovement>();

            bossMovement.FollowPlayerYAxis();
            boss.ShootPrimaryShot();
        }

        public float Timer(ref float timer, Animator animator)
        {
            if (timer <= 0)
            {
                animator.SetTrigger("Idle");

            }
            else
            {
                Debug.Log("Tempo: "+timer);
                timer -= Time.deltaTime;
            }
            return timer;
        }
    }
}
