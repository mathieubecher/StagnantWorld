using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "new weapon", menuName = "Item/Weapon")]
    public class Weapon : Item
    {
        [HideInInspector] public int last = -1;
        [Header("Attacks")]
        public List<Attack> attacks;
        public Attack charge;
        public Attack release;

        private float releaseTime = InputManager.waitCharge;
        public bool ExistCharge()
        {
            return charge != null;
        }

        public Attack GetCharge()
        {
            return Instantiate(charge);
        }

        public bool ExistRelease()
        {
            return release != null;
            //return ((time > releaseTime && release != null) || (time < releaseTime && attacks.Count > 0));
        }
        
        public Attack GetRelease()
        {
            return Instantiate(release);
        }
        public Attack GetNext()
        {
            ++last;
            if (last >= attacks.Count) last = 0;
            return Instantiate(attacks[last]);
        }

        public bool ExistAttack()
        {
            return attacks.Count > 0;
        }
    }
}