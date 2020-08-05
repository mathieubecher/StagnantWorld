using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class Iddle : Abstract
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            animator.SetFloat("charge",0);
            animator.SetBool("isDead", false);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Vector3 velocity = _controller.inputs.move * GetSpeed();
            velocity.y = _rigidbody.velocity.y;
            _rigidbody.velocity = velocity;
        
            SetDirection();
        }
        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }
    }
}