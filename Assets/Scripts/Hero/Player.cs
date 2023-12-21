using Base;
using UnityEngine;

namespace Hero
{
    [RequireComponent(typeof(Health))]
    public class Player : Person
    {
        public Health Health { get; private set; }
        public int DamageValue => Health.DamageValue;

        private void Awake()
        {
            Health = GetComponent<Health>();
        }
    }
}