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

        private JoystickContainer _joystickContainer;
        private GameModeType _gameMode;
        private PlayerLogic _bluePlayer;
        private PlayerLogic _redPlayer;
        private GameObject _hud;
        private ScorePoint _scorePoint;

        public InitializeLevel(GameState gameState, MenuSate menuSate, IGameFactory gameFactory,
            SceneLoader sceneLoader, LocalisationServices localisation)
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
            _hud = _gameFactory.CreateHud();

            _joystickContainer = _hud.GetComponentInChildren<JoystickContainer>();
            
            _hud.GetComponentInChildren<ExitMenuButton>().Construct(_menuSate);
            _hud.GetComponentInChildren<TimerUI>().Construct(_gameState);
            _hud.GetComponent<LocalisationHud>().Construct(_localisation.GetLocalisationData(Init.Instance.language));
            _joystickContainer.Construct(_gameMode);
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

            _scorePoint = _hud.GetComponentInChildren<ScorePoint>();

            _bluePlayer.Construct(_scorePoint);
            _redPlayer.Construct(_scorePoint);
            _bluePlayer.GetComponent<Controller>().Construct(_joystickContainer.BlueJoystick);
            _redPlayer.GetComponent<Controller>().Construct(_joystickContainer.RedJoystick);
        }

        public void ShowWinner() =>
            _scorePoint.ShowWinner();
    }
}