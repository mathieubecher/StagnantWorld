using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;

namespace State
{
    public class Skill : Iddle
    {
        public bool invulnerability;
        protected Skills.Skill _skill;
        public Skill(Controller controller, Skills.Skill skill) :base(controller)
        {
            _skill = skill;
            _skill.OnCall(controller);
        }

        public override void Update()
        {
            _skill.Update();
            base.Update();
            if (_skill.Time()) Exit();
        }

        public void Exit()
        {
            _skill.OnExit();
            IddleState();
        }
        
        protected override float GetSpeed()
        {
            return _controller.GetSpeed() * _skill.speed;
        }
        
        public override void ReleaseState(){
        }
        
        public override void AttackState(Weapon weapon) {
        }
        
        public override void ChargeState(Weapon weapon){
        }

        public override void SkillState(Skills.Skill skill)
        {
        }
    }
}