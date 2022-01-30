using System;
using UnityEngine;

namespace Boss
{
    public class BossAttackState : StateMachineBehaviour

    {
        protected float Timer { get; set; }
        protected BossHealth BossHealth;
        protected BossMovement BossMovement;
        protected BossPhaseOne BossPhaseOne;
        public static event EventHandler BossPowerUpEventHandler;
        public static event EventHandler BossDeathEventHandler;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Timer = 3f;
            BossHealth = animator.GetComponent<BossHealth>();
            BossMovement = animator.GetComponent<BossMovement>();
            BossPhaseOne = animator.GetComponent<BossPhaseOne>();
        }
        
        protected void CheckTimedTransition(Animator animator, int triggerId)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                animator.SetTrigger(triggerId);
            }
        }

        protected void InvokePowerUpEvent()
        {
            BossPowerUpEventHandler?.Invoke(null, EventArgs.Empty);
        }    
        protected void InvokeDeathEvent()
        {
            BossDeathEventHandler?.Invoke(null, EventArgs.Empty);
        }

    }
}