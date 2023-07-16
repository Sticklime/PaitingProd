using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class PlayerController : Controller
    {
        [SerializeField] private KeyCode UpKey = KeyCode.W;
        [SerializeField] private KeyCode DownKey = KeyCode.S;
        [SerializeField] private KeyCode LeftKey = KeyCode.A;
        [SerializeField] private KeyCode RightKey = KeyCode.D;

        private void Update()
        {
            if (Init.Instance.mobile)
                PlayerInputMobile();
            else
                PlayerInputPc();
        }

        private void PlayerInputPc()
        {
            Direction = Vector2.zero;

            if (Input.GetKey(UpKey))
                Direction += Vector2.up;
            if (Input.GetKey(DownKey))
                Direction += Vector2.down;
            if (Input.GetKey(LeftKey))
                Direction += Vector2.left;
            if (Input.GetKey(RightKey))
                Direction += Vector2.right;
        }

        private void PlayerInputMobile() =>
            Direction = Joystick.Direction;
    }
}