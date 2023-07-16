using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private int _moveSpeed;
        [SerializeField] private Controller PlayerController;

        private void Update()
        {
            OnMove(PlayerController.Direction);
            Rotate(PlayerController.Direction);
        }

        private void OnMove(Vector3 direction)
        {
            float scaleSpeed = _moveSpeed * Time.deltaTime;
            Vector3 targetPosition = transform.position + (direction.normalized * scaleSpeed);

            transform.position = Vector2.Lerp(transform.position, targetPosition, 0.5f);
        }

        private void Rotate(Vector3 direction)
        {
            if (direction == Vector3.zero)
                return;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle + 270, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.5f);
        }
    }
}