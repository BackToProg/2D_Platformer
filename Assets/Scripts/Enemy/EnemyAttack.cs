using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;
    [SerializeField] private Dust _dust;

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
        WaitForSeconds waitForSeconds = new WaitForSeconds(_enemy.AttackSpeed());
        _isAttackCoroutineRunning = true;

        while (IsAttackPossible())
        {
            Dust newDust = Instantiate(_dust, transform.position, transform.rotation);
            newDust.GetMoveDirection(_enemy.GetPlayerSpriteRenderer().flipX);

            yield return waitForSeconds;
        }

        _isAttackCoroutineRunning = false;
    }

    private bool IsAttackPossible() => Vector2.Distance(transform.position, _player.transform.position) <= _enemy.AttackDistance();

}
