using Hero;
using Rival;
using UnityEngine;

namespace Bullet
{
    public class DustDamage : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                enemy.Health.TakeDamage();
                Destroy(gameObject);
            }

            if (collision.TryGetComponent(out Player player))
            {
                player.Health.TakeDamage();
                Destroy(gameObject);
            }
        }
    }
}