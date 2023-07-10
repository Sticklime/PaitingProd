using CodeBase.Infrastructure;
using UnityEngine;

namespace CodeBase.Logic.UI.UIElements
{
    public class ExitMenuButton : MonoBehaviour
    {
        private Game _game;

        public void Construct(Game game) => 
            _game = game;

        public void ExitMenu() => 
            _game.EndGame();

        public void ExitMainMenu() { }
    }
}
