using CodeBase.Logic.Player;
using TMPro;
using UnityEngine;

namespace CodeBase.Logic.UI
{
    public class ScorePoint : MonoBehaviour
    {
        [SerializeField] private TMP_Text _redPointText;
        [SerializeField] private TMP_Text _bluePointText;

        private int _bluePoints;
        private int _redPoints;

        public void AddPoint(PlayerType playerType, int countPoint)
        {
            switch (playerType)
            {
                case PlayerType.BluePlayer:
                    _bluePoints += countPoint;
                    break;
                case PlayerType.RedPlayer:
                    _redPoints += countPoint;
                    break;
                case PlayerType.RedPcPlayer:
                    _redPoints += countPoint;
                    break;
            }

            RefreshData();
        }

        public void RemovedPoint(PlayerType playerType, int countPoint)
        {
            switch (playerType)
            {
                case PlayerType.BluePlayer:
                    _bluePoints -= countPoint;
                    break;
                case PlayerType.RedPlayer:
                    _redPoints -= countPoint;
                    break;
                case PlayerType.RedPcPlayer:
                    _redPoints -= countPoint;
                    break;
            }

            RefreshData();
        }

        private void RefreshData()
        {
            _bluePointText.text = _bluePoints.ToString();
            _redPointText.text = _redPoints.ToString();
        }
    }
}