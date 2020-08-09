using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "new attack", menuName = "Item/State/Attack")]
    public class Attack : Action
    {
        public enum Type
        {
            ATTACK, PROTECT
        }
        
        /// <summary>
        /// Valeur de l'arme
        /// </summary>
        public float value;
        /// <summary>
        /// Effet de l'arme (null si aucun effet)
        /// </summary>
        public Condition effect;

        public Type type;

        
        private Weapon _weapon;
        private bool active = true;
        private List<Character> hits;
        
        public void OnCall(Controller controller, Weapon weapon)
        {
            base.OnCall(controller,controller.character.SetAnimation(animation));
            
            if (type == Type.PROTECT) active = false;
            hits = new List<Character>();
            _weapon = weapon;
            controller.character.SetWeaponCollider(weapon, true);
            
        }


        public override void Update()
        {
            base.Update();
        }

        public override void OnExit()
        {
            base.OnExit();
            owner.character.SetWeaponCollider(_weapon, false);
        }

        public void OnHit(Collider other)
        {
            
            if (active)
            {
                if (other.gameObject.layer == LayerMask.NameToLayer("Character") && other.gameObject.TryGetComponent(out Character target) && !hits.Contains(target))
                {
                    target.controller.Hit(owner, value);
                    hits.Add(target);
                }
                else if (other.gameObject.layer == LayerMask.NameToLayer("Weapon") && other.gameObject.TryGetComponent(out WeaponView block)) {
                    Block();
                }
                else
                {
                    //TODO Bloque l'attaque sur les mur si non constant
                }
            }
        }

        private void Block()
        {
            active = false;
        }
    }
}

