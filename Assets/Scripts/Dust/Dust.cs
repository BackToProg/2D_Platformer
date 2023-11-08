using Enemy;
using Player;
using UnityEngine;

namespace Dust
{
    [RequireComponent(typeof(DustSpawner))]
    [RequireComponent(typeof(DustMover))]
    [RequireComponent(typeof(DustDamage))]
    public class Dust : MonoBehaviour
    {
        [SerializeField] private float _speed;
    
        private DustMover _mover;
        private DustDamage _damage;
        private bool _objectFlip;
    
        public void DefineMoveDirection(bool objectFlip)
        {
            _objectFlip = objectFlip;
        }

        public void Init(Enemy.Enemy enemy, Player.Player player, PlayerAnimator playerAnimator, EnemyAnimator enemyAnimator)
        {
            _damage.Init(enemy, player, playerAnimator, enemyAnimator);
        }
    
        private void Awake()
        {
            _mover = GetComponent<DustMover>();
            _damage = GetComponent<DustDamage>();
        }

        private void Update()
        {
            _mover.Move(_speed, _objectFlip);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}