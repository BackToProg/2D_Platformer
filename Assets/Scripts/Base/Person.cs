using UnityEngine;

namespace Base
{
    public class Person : MonoBehaviour
    {
        [SerializeField] protected int _health;
        [SerializeField] protected int _damage;
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected float movementMovementSpeed;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public int Damage => _damage;

        public int Health => _health;

        public float MovementSpeed => movementMovementSpeed;

        public bool IsAlive => _health >= 0;
        
        public void TakeDamage(int damage) => _health -= damage;
        
        public void Destroy()
        {
            Destroy(gameObject);
        }

        protected void IncreaseHealthValue(int healValue) => _health += healValue;
    }
}