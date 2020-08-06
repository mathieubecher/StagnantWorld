using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;

namespace Item
{
    public class WeaponView : MonoBehaviour
    {
        public int id;
        public Weapon weapon;
        public bool attack;
        public Attack actualAttack;
        public Collider collider;

        void Awake()
        {
            collider = GetComponent<Collider>();
            collider.enabled = false;
        }
        
        /*
        public void Attack(Controller controller, Attack _attack)
        {
            attack = true;
            actualAttack = _attack;
            _collider.enabled = true;
            actualAttack.OnCall(controller, this);
        }
        */
        
        void Update()
        {
            
        }

        public void OnTriggerEnter(Collider other)
        {
            // TODO gestion trigger
            // actualAttack.OnHit(other);
        }

    }
}
