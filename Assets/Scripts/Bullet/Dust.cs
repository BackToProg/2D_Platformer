using Hero;
using Rival;
using UnityEngine;

namespace Bullet
{
    [RequireComponent(typeof(DustMover))]
    [RequireComponent(typeof(DustDamage))]
    public class Dust : MonoBehaviour
    {
        [SerializeField] private float _speed;
    
        private DustMover _mover;
        private DustDamage _damage;
        private float _scale;
        
        private void Awake()
        {
            _mover = GetComponent<DustMover>();
            _damage = GetComponent<DustDamage>();
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

        public void Init(Player player, Enemy enemy)
        {
            _damage.Init(player, enemy);
        }
    }
}