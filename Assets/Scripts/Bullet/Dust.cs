using UnityEngine;

namespace Bullet
{
    [RequireComponent(typeof(DustMover))]
    [RequireComponent(typeof(DustDamage))]
    public class Dust : MonoBehaviour
    {
        [SerializeField] private float _speed;
    
        private DustMover _mover;
        private float _scale;
        
        private void Awake()
        {
            _mover = GetComponent<DustMover>();
        }

        private void Update()
        {
            _mover.Move(_speed, _scale);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        public void DefineMoveDirection(float scale)
        {
            _scale = scale;
        }
    }
}