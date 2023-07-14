using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Localisation;
using CodeBase.Infrastructure.State;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private LocalisationServices _localisation;
        private IGameFactory _gameFactory;
        private SceneLoader _sceneLoader;
        private MenuSate _menuSate;

        public void Awake()
        {
            InitServices();
            DontDestroyOnLoad(gameObject);
        }

        public void Start()
        {
            Init.Instance.ShowBannerAd();
            LoadServices();
            
            _menuSate = new MenuSate(_gameFactory, _sceneLoader, _localisation, this);
            _menuSate.Enter();
        }

        private void InitServices()
        {
            _sceneLoader = new SceneLoader(this);
            _localisation = new LocalisationServices();
            _gameFactory = new GameFactory();
        }

        private void LoadServices()
        {
            _localisation.Load();
            _gameFactory.Load();
        }
    }
}