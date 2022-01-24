using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBehavior : StateMachineBehaviour
{
    public float timer = 2f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            //animator.SetTrigger("TripleShot");
            animator.SetTrigger("Idle");

        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
