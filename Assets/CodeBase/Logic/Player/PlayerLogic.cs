using CodeBase.Logic.UI;
using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class PlayerLogic : MonoBehaviour
    {
        public PlayerType PlayerType;
        public Color PaintingColor;

        private ScorePoint _scorePoint;

        public void Construct(ScorePoint scorePoint) =>
            _scorePoint = scorePoint;

        public void AddPoint(int countPoint) =>
            _scorePoint.AddPoint(PlayerType, countPoint);

        public void RemovedPoint(PlayerType playerType, int countPoint) =>
            _scorePoint.RemovedPoint(playerType, countPoint);
    }
}