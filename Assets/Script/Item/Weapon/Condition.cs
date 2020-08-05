using System.Collections;
using System.Collections.Generic;
using CharacterSheet;
using UnityEngine;

namespace Item
{
    
    [CreateAssetMenu(fileName = "new condition", menuName = "Item/State/Condition")]
    public class Condition : ScriptableObject
    {
        public enum StateType
        {
            HEAL, POISONED, CURSED
        }
   
        /// <summary>
        /// Durée en secondes de l'effet (-1 si infini)
        /// </summary>
        [Header("Info")]
        public float time;
        public StateType type;
        public float value;
    
        /// <summary>
        /// Si l'état est cumulable avec d'autres état du même type 
        /// </summary>
        public bool cumulative
        {
            get { return type != StateType.CURSED; }
        }
    
        /// <summary>
        /// Mise à jour de l'effet
        /// </summary>
        /// <param name="status">Status du personnage affecté</param>
        /// <returns>Vérifie si l'état est fini</returns>
        public bool Effect(Status status)
        {

            switch (type)
            {
                case Condition.StateType.HEAL :
                    status.AddHeal(value);
                    break;
                case Condition.StateType.POISONED :
                    status.AddDamage(value);
                    break;
                case Condition.StateType.CURSED :
                    status.maxLife = value;
                    break;
            }
            if (time > 0)
            {
                time -= Time.deltaTime;
                if (type == Condition.StateType.CURSED) status.maxLife = 1;
            
                return (time <= 0);
            
            }   
            return false;
        }

    }   

}
