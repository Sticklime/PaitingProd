using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private KeyCode UpKey = KeyCode.W;
        [SerializeField] private KeyCode DownKey = KeyCode.S;
        [SerializeField] private KeyCode LeftKey = KeyCode.A;
        [SerializeField] private KeyCode RightKey = KeyCode.D;

        private Joystick _joystick;

        public void Construct(Joystick joystick)
        {
            _joystick = joystick;
        }

        public Vector2 PlayerInputPc()
        {
            Vector2 moveDirection = Vector2.zero;

            if (Input.GetKey(UpKey))
                moveDirection += Vector2.up;
            if (Input.GetKey(DownKey))
                moveDirection += Vector2.down;
            if (Input.GetKey(LeftKey))
                moveDirection += Vector2.left;
            if (Input.GetKey(RightKey))
                moveDirection += Vector2.right;

            return moveDirection;
        }

        public Vector2 PlayerInputMobile() => 
            _joystick.Direction;
    }
}