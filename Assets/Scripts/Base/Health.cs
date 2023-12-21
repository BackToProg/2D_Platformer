using System;
using UnityEngine;

namespace Base
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _healValue = 35;
        [SerializeField] private int _damageValue = 25;

        private int _currentHealth;

        public event Action OnDamage;
        public event Action OnHeal;

        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;
        public int DamageValue => _damageValue;
        public int HealValue => _healValue;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth = Math.Max(0, _currentHealth - damage);

            if (_currentHealth == 0)
                Die();

            OnDamage?.Invoke();
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        public void Heal(int healValue)
        {
            _currentHealth = Math.Min(_maxHealth, _currentHealth + healValue);

            OnHeal?.Invoke();
        }
    }
}