using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;

namespace State
{
    public abstract class Abstract
    {
        public enum Type
        {
            IDDLE, SKILL, ATTACK, HIT, DEAD
        }
        protected Controller _controller;
        protected Rigidbody _rigidbody;

        public Abstract(Controller controller)
        {
            _controller = controller;
            _rigidbody = controller.rigidbody;
            _controller.state = this;
        }

        public abstract void Update();
        protected virtual void IddleState(){_controller.state = new Iddle(_controller);}
        public virtual void AttackState(Weapon weapon){}
        public virtual void ChargeState(Weapon weapon){}
        public virtual void ReleaseState(){}
        public virtual void SkillState(Skills.Competence competence) {}

        protected void SetDirection()
        {
            Vector3 moveDirection = _rigidbody.velocity;
            moveDirection.y = 0;
        
            _controller.character.SetDirection(moveDirection);
            _controller.character.SetSpeed(moveDirection.magnitude);
        }

        protected virtual string GetName()
        {
            return GetType().ToString();
        }

    }

}
