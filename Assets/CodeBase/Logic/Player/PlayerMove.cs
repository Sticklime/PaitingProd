using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private int _moveSpeed;

        private void Update()
        {
            Vector2 direction;

            if (Init.Instance.mobile)
                direction = _playerController.PlayerInputMobile();
            else
                direction = _playerController.PlayerInputPc();

            Move(direction);
            RotateTowards(direction);
        }

        private void Move(Vector3 direction)
        {
            float scaleSpeed = _moveSpeed * Time.deltaTime;
            Vector3 targetPosition = transform.position + (direction.normalized * scaleSpeed);

            transform.position = Vector2.Lerp(transform.position, targetPosition, 0.5f);
        }

        private void RotateTowards(Vector3 direction)
        {
            if (direction == Vector3.zero)
                return;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle + 270, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.5f);
        }
    }
}