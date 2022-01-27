using System;
using UnityEngine;

namespace Animation
{
    public class WarningEnd : StateMachineBehaviour
    {
        public static event EventHandler IntroEndedEventHandler;
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            IntroEndedEventHandler?.Invoke(null, EventArgs.Empty);
            animator.gameObject.SetActive(false);
        }
    }
}
