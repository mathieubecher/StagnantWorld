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
        public Collider collider;

        void Awake()
        {
            collider = GetComponent<Collider>();
            collider.enabled = false;
        }

        void Update()
        {
            
        }

        public void OnTriggerEnter(Collider other)
        {
            // TODO gestion trigger
            weapon.OnHit(other);
        }

    }
}
