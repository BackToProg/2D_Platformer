using System.Collections;
using Rival;
using UnityEngine;

namespace Hero
{
    public class PlayerVampireAbility : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _circleCollider;
        [SerializeField] private int _abilityRadius;
        [SerializeField] private int _abilityValue = 7;
        [SerializeField] private int _abilityDuration = 6;
        [SerializeField] private Player _player;

        private Coroutine _coroutine;
        private bool _isCoroutineRun;
        private Enemy _enemy;

        private void Start()
        {
            _circleCollider.radius = _abilityRadius;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Q) && _enemy != null && _isCoroutineRun == false)
            {
                _coroutine = StartCoroutine(StartAbility(_enemy));
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                _enemy = enemy;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy) && _isCoroutineRun)
            {
                StopCoroutine(_coroutine);
                _isCoroutineRun = false;
                _enemy = null;
            }
        }

        private IEnumerator StartAbility(Enemy enemy)
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(1);
            int count = 0;
            _isCoroutineRun = true;

            while (count <= _abilityDuration)
            {
                enemy.Health.TakeDamage(_abilityValue);
                _player.Health.Heal(_abilityValue);
                count++;

                yield return waitForSeconds;
            }
        }
    }
}