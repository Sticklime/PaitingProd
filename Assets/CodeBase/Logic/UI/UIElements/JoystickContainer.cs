using CodeBase.Infrastructure;
using UnityEngine;

namespace CodeBase.Logic.UI.UIElements
{
    public class JoystickContainer : MonoBehaviour
    {
        public Joystick BlueJoystick;
        public Joystick RedJoystick;

        private GameModeType _gameModeType;

        public void Construct(GameModeType gameMode) => 
            _gameModeType = gameMode;

        public void Start()
        {
            if (Init.Instance.mobile == false)
            {
                BlueJoystick.gameObject.SetActive(false);
                RedJoystick.gameObject.SetActive(false);
            }
            else if(Init.Instance.mobile && _gameModeType == GameModeType.PcPlayer) 
                RedJoystick.gameObject.SetActive(false);
        }
    }
}