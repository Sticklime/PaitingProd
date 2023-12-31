﻿using System.Collections.Generic;
using System.Linq;
using CodeBase.Logic.Player;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private List<PlayerLogic> _playerPrefabs;
        private GameObject _hudPrefab;
        private GameObject _menuPrefab;

        public void Load()
        {
            _playerPrefabs = Resources.LoadAll<PlayerLogic>(PathManager.PlayerPrefabsPath).ToList();
            _hudPrefab = Resources.Load<GameObject>(PathManager.HudPrefabPath);
            _menuPrefab = Resources.Load<GameObject>(PathManager.MenuPrefab);
        }

        public GameObject CreateHud() =>
            Object.Instantiate(_hudPrefab);

        public GameObject CreateMenu() =>
            Object.Instantiate(_menuPrefab);

        public PlayerLogic CreatePlayer(Vector3 at, PlayerType playerType)
        {
            foreach (PlayerLogic playerPrefab in _playerPrefabs)
            {
                if (playerPrefab.PlayerType == playerType)
                    return Object.Instantiate(playerPrefab, at, Quaternion.identity);
            }

            return null;
        }
    }
}