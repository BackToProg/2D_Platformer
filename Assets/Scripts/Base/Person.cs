using UnityEngine;

namespace Base
{
    public class Person : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected float movementMovementSpeed;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public float MovementSpeed => movementMovementSpeed;
    }
}