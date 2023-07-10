using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class PlayerController : MonoBehaviour
    {
        public KeyCode UpKey = KeyCode.W;
        public KeyCode DownKey = KeyCode.S;
        public KeyCode LeftKey = KeyCode.A;
        public KeyCode RightKey = KeyCode.D;

        public Vector2 PlayerInput()
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
    }
}