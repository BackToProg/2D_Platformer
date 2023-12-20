using UnityEngine;

namespace Base
{
    public class Person : MonoBehaviour
    {
        [SerializeField] protected float movementMovementSpeed;

        public float MovementSpeed => movementMovementSpeed;
    }
}