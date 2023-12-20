using TMPro;
using UnityEngine;

namespace Environment
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private int _score;
        
        private void Update()
        {
            _scoreText.text = $"X{_score}";
        }

        public void IncreaseScore()
        {
            _score ++;
        }
    }
}