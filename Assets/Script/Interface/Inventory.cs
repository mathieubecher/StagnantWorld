using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;

namespace CharacterSheet
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Interface/Inventory")]
    public class Inventory : ScriptableObject
    {
        public Weapon weapon1;
        public Weapon weapon2;
    }
}
