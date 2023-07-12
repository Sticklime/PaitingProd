using CodeBase.Infrastructure;
using TMPro;
using UnityEngine;

namespace CodeBase.Logic.UI.UIElements
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;

        private Game _game;

        public void Construct(Game game) =>
            _game = game;

        private void Update()
        {
            int currentTime = _game.DurationGame - (int)Time.fixedTime;
            RefreshTime(currentTime);
        }

        private void RefreshTime(int time) =>
            _timerText.text = time.ToString();
    }
}