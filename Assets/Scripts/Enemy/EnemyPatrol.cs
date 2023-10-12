using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;
    [SerializeField] private SpriteRenderer _enemySpriteRenderer;
    [SerializeField] private EnemyAnimator _enemyAnimator;

    private Transform[] _movementPoints;
    private int _currentPoint;
    private readonly float _patrolPointDistance = 0.01f;

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
        Transform target = _movementPoints[_currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        float distance = Vector2.Distance(transform.position, target.position);
        _enemyAnimator.ActivateWalkAnimation(true);

        _enemySpriteRenderer.flipX = target.position.x < transform.position.x;

        if (distance < _patrolPointDistance)
        {
            _currentPoint++;

            if (_currentPoint >= _movementPoints.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}