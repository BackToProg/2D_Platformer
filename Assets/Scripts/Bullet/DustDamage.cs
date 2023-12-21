using Hero;
using Rival;
using UnityEngine;

namespace Bullet
{
    public class DustDamage : MonoBehaviour
    {
        private Player _player;
        private Enemy _enemy;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                int enemyTakeDamageValue = _player.Health.DamageValue;
                enemy.Health.TakeDamage(enemyTakeDamageValue);
                Destroy(gameObject);
            }

            if (collision.TryGetComponent(out Player player))
            {
                int playerTakeDamageValue = _enemy.Health.DamageValue;
                player.Health.TakeDamage(playerTakeDamageValue);
                Destroy(gameObject);
            }
        }

        public void Init(Player player, Enemy enemy)
        {
            _player = player;
            _enemy = enemy;
        }
    }
}