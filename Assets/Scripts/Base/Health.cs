using UnityEngine;

namespace Base
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _healValue = 35;
        [SerializeField] private int _damageValue = 25;

        private int _currentHealth;

        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage()
        {
            ApplyDamage(_damageValue);
        }

        public void Heal()
        {
            ApplyHeal(_healValue);
        }

        private void ApplyDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth < 0)
            {
                _currentHealth = 0;
            }

            if (_currentHealth == 0)
                Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void ApplyHeal(int healValue)
        {
            _currentHealth += healValue;

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
    }
}