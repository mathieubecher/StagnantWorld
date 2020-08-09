using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    
    [CreateAssetMenu(fileName = "new skill", menuName = "Skills/Skill")]
    public class Skill : Action
    {
        // Comportement
        [HideInInspector] public Controller owner;
        public void OnCall(Controller controller)
        {
            owner = controller;
            base.OnCall(controller,controller.character.SetAnimation(animation));
            
        }

        public override void Update()
        {
            if (!rotate) owner.inputs.move = owner.character.transform.rotation * Vector3.forward;
        }

        public override void OnExit()
        {
            base.OnExit();
        }
        
    }
    
}
