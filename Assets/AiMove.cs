using System;
using CodeBase.Logic.Player;
using UnityEngine;

public class AiMove : MonoBehaviour
{
    [SerializeField] private AIPlayerLogic _logic;
    [SerializeField] private int _speed;

    public void Update()
    {
        Move(_logic.Direction);
        RotateTowards(_logic.Direction);
    }

    private void Move(Vector3 direction)
    {
        float scaleSpeed = _speed * Time.deltaTime;
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