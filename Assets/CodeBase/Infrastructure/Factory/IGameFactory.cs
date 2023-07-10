using CodeBase.Logic.Player;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory
    {
        public void Load();
        public PlayerLogic CreatePlayer(Vector3 at, PlayerType playerType);
        public GameObject CreateHud();
    }
}