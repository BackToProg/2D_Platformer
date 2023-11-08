using UnityEngine;

namespace Enviroment
{
    public class Apple : MonoBehaviour
    {
        [SerializeField] private int _healValue;

        public int HealValue => _healValue;
    }
}
