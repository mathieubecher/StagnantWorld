﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class Attack : Abstract
    {
        public Item.Attack attack;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator,stateInfo,layerIndex);
            if (animator.GetInteger("attackInput") == 0)
            {
                attack = _controller.model.GetAttack(0, animator.GetFloat("charge"));
                _controller.character.weapon1.Attack(_controller, attack);
            }
            else
            {
                attack = _controller.model.GetAttack(1, animator.GetFloat("charge"));
                _controller.character.weapon2.Attack(_controller, attack);
            }
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Vector3 velocity = _controller.inputs.move * GetSpeed() * attack.speed;
            velocity.y = _rigidbody.velocity.y;
            _rigidbody.velocity = velocity;
        }
    }
}