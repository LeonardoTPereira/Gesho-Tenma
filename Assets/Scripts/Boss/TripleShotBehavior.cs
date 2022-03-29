using UnityEngine;

namespace Boss
{
    public class TripleShotBehavior : BossAttackState
    {
        private static readonly int Sinusoidal = Animator.StringToHash("Sinusoidal");
        private static readonly int Idle = Animator.StringToHash("Idle");
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            Timer = 2f;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //CheckTimedTransition(animator, Idle);

            if (BossMovement != null)
            {
                BossMovement.FollowPlayerXAxis();
            }

            if (BossPhaseOne != null)
            {
                BossPhaseOne.ShootPrimaryShot();
                BossPhaseOne.ShootFollowStraightShot();
            }
            
            if(BossHealth == null) return;

            if (BossHealth.Health > BossHealth.MaxHealth * 0.6) return;
            
            InvokePowerUpEvent();
            animator.SetTrigger(Sinusoidal);
        }
    }
}
