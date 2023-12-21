using Environment;
using UnityEngine;

namespace Hero
{
    public class PlayerCollectApple : MonoBehaviour
    {
        [SerializeField] private Score _score;
        [SerializeField] private Player _player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Apple apple) && _player.Health.CurrentHealth != _player.Health.MaxHealth)
            {
                int healValue = _player.Health.HealValue;
                _player.Health.Heal(healValue);
                Destroy(apple.gameObject);
                _score.IncreaseScore();
            }
        }
    }
}