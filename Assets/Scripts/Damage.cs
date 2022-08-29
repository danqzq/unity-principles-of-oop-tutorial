using UnityEngine;

namespace Dan
{
    public readonly struct Damage
    {
        public readonly float amount;
        public readonly Transform damageDealer;
        
        public Damage(float amount, Transform damageDealer)
        {
            this.amount = amount;
            this.damageDealer = damageDealer;
        }
    }
}