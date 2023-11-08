using TMPro;
using UnityEngine;

namespace Enviroment
{
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
}