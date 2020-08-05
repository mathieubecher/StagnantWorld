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

        public bool IsReleasable(int index, float time)
        {
            if(index == 0) return _inventory.weapon1.IsReleasable(time);
            return _inventory.weapon2.IsReleasable(time);
        }
        public Attack GetAttack(int index, float time)
        {
            if(index == 0) return _inventory.weapon1.GetNext(time);
            return _inventory.weapon2.GetNext(time);
        }
        public bool IsChargable(int index)
        {
            return (index==0)? _inventory.weapon1.IsChargable() : _inventory.weapon2.IsChargable();
        }
        public Attack GetCharge(int index)
        {
            return  (index==0)? _inventory.weapon1.GetCharge() : _inventory.weapon2.GetCharge();
        }
        #endregion


        
    }


}
