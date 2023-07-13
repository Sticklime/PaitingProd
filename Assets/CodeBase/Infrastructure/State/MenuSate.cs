using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Localisation;

namespace CodeBase.Infrastructure.State
{
    public class MenuSate
    {
        private readonly LocalisationServices _localisation;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IGameFactory _gameFactory;
        private readonly SceneLoader _sceneLoader;

        private InitializeMainMenu _initializeMenu;
        private GameState _nextState;

        public MenuSate(IGameFactory gameFactory, SceneLoader sceneLoader, LocalisationServices localisation,
            ICoroutineRunner coroutineRunner)
        {
            _localisation = localisation;
            _coroutineRunner = coroutineRunner;
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _nextState = new GameState(this, _gameFactory, _sceneLoader, _localisation, _coroutineRunner);

            InitMainMenu();
        }

        private void InitMainMenu()
        {
            _initializeMenu = new InitializeMainMenu(_localisation, _gameFactory, _sceneLoader);
            _initializeMenu.LoadMenu(_nextState);
        }
    }
}