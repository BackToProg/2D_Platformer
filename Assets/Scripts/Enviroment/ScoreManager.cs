using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    private int _score;

    public void IncreaseScore()
    {
        _score += 1;
    }

    private void Update()
    {
        _scoreText.text = $"X{_score}";
    }
}
