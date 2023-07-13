using CodeBase.Infrastructure.State;
using UnityEngine;

namespace CodeBase.Logic.UI.UIElements
{
    public class ExitMenuButton : MonoBehaviour
    {
        private MenuSate _menuSate;

        public void Construct(MenuSate menuSate) => 
            _menuSate = menuSate;

        public void ExitMenu() => 
            _menuSate.Enter();
    }
}
