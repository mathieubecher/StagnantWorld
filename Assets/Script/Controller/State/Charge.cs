using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class Charge : Abstract
    {
        public int input;
        public Item.Attack attack;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            input = animator.GetInteger("attackInput");
            base.OnStateEnter(animator,stateInfo,layerIndex);
            if (input == 0)
            {
                attack = _controller.model.GetCharge(0);
                _controller.character.weapon1.Attack(_controller, attack);
            }
            else
            {
                attack = _controller.model.GetCharge(1);
                _controller.character.weapon2.Attack(_controller, attack);
            }
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Vector3 velocity = _controller.inputs.move * GetSpeed() * attack.speed;
            velocity.y = _rigidbody.velocity.y;
            _rigidbody.velocity = velocity;
        }
        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }

        public void Release()
        {
            attack.OnExit();
            _controller.character.ReleaseAnimation();
        }
    }
}