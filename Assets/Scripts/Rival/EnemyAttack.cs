using System.Collections;
using Dust;
using Hero;
using UnityEngine;

namespace Rival
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private DustSpawner _dustSpawner;

        private bool _isAttackCoroutineRunning;
   
        private void Update()
        {
            if (IsAttackPossible() && _isAttackCoroutineRunning == false)
            {
                StartCoroutine(Shoot());
            }
            else
            {
                StopCoroutine(Shoot());
            }
        }

        private IEnumerator Shoot()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(_enemy.AttackSpeed);
            _isAttackCoroutineRunning = true;

            while (IsAttackPossible())
            {
                Dust.Dust newDust = _dustSpawner.Spawn(_enemy.transform, _enemy.SpriteRenderer.flipX);
                newDust.Init(_enemy, _player, _playerAnimator, _enemyAnimator);
                newDust.DefineMoveDirection(_enemy.SpriteRenderer.flipX);

                yield return waitForSeconds;
            }
        
            _isAttackCoroutineRunning = false;
        }

        private bool IsAttackPossible() =>
            Vector2.Distance(transform.position, _player.transform.position) <= _enemy.AttackDistance;

    }
}
