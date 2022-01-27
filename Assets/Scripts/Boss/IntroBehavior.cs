using UnityEngine;

namespace Boss
{
    public class IntroBehavior : StateMachineBehaviour
    {
        private static readonly int Idle = Animator.StringToHash("Idle");
        public float Timer { get; set; } = 2f;

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Timer <= 0)
            {
                animator.SetTrigger(Idle);
            }
            else
            {
                Timer -= Time.deltaTime;
            }
        }
    }
}