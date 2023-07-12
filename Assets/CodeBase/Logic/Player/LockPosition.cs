using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class LockPosition : MonoBehaviour
    {
        [SerializeField] private float minYPosition = -4f;
        [SerializeField] private float maxYPosition = 4f;
        [SerializeField] private float minXPosition = -8f;
        [SerializeField] private float maxXPosition = 8f;

        private void Update() => 
            LockPositionXY();

        private void LockPositionXY()
        {
            float clampedY = Mathf.Clamp(transform.position.y, minYPosition, maxYPosition);
            float clampedX = Mathf.Clamp(transform.position.x, minXPosition, maxXPosition);

            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
