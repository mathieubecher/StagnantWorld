using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Item;

namespace State
{
    public enum AttackType
    {
        ATTACK, RELEASE, CHARGE
    }
    public class Attack : Iddle
    {
        protected Item.Attack _attack;
        protected Weapon _weapon;
        protected AttackType _type;

        public Attack(Controller controller, Weapon weapon,AttackType type) : base(controller)
        {
            _type = type;
            _attack = GetAttack(weapon);
            _attack.OnCall(controller,weapon);
            controller.stateName = GetName();
        }

        protected Item.Attack GetAttack(Weapon weapon)
        {
            _weapon = weapon;
            
            switch (_type)
            {
                case AttackType.RELEASE:
                    return _weapon.GetRelease();
                    break;
                case AttackType.CHARGE:
                    return _weapon.GetCharge();
                    break;
                default :
                    return _weapon.GetNext();
                    break;
            }
        }
        
        public override void Update()
        {
            base.Update();
            _attack.Update();
            if (_attack.Time()) Exit();
        }

        public void Exit()
        {
            switch (_type)
            {
                case AttackType.ATTACK:
                    IddleState();
                    break;
                case AttackType.RELEASE:
                    IddleState();
                    break;
                case AttackType.CHARGE:
                    if (_weapon.ExistRelease()) ReleaseState();
                    else IddleState();
                    break;
            }
        }
        
        protected override float GetSpeed()
        {
            return _controller.GetSpeed() * _attack.speed;
        }
        
        public override void ReleaseState(){
            if(_weapon.ExistRelease()) _controller.state = new Attack(_controller,_weapon,AttackType.RELEASE);
        }

        protected override void IddleState()
        {
            _attack.OnExit();
            base.IddleState();
        }

        public override void AttackState(Weapon weapon) {
        }
        
        public override void ChargeState(Weapon weapon){
        }

        public override void SkillState(Skills.Skill skill)
        {
        }
        
        protected override string GetName()
        {
            return "Attack."+_type;
        }
        
    }
}