using Enviroment;
using UnityEngine;

namespace Player
{
    public class PlayerCollectApple : MonoBehaviour
    {
        [SerializeField] private ScoreManager _scoreManager;
        [SerializeField] private Player _player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Apple apple) && _player.InitialHealth != _player.Health)
            {
                _player.Heal(apple.HealValue);
                Destroy(apple.gameObject);
                _scoreManager.IncreaseScore();
            }
        }
    }
}