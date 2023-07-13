using CodeBase.Infrastructure.State;
using TMPro;
using UnityEngine;

namespace CodeBase.Logic.UI.UIElements
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;

        private GameState _gameState;
        private int _targetTime;
        private int _startTime;

        public void Construct(GameState gameState) =>
            _gameState = gameState;

        private void Start()
        {
            _targetTime = _gameState.DurationGame;
            _startTime = (int)Time.time;
        }

        private void Update()
        {
            int elapsedTime = (int)Time.time - _startTime;

            int remainingTime = _targetTime - elapsedTime;
            
            if (remainingTime < 0)
                remainingTime = 0;

            RefreshTime(remainingTime);
        }

        private void RefreshTime(int time) =>
            _timerText.text = time.ToString();
    }
}