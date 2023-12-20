using System.Collections;
using Bullet;
using Hero;
using UnityEngine;

namespace Rival
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Player _player;
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
                Vector3 localScale = _player.transform.localScale;
                
                Dust newDust = _dustSpawner.Spawn(_enemy.transform, localScale.x);
                newDust.DefineMoveDirection(localScale.x);

                yield return waitForSeconds;
            }
        
            _isAttackCoroutineRunning = false;
        }

        private bool IsAttackPossible() =>
            Vector2.Distance(transform.position, _player.transform.position) <= _enemy.AttackDistance;
    }
}
