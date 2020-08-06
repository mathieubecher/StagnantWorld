using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace CharacterSheet
{
    [CreateAssetMenu(fileName = "Interface", menuName = "Interface/Interface")]
    public class Interface : ScriptableObject
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Statistics _statistics;
    
        private Status _status;

        /// <summary>
        /// Initialisation de l'interface
        /// </summary>
        public void Init(Transform parent)
        {
            _status = Instantiate((GameObject)Resources.Load("Status"), parent).GetComponent<Status>();
            _status.Init(_statistics);
        }

        #region Statistics
        /// <summary>
        /// Multiplicateur de vitesse
        /// </summary>
        public float GetSpeed()
        {
            return _statistics.normalSpeed;
        }

        /// <summary>
        /// Vie du personnage
        /// </summary>
        public float GetLife()
        {
            return _statistics.life;
        }

        public void AddDamage(float damage)
        {
            _status.AddDamage(damage);
        }
        #endregion
        
        #region Attack

        public Weapon GetWeapon(int index)
        {
            return (index == 0) ? _inventory.weapon1 : _inventory.weapon2;
        }
        
        
        public bool ExistRelease(int index)
        {
            if(index == 0) return _inventory.weapon1.ExistRelease();
            return _inventory.weapon2.ExistRelease();
        }

        public Attack GetRelease(int index)
        {
            if(index == 0) return _inventory.weapon1.GetRelease();
            return _inventory.weapon2.GetRelease();
        }
        public Attack GetAttack(int index)
        {
            if(index == 0) return _inventory.weapon1.GetNext();
            return _inventory.weapon2.GetNext();
        }
        public bool ExistCharge(int index)
        {
            return (index==0)? _inventory.weapon1.ExistCharge() : _inventory.weapon2.ExistCharge();
        }
        public Attack GetCharge(int index)
        {
            return  (index==0)? _inventory.weapon1.GetCharge() : _inventory.weapon2.GetCharge();
        }
        #endregion


        public bool ExistAttack(int index)
        {
            return (index==0)? _inventory.weapon1.ExistAttack() : _inventory.weapon2.ExistAttack();
        }
    }


}
