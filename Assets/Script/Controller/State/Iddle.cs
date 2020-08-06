using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item;

namespace State
{
    public class Iddle : Abstract
    {
        public Iddle(Controller controller) : base(controller)
        {
                
        }
        public override void Update()
        {
            Vector3 velocity = _controller.inputs.move * GetSpeed();
            velocity.y = _rigidbody.velocity.y;
            _rigidbody.velocity = velocity;
        
            SetDirection();
        }

        protected virtual float GetSpeed()
        {
            return _controller.GetSpeed();
        }

        public override void AttackState(Weapon weapon) {
            if(weapon.ExistAttack())_controller.state = new Attack(_controller,weapon, AttackType.ATTACK);
        }
        
        public override void ChargeState(Weapon weapon){
            if(weapon.ExistCharge())_controller.state = new Attack(_controller,weapon, AttackType.CHARGE);
        }
    }
}