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
        /// Effet de l'arme (null si aucun effet)
        /// </summary>
        public Condition effect;
        /// <summary>
        /// Valeur de l'arme
        /// </summary>
        public float value;

        public Type type;
        public string animation;
        public float speed = 0;

        
        // Comportement
        [HideInInspector] public Controller owner;
        private WeaponView _weapon;
        private bool active = true;
        private List<Character> hits;
        
        public void OnCall(Controller controller, WeaponView weapon)
        {
            if (type == Type.PROTECT) active = false;
            
            time = controller.character.SetAttackAnimation(animation);
            owner = controller;
            _weapon = weapon;
            hits = new List<Character>();
        }

        public void Update()
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
                if(time <= 0) OnExit();    
            }
        }

        public void OnExit()
        {
            _weapon.attack = false;
            _weapon.actualAttack = null;
            Destroy(this);
            owner.Exit();
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
                    if (block.attack && block.actualAttack.type == Type.PROTECT)
                    {
                        Block();
                    }
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

