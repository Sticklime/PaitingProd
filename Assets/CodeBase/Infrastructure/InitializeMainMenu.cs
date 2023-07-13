using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Localisation;
using CodeBase.Infrastructure.State;
using CodeBase.Logic.UI;
using CodeBase.Logic.UI.UIElements;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class InitializeMainMenu
    {
        private const string MenuSceneName = "Menu";

        private readonly IGameFactory _gameFactory;
        private readonly LocalisationServices _localisation;
        private readonly SceneLoader _sceneLoader;
        
        private GameState _gameState;
        private GameObject _menu;

        public InitializeMainMenu(LocalisationServices localisation, IGameFactory gameFactory, SceneLoader sceneLoader)
        {
            _localisation = localisation;
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
        }

        public void LoadMenu(GameState gameState)
        {
            _gameState = gameState;
            _sceneLoader.Load(MenuSceneName, InitMenu);
        }

        private void InitMenu()
        {
             _menu = _gameFactory.CreateMenu();
     
            LocalisationMainMenu localisationUI = _menu.GetComponent<LocalisationMainMenu>();
            ChoiceGameMode choiceGameMode = _menu.GetComponentInChildren<ChoiceGameMode>();
            
            localisationUI.Construct(_localisation.GetLocalisationData(Init.Instance.language));
            
            choiceGameMode.TwoPlayerButton.onClick.AddListener(_gameState.StartGameTwoPlayer);
            choiceGameMode.PcFightButton.onClick.AddListener(_gameState.StartGamePC);
        }
    }
}