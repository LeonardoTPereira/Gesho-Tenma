using UnityEngine;

namespace Boss
{
    public class CircleShotBehavior : StateMachineBehaviour
    {
        private static readonly int Death = Animator.StringToHash("Death");
        public float Timer { get; set; } = 3f;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Timer = 3f;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var bossHealth = animator.GetComponent<BossHealth>();
            var bossMovement = animator.GetComponent<BossMovement>();
            var bossPhaseOne = animator.GetComponent<BossPhaseOne>();

            //bossMovement.MoveLeftToRight();
            bossPhaseOne.ShootSemiCircleShot();

            if (bossHealth.Health <= 0)
            {
                animator.SetTrigger(Death);
            }
        }
        public float UpdateCountdown(ref float timer, Animator animator)
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