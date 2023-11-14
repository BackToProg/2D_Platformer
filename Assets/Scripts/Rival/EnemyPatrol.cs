using System;
using UnityEngine;

namespace Rival
{
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private Transform _path;
        [SerializeField] private SpriteRenderer _enemySpriteRenderer;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Hero.Player _player;
        
        private readonly float _patrolPointDistance = 0.01f;
        private readonly float _chaseDistanceY = 0.8f;
        private Transform[] _movementPoints;
        private int _currentPoint;

        private void Start()
        {
            _movementPoints = new Transform[_path.childCount];

            for (int i = 0; i < _path.childCount; i++)
            {
                _movementPoints[i] = _path.GetChild(i).transform;
            }
        }

        private void Update()
        {
            if (IsChasePossible())
            {
                Chase();
            }
            else
            {
                Patrol();
            }
        }

        private void Patrol()
        {
            Transform target = _movementPoints[_currentPoint];

            transform.position = Vector2.MoveTowards(transform.position, target.position, _enemy.MovementSpeed * Time.deltaTime);
            float distance = Vector2.Distance(transform.position, target.position);
            _enemyAnimator.ActivateWalkAnimation(true);

            _enemySpriteRenderer.flipX = IsFlipX(target);

            if (distance < _patrolPointDistance)
            {
                _currentPoint++;

                if (_currentPoint >= _movementPoints.Length)
                {
                    _currentPoint = 0;
                }
            }
        }

        private void Chase()
        {
            _enemySpriteRenderer.flipX = IsFlipX(_player.transform);
            transform.position =
                Vector2.MoveTowards(transform.position, _player.transform.position, _enemy.ChaseSpeed * Time.deltaTime);
        }

        private bool IsChasePossible()
        {
            bool isPossible = false;
            float distanceX = Vector2.Distance(transform.position, _player.transform.position);
            float distanceY = Math.Abs(transform.position.y - _player.transform.position.y);
        
            if (distanceX <= _enemy.ChaseDistance && distanceY <= _chaseDistanceY)
            {
                isPossible = true;
            }

            return isPossible;
        }

        private bool IsFlipX(Transform target) => target.position.x < transform.position.x;
    }
}