using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private int _attackSpeed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public int Health() => _health;

    public int Damage() => _damage;

    public float AttackDistance() => _attackDistance;

    public int AttackSpeed() => _attackSpeed;

    public SpriteRenderer GetPlayerSpriteRenderer() => _spriteRenderer;
    
}
