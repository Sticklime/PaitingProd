using System.Collections;
using CodeBase.Infrastructure.Factory;
using CodeBase.Logic.UI.UIElements;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Game : MonoBehaviour, ICoroutineRunner
    {
        private const string PaintSceneName = "Paint";
        private const string MenuSceneName = "Menu";

        [SerializeField] private int _durationGame;

        private IGameFactory _gameFactory;
        private SceneLoader _sceneLoader;
        private int _countGamesPlayed;
        private GameObject _menu;

        public void Awake()
        {
            _sceneLoader = new SceneLoader(this);
            _gameFactory = new GameFactory();
            _gameFactory.Load();
            InitMenu();

            DontDestroyOnLoad(gameObject);
        }

        private void InitMenu()
        {
            _menu = _gameFactory.CreateMenuChooseMode(gameObject.transform);

            var gameModeButtons = _menu.GetComponentInChildren<ChoiceGameMode>();
            
            gameModeButtons.PcFightButton.onClick.AddListener(StartGamePC);
            gameModeButtons.TwoPlayerButton.onClick.AddListener(StartGameTwoPlayer);
        }

        private void StartGameTwoPlayer() =>
            StartCoroutine(OnStartGame(GameModeType.TwoPlayer));

        private void StartGamePC() =>
            StartCoroutine(OnStartGame(GameModeType.PcPlayer));

        private IEnumerator OnStartGame(GameModeType gameMode)
        {
            new InitializeLevel(_gameFactory, _sceneLoader, this).LoadLevel(gameMode, PaintSceneName);
            _menu.SetActive(false);

            yield return new WaitForSecondsRealtime(_durationGame);

            EndGame();
        }

        public void EndGame()
        {
            _sceneLoader.Load(MenuSceneName, ReturnMenu);

            RateGameFunc();
        }

        private void ReturnMenu() =>
            _menu.SetActive(true);


        private void RateGameFunc()
        {
            _countGamesPlayed++;

            if (_countGamesPlayed == 3)
                Init.Instance.RateGameFunc();
        }
    }
}