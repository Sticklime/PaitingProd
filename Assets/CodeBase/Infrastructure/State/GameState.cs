using System.Collections;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Localisation;
using UnityEngine;

namespace CodeBase.Infrastructure.State
{
    public class GameState
    {
        private const string PaintSceneName = "Paint";

        private readonly LocalisationServices _localisation;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly MenuSate _menuSate;
        private readonly IGameFactory _gameFactory;
        private readonly SceneLoader _sceneLoader;

        private int _countGamesPlayed;

        public int DurationGame => 30;

        public GameState(MenuSate menuSate, IGameFactory gameFactory, SceneLoader sceneLoader,
            LocalisationServices localisation, ICoroutineRunner coroutineRunner)
        {
            _menuSate = menuSate;
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
            _localisation = localisation;
            _coroutineRunner = coroutineRunner;
        }

        public void StartGameTwoPlayer() => 
            _coroutineRunner.StartCoroutine(OnStartGame(GameModeType.TwoPlayer));

        public void StartGamePC() => 
            _coroutineRunner.StartCoroutine(OnStartGame(GameModeType.PcPlayer));

        private IEnumerator OnStartGame(GameModeType gameMode)
        {
            var initLevel = new InitializeLevel(this, _menuSate, _gameFactory, _sceneLoader, _localisation);
            initLevel.LoadLevel(gameMode, PaintSceneName);

            yield return new WaitForSecondsRealtime(DurationGame);
            initLevel.ShowWinner();

            yield return new WaitForSecondsRealtime(2);

            _menuSate.Enter();
            RateGameFunc();
        }

        private void RateGameFunc()
        {
            _countGamesPlayed++;

            if (_countGamesPlayed == 3)
                Init.Instance.RateGameFunc();
        }
    }
}