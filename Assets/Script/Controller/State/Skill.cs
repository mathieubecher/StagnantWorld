using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;

namespace State
{
    public class Skill : Iddle
    {
        public bool invulnerability;
        protected Skills.Competence Competence;
        public Skill(Controller controller, Skills.Competence competence) :base(controller)
        {
            Competence = competence;
            Competence.OnCall(controller);
        }

        public override void Update()
        {
            Competence.Update();
            base.Update();
            if (Competence.Time()) Exit();
        }

        public void Exit()
        {
            Competence.OnExit();
            IddleState();
        }
        
        protected override float GetSpeed()
        {
            return _controller.GetSpeed() * Competence.speed;
        }
        
        public override void ReleaseState(){
        }
        
        public override void AttackState(Weapon weapon) {
        }
        
        public override void ChargeState(Weapon weapon){
        }

        public override void SkillState(Skills.Competence competence)
        {
        }
    }
}