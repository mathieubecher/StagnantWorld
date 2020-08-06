using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;

namespace CharacterSheet
{
    public class Status : MonoBehaviour
    {
        private Statistics statistics;
        private bool init;
        private float life {get => statistics.life; set => statistics.life = value; }
        public float maxLife {get => statistics.maxLife;
            set
            {
                statistics.maxLife = value * MAXLIFE;
                if (statistics.life > statistics.maxLife) statistics.life = statistics.maxLife;
            }
        }
        private float MAXLIFE {get => statistics.MAXLIFE;}
        private float speed {get => statistics.speed; set => statistics.speed = value; }
        private float maxSpeed {get => statistics.normalSpeed; set => statistics.normalSpeed = value; }

        // Effect
        private List<Condition> conditions; 
        
        public void Init(Statistics status)
        {
            statistics = status;
            statistics.Init();
            conditions = new List<Condition>();
            init = true;
        }

        void Update()
        {
            if (!init) return;
            ConditionsGestor();
        }
        
        /// <summary>
        /// Inflige des dégats au personnage
        /// </summary>
        /// <param name="damage">dégats reçus</param>
        /// <returns>Vérifie si le personnage est encore en vie</returns>
        public bool AddDamage(float damage)
        {
            life -= damage * Time.deltaTime;
            return (life > 0);
        }

        /// <summary>
        /// Soigne le personnage
        /// </summary>
        /// <param name="heal">soins reçus</param>
        public void AddHeal(float heal)
        {
            life += heal * Time.deltaTime;
            if (life > maxLife) life = maxLife;
        }
        
        /// <summary>
        /// Ajoute un état au personnage
        /// </summary>
        /// <param name="condition">Etat appliqué au personnage</param>
        public void AddCondition(Condition condition)
        {
            if (!condition.cumulative || !conditions.Exists(x => x.type == condition.type))
            {
                conditions.Add(condition);
            }
        }
        
        private void ConditionsGestor()
        {
            for (int i = conditions.Count - 1; i >= 0; ++i)
            {
                Condition condition = conditions[i];
                if (condition.Effect(this)) conditions.Remove(condition);
            }
        }
        
    }
}
