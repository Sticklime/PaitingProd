using System.Collections;
using CodeBase.Infrastructure.Factory;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure
{
    public class Game : MonoBehaviour, ICoroutineRunner
    {
        private const string PaintSceneName = "Paint";
        private const string MenuSceneName = "Menu";

        [SerializeField] private Button _pcFightButton;
        [SerializeField] private Button _twoPlayerButton;
        [SerializeField] private int _durationGame;

        private IGameFactory _gameFactory;
        private SceneLoader _sceneLoader;

        public void Awake()
        {
            // это прототип, поэтму фабрика не создается в Bootstrapper 
            _sceneLoader = new SceneLoader(this);
            _gameFactory = new GameFactory();
            _gameFactory.Load();

            DontDestroyOnLoad(gameObject);
        }

        public void OnEnable()
        {
            _pcFightButton.onClick.AddListener(StartGamePC);
            _twoPlayerButton.onClick.AddListener(StartGameTwoPlayer);
        }

        public void OnDisable()
        {
            _pcFightButton.onClick.RemoveListener(StartGamePC);
            _twoPlayerButton.onClick.RemoveListener(StartGameTwoPlayer);
        }

        private void StartGameTwoPlayer() =>
            StartCoroutine(OnStartGame(GameModeType.TwoPlayer));

        private void StartGamePC() =>
            StartCoroutine(OnStartGame(GameModeType.PcPlayer));

        private IEnumerator OnStartGame(GameModeType gameMode)
        {
            new InitializeLevel(_gameFactory, _sceneLoader, this).LoadLevel(gameMode, PaintSceneName);

            yield return new WaitForSecondsRealtime(_durationGame);

            EndGame();
        }

        public void EndGame() =>
            _sceneLoader.Load(MenuSceneName);
    }
}