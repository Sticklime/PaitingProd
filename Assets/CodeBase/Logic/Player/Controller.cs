using UnityEngine;

namespace CodeBase.Logic.Player
{
    public abstract class Controller : MonoBehaviour
    {
        public Vector2 Direction { get; protected set; }
        
        protected Joystick Joystick;

        public void Construct(Joystick joystick) =>
            Joystick = joystick;
    }
}