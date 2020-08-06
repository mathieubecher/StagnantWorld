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


        private Attack actual;

        private float releaseTime = InputManager.waitCharge;
        public bool ExistCharge()
        {
            return charge != null;
        }

        public Attack GetCharge()
        {
            actual = Instantiate(charge);
            return actual;
        }

        public bool ExistRelease()
        {
            return release != null;
            //return ((time > releaseTime && release != null) || (time < releaseTime && attacks.Count > 0));
        }
        
        public Attack GetRelease()
        {
            actual = Instantiate(release);
            return actual;
        }
        public Attack GetNext()
        {
            ++last;
            if (last >= attacks.Count) last = 0;
            actual = Instantiate(attacks[last]);
            return actual;
        }

        public bool ExistAttack()
        {
            return attacks.Count > 0;
        }

        public void OnHit(Collider other)
        {
            actual.OnHit(other);
        }
    }
}