using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IddleState : AbstractState
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 velocity = _controller.inputs.move * speed * _controller.speedMultiplicator;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
        
        base.OnStateUpdate(animator,stateInfo,layerIndex);
    }

    
}
