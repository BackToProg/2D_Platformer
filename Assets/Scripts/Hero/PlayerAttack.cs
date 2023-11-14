using Dust;
using Rival;
using UnityEngine;

namespace Hero
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private DustSpawner _dustSpawner;
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Dust.Dust newDust = _dustSpawner.Spawn(_player.transform, _player.SpriteRenderer.flipX);
                newDust.Init(_enemy, _player, _playerAnimator, _enemyAnimator);
                newDust.DefineMoveDirection(_player.SpriteRenderer.flipX);
            }
        }
    }
}