using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NoSuchCompany.Games.SuperMario.Behaviors
{
    public class TimeBehavior : MonoBehaviour
    {
        private TextMeshProUGUI _time;
        private readonly Stopwatch _stopwatch;
        private const int AvailableTime = 360;
        private bool _gameEnded = false;

        public TimeBehavior()
        {
            _stopwatch = Stopwatch.StartNew();
        }
    
        public void Start()
        {
            _time = GetComponent<TextMeshProUGUI>();
        }

        public void Update()
        {
            int remainingTime = AvailableTime - (int)_stopwatch.Elapsed.TotalSeconds;
            if (remainingTime <= 0 && !_gameEnded)
            {
                _gameEnded = true;
                EndGame();
                return;
            }

            _time.text = $"{Mathf.Max(remainingTime, 0):00#}";
        }

        private void EndGame()
        {
            // ¾À ÀüÈ¯
            SceneManager.LoadScene("TimeOver");
        }
    }
}
