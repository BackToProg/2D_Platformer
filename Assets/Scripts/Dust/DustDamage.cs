using Hero;
using Rival;
using UnityEngine;

namespace Dust
{
    public class DustDamage : MonoBehaviour
    {
        private PlayerAnimator _playerAnimator;
        private EnemyAnimator _enemyAnimator;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                enemy.Health.TakeDamage();
                _enemyAnimator.ActivateHitAnimation();
                Destroy(gameObject);
            }

            if (collision.TryGetComponent(out Player player))
            {
                player.Health.TakeDamage();
                _playerAnimator.ActivateHitAnimation();
                Destroy(gameObject);
            }
        }
        
        public void Init(PlayerAnimator playerAnimator, EnemyAnimator enemyAnimator)
        {
            _playerAnimator = playerAnimator;
            _enemyAnimator = enemyAnimator;
        }
    }
}