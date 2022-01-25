using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class IdleBehavior : StateMachineBehaviour
    {
        public float timer;
        public float minimunTime;
        public float maximunTime;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            timer = Random.Range(minimunTime, maximunTime);
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (timer <= 0)
            {
                animator.SetTrigger("TripleShot");
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }


    }
}
