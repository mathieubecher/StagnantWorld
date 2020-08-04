using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractState : StateMachineBehaviour
{
    protected Controller _controller;
    protected Rigidbody _rigidbody;
    [SerializeField] protected float speed;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _controller = animator.GetComponent<Controller>();
        _rigidbody = animator.GetComponent<Rigidbody>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetDirection();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    
    public void SetDirection()
    {
        Vector3 moveDirection = _rigidbody.velocity;
        moveDirection.y = 0;
        
        _controller.character.SetDirection(moveDirection);
        _controller.character.SetSpeed(moveDirection.magnitude/speed);
    }
}
