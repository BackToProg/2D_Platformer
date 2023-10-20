using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Dust : MonoBehaviour
{
    private readonly float _speed = 0.5f;
    private int _direction;

    public void GetMoveDirection(bool objectFlip)
    {
        if (objectFlip)
        {
            _direction = 1;
        }
        else
        {
            _direction = -1;
        }
    }
    
    private void Update()
    {
        transform.Translate(new Vector2(transform.position.x * _speed * Time.deltaTime * _direction, 0));
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
