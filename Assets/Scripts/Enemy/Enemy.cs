using Base;
using UnityEngine;

namespace Enemy
{
    public class Enemy : Person
    {
        [SerializeField] private float _attackDistance;
        [SerializeField] private int _attackSpeed;
        [SerializeField] private int _chaseDistance;
        [SerializeField] private float _chaseSpeed;

        public float AttackDistance() => _attackDistance;
    
        public float ChaseSpeed() => _chaseSpeed;

        public float ChaseDistance() => _chaseDistance;

        public int AttackSpeed() => _attackSpeed;

    }
}