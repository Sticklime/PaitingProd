using CodeBase.Logic.Player;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Logic.Tile
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class TileLogic : MonoBehaviour
    {
        [SerializeField] private int _countPoint;
        [SerializeField] private Image _icons;

        private PlayerType _playerFlag;

        public void OnTriggerEnter2D(Collider2D trigger)
        {
            if (trigger.TryGetComponent(out PlayerLogic player))
            {
                if (_playerFlag == player.PlayerType)
                    return;

                if (_playerFlag != player.PlayerType)
                    player.RemovedPoint(_playerFlag, _countPoint);

                _playerFlag = player.PlayerType;
                _icons.color = player.PaintingColor;
                player.AddPoint(_countPoint);
            }
        }
    }
}