using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSheet
{
    [CreateAssetMenu(fileName = "New Statistics", menuName = "Interface/Statistics")]
    public class Statistics : ScriptableObject
    {
        // Life
        [HideInInspector] public float life;
        [HideInInspector] private float _MAXLIFE;

        public float MAXLIFE
        {
            get => _MAXLIFE;
        }

        public float maxLife;

        // Speed
        [HideInInspector] public float speed;
        [HideInInspector] public float normalSpeed = 1;

        public void Init()
        {
            life = maxLife;
            _MAXLIFE = life;
            speed = normalSpeed;
        }
    }
}