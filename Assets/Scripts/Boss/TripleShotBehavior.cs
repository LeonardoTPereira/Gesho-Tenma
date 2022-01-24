using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotBehavior : StateMachineBehaviour
{
    public float timer = 3f;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 3f;
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Timer(timer, animator);
        BossPhaseOne boss = animator.GetComponent<BossPhaseOne>();
        BossMovement bossMovement = animator.GetComponent<BossMovement>();
        
        bossMovement.FollowPlayerYAxis();
        boss.ShootPrimaryShot();
    } 

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


    public void Timer(float timer, Animator animator)
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
