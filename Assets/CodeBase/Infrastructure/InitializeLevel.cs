using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Localisation;
using CodeBase.Infrastructure.State;
using CodeBase.Logic.Player;
using CodeBase.Logic.UI;
using CodeBase.Logic.UI.UIElements;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class InitializeLevel
    {
        private readonly LocalisationServices _localisation;
        private readonly IGameFactory _gameFactory;
        private readonly SceneLoader _sceneLoader;
        private readonly GameState _gameState;
        private readonly MenuSate _menuSate;

        private GameModeType _gameMode;
        private PlayerLogic _bluePlayer;
        private PlayerLogic _redPlayer;
        private ScorePoint _scorePoint;

        public InitializeLevel(GameState gameState, MenuSate menuSate, IGameFactory gameFactory, SceneLoader sceneLoader,
            LocalisationServices localisation)
        {
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
            _gameState = gameState;
            _menuSate = menuSate;
            _localisation = localisation;
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

            _scorePoint = hud.GetComponentInChildren<ScorePoint>();

            hud.GetComponentInChildren<ExitMenuButton>().Construct(_menuSate);
            hud.GetComponentInChildren<TimerUI>().Construct(_gameState);
            hud.GetComponent<LocalisationHud>().Construct(_localisation.GetLocalisationData(Init.Instance.language));
        }

        private void InitPlayers()
        {
            switch (_gameMode)
            {
                case GameModeType.TwoPlayer:
                    _bluePlayer = _gameFactory.CreatePlayer(new Vector3(-6, -3), PlayerType.BluePlayer);
                    _redPlayer = _gameFactory.CreatePlayer(new Vector3(6.27f, -3), PlayerType.RedPlayer);
                    break;
                case GameModeType.PcPlayer:
                    _bluePlayer = _gameFactory.CreatePlayer(new Vector3(-6, -3), PlayerType.BluePlayer);
                    _redPlayer = _gameFactory.CreatePlayer(new Vector3(6.27f, -3), PlayerType.RedPcPlayer);
                    break;
            }

            _bluePlayer.Construct(_scorePoint);
            _redPlayer.Construct(_scorePoint);
        }

        public void ShowWinner() =>
            _scorePoint.ShowWinner();
    }
}