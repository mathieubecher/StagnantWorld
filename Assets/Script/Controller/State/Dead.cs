using System.Collections;
using System.Collections.Generic;
using State;
using UnityEngine;

public class Dead : Abstract
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator,stateInfo,layerIndex);
        animator.SetBool("isDead", true);
    }
}
