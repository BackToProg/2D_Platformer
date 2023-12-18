using Base;
using UnityEngine;

namespace Rival
{
    [RequireComponent(typeof(Health))]
    public class Enemy : Person
    {
        [SerializeField] private float _attackDistance;
        [SerializeField] private int _attackSpeed;
        [SerializeField] private int _chaseDistance;
        [SerializeField] private float _chaseSpeed;

        public float AttackDistance => _attackDistance;
    
        public float ChaseSpeed => _chaseSpeed;

        public float ChaseDistance => _chaseDistance;

        public int AttackSpeed => _attackSpeed;
        
        public Health Health { get; private set; }

        private void Awake()
        {
            Health = GetComponent<Health>();
        }

    }
}