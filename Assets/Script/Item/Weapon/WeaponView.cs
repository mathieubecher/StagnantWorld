using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;

namespace Item
{
    public class WeaponView : MonoBehaviour
    {
        public Weapon weapon;
        public bool attack;
        public Attack actualAttack;
        public Collider _collider;

        void Awake()
        {
            _collider = GetComponent<Collider>();
            _collider.enabled = false;
        }


        public void Attack(Controller controller, Attack _attack)
        {
            attack = true;
            actualAttack = _attack;
            _collider.enabled = true;
            actualAttack.OnCall(controller, this);
        }
        
        void Update()
        {
            if (attack)
            {
                actualAttack.Update();
            }
            else if(_collider.enabled) _collider.enabled = false;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (attack)
            {
                actualAttack.OnHit(other);
            }
        }

        public void Release()
        {
            if (attack)
            {
                actualAttack.OnExit();
            }
        }
    }
}
