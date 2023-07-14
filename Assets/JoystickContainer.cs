using UnityEngine;

public class JoystickContainer : MonoBehaviour
{
    public Joystick BlueJoystick;
    public Joystick RedJoystick;

    public void Awake()
    {
        if (Init.Instance.mobile == false)
        {
            BlueJoystick.gameObject.SetActive(false);
            RedJoystick.gameObject.SetActive(false);
        }
    }
}