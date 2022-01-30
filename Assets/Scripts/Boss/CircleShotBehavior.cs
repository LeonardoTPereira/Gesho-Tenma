using UnityEngine;

namespace Boss
{
    public class CircleShotBehavior : BossAttackState
    {
        private static readonly int Death = Animator.StringToHash("Death");

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (BossMovement != null)
            {
                BossMovement.MoveLeftToRight();
            }
            if (BossPhaseOne != null)
            {
                BossPhaseOne.ShootSemiCircleShot();
            }
            
            if (BossHealth == null) return;

            if (BossHealth.Health > 0) return;
            
            InvokeDeathEvent();
            animator.SetTrigger(Death);
        }
    }
}