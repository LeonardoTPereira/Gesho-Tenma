
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boss
{
    public class DeathBehavior : BossAttackState
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (BossPhaseOne == null) return;
            BossPhaseOne.DestroyBoss();
        }
    }
}