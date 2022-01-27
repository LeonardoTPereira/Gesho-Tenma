using UnityEngine;

namespace Boss
{
    public class SinusoidalShotBehavior : StateMachineBehaviour
    {
        private static readonly int Circle = Animator.StringToHash("Circle");
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

            bossMovement.FollowPlayerXAxis();
            bossPhaseOne.ShootSecondaryShot();

            if (bossHealth.Health <= bossHealth.MaxHealth/3)
            {
                animator.SetTrigger(Circle);
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