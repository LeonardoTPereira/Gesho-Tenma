using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class IntroBehavior : StateMachineBehaviour
    {
        public float timer = 2f;

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (timer <= 0)
            {
                animator.SetTrigger("Idle");
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}