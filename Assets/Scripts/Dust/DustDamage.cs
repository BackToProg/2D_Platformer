using Hero;
using Rival;
using UnityEngine;

namespace Dust
{
    public class DustDamage : MonoBehaviour
    {
        private Enemy _enemy;
        private Player _player;
        private PlayerAnimator _playerAnimator;
        private EnemyAnimator _enemyAnimator;

        public void Init(Enemy enemy, Player player, PlayerAnimator playerAnimator, EnemyAnimator enemyAnimator)
        {
            _enemy = enemy;
            _player = player;
            _playerAnimator = playerAnimator;
            _enemyAnimator = enemyAnimator;
        }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Rival.Enemy enemy))
            {
                enemy.TakeDamage(_player.Damage);
                _enemyAnimator.ActivateHitAnimation();
                Destroy(gameObject);
                if (_enemy.IsAlive == false)
                {
                    _enemy.Destroy();
                }
            
            }
        
            if (collision.TryGetComponent(out Hero.Player player))
            {
                player.TakeDamage(_enemy.Damage);
                _playerAnimator.ActivateHitAnimation();
                Destroy(gameObject);
                if (_player.IsAlive == false)
                {
                    _player.Destroy();
                }
            }
        }
    }
}
