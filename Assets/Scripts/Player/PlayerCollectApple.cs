using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerCollectApple : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Apple apple))
        {
            Destroy(apple.gameObject);
            _scoreManager.IncreaseScore();
        }
    }
}