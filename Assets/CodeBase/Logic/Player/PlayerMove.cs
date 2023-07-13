using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private int _moveSpeed;
        
        private void Update()
        {
            if (Application.platform == RuntimePlatform.Android)
                Move(_playerController.PlayerInputMobile());
            else if (Application.platform == RuntimePlatform.WindowsEditor) 
                Move(_playerController.PlayerInputPc());
        }

        private void Move(Vector3 direction)
        {
            float scaleSpeed = _moveSpeed * Time.deltaTime;
            Vector3 targetPosition = transform.position + (direction.normalized * scaleSpeed);
            
            transform.position = Vector2.Lerp(transform.position, targetPosition, 0.5f);
        }
        
    }
}