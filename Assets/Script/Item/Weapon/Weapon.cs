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

        public bool IsChargable()
        {
            return charge != null;
        }

        public Attack GetCharge()
        {
            return Instantiate(charge);
        }
        public bool IsReleasable(float time)
        {
            return ((time > 0.2 && release != null) || (time < 0.2f && attacks.Count > 0));
        }
        public Attack GetNext(float time)
        {
            if (release == null || (release != null && time < 0.2f))
            {
                ++last;
                if (last >= attacks.Count) last = 0;
                return Instantiate(attacks[last]);
            }
            else
            {
                return Instantiate(release);
            }
        }
    }
}