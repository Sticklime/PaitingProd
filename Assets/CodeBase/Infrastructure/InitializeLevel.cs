using CodeBase.Infrastructure.Factory;
using CodeBase.Logic.Player;
using CodeBase.Logic.UI;
using CodeBase.Logic.UI.UIElements;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class InitializeLevel
    {
        private readonly IGameFactory _gameFactory;
        private readonly SceneLoader _sceneLoader;
        private readonly Game _game;

        private GameModeType _gameMode;
        private PlayerLogic _bluePlayer;
        private PlayerLogic _redPlayer;
        private ScorePoint _scorePoint;

        public InitializeLevel(IGameFactory gameFactory, SceneLoader sceneLoader, Game game)
        {
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
            _game = game;
        }

        public void LoadLevel(GameModeType gameMode, string sceneName)
        {
            Init.Instance.ShowInterstitialAd();
            _gameMode = gameMode;
            _sceneLoader.Load(sceneName, InitLevel);
        }

        private void InitLevel()
        {
            InitHud();
            InitPlayers();
        }

        private void InitHud()
        {
            GameObject hud = _gameFactory.CreateHud();

            hud.GetComponentInChildren<ExitMenuButton>().Construct(_game);
            _scorePoint = hud.GetComponentInChildren<ScorePoint>();
        }

        private void InitPlayers()
        {
            switch (_gameMode)
            {
                case GameModeType.TwoPlayer:
                    _bluePlayer = _gameFactory.CreatePlayer(new Vector3(-6, -3), PlayerType.BluePlayer);
                    _redPlayer = _gameFactory.CreatePlayer(new Vector3(6, -3), PlayerType.RedPlayer);
                    break;
                case GameModeType.PcPlayer:
                    _bluePlayer = _gameFactory.CreatePlayer(new Vector3(-6, -3), PlayerType.BluePlayer);
                    _redPlayer = _gameFactory.CreatePlayer(new Vector3(6, -3), PlayerType.RedPcPlayer);
                    break;
            }

            _bluePlayer.Construct(_scorePoint);
            _redPlayer.Construct(_scorePoint);
        }
    }
}