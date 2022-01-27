using UnityEngine;

namespace Boss
{
    public class IdleBehavior : StateMachineBehaviour
    {
        private static readonly int TripleShot = Animator.StringToHash("TripleShot");
        public float Timer { get; set; }
        public float MinimumTime { get; set; }
        public float MaximumTime { get; set; }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Timer = Random.Range(MinimumTime, MaximumTime);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Timer <= 0)
            {
                animator.SetTrigger(TripleShot);
            }
            else
            {
                Timer -= Time.deltaTime;
            }
        }


    }
}
