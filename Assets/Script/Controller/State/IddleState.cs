using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IddleState : AbstractState
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rigidbody.velocity = _controller.inputs.move;
    }
    
}
