﻿using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;

namespace CharacterSheet
{
    [CreateAssetMenu(fileName = "Interface", menuName = "Interface/Interface")]
    public class Interface : ScriptableObject
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Statistics _statistics;
        [SerializeField] private Skills.Competence _skill1;
        [SerializeField] private Skills.Competence _skill2;
    
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
        #endregion

        public Skills.Competence GetSkill(int input)
        {
            return (input == 0) ? _skill1 : _skill2;
        }
    }


}
