using UnityEngine;

namespace Boss
{
    public class SinusoidalShotBehavior : BossAttackState
    {
        private static readonly int Circle = Animator.StringToHash("Circle");

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (BossMovement != null)
            {
                BossMovement.MoveLeftToRight();
            }

            if (BossPhaseOne != null)
            {
                BossPhaseOne.ShootSecondaryShot();
            }

            if(BossHealth == null) return;
            
            if (BossHealth.Health > BossHealth.MaxHealth * 0.3) return;
            
            InvokePowerUpEvent();
            animator.SetTrigger(Circle);
        }
    }
}