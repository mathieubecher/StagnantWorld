using UnityEngine;

namespace Item
{
    public abstract class Item : ScriptableObject{
        public enum Type
        {
            ITEM, CUNSUMABLE, ARMOR, WEAPON
        }
        //TODO à gérer le rendu
        [Header("View")]
        public Mesh view;
        public Material material;
        public Sprite icon;
        
        [Header("Infos")]
        public string name;
        public string description;
        public Type type;
    }
}