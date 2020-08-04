using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSheet
{
    [CreateAssetMenu(fileName = "Interface", menuName = "Interface/Interface")]
    public class Interface : ScriptableObject
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private GameObject _statusPrefab;
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
        #endregion
    }


}
