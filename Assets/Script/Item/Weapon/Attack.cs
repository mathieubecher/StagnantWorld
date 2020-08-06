using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "new attack", menuName = "Item/State/Attack")]
    public class Attack : ScriptableObject
    {
        public enum Type
        {
            ATTACK, PROTECT
        }
        
        /// <summary>
        /// Durée de l'attaque, -1 si infini
        /// </summary>
        //public float duration;
        private float time;
        /// <summary>
        /// Valeur de l'arme
        /// </summary>
        public float value;
        /// <summary>
        /// Effet de l'arme (null si aucun effet)
        /// </summary>
        public Condition effect;

        public Type type;
        public string animation;
        public float speed = 0;

        
        // Comportement
        [HideInInspector] public Controller owner;
        private Weapon _weapon;
        private bool active = true;
        private List<Character> hits;
        
        public void OnCall(Controller controller, Weapon weapon)
        {
            if (type == Type.PROTECT) active = false;
            hits = new List<Character>();
            
            owner = controller;
            _weapon = weapon;
            time = controller.character.SetAttackAnimation(animation);
            controller.character.SetWeaponCollider(weapon, true);
            
        }

        public void Update()
        {
            
        }

        public bool Time()
        {
            if (time >= 0)
            {
                time -= UnityEngine.Time.deltaTime;
                if (time <= 0) return true;
            }
            return false;
        }

        public void OnExit()
        {
            owner.character.ReleaseAnimation();
            owner.character.SetWeaponCollider(_weapon, false);
        }

        public void OnHit(Collider other)
        {
            if (active)
            {
                if (other.gameObject.layer == LayerMask.NameToLayer("Character") && other.gameObject.TryGetComponent(out Character target) && !hits.Contains(target))
                {
                    target.controller.Hit(value);
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

