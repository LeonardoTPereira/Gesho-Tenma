using UnityEngine;

namespace Boss
{
    public class TripleShotBehavior : StateMachineBehaviour
    {
        private float _timer = 3f;
        private static readonly int Sinusoidal = Animator.StringToHash("Sinusoidal");
        private static readonly int Idle = Animator.StringToHash("Idle");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _timer = 3f;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateCountdown(ref _timer, animator);
            var bossHealth = animator.GetComponent<BossHealth>();
            var bossMovement = animator.GetComponent<BossMovement>();
            var bossPhaseOne = animator.GetComponent<BossPhaseOne>();

            bossMovement.FollowPlayerXAxis();
            bossPhaseOne.ShootPrimaryShot();
            if (bossHealth.Health <= bossHealth.MaxHealth/2)
            {
                animator.SetTrigger(Sinusoidal);
            }
        }

        private static float UpdateCountdown(ref float timer, Animator animator)
        {
            if (timer <= 0)
            {
                animator.SetTrigger(Idle);

            }
            else
            {
                //Debug.Log("Tempo: "+timer);
                timer -= Time.deltaTime;
            }
            return timer;
        }
    }
}
