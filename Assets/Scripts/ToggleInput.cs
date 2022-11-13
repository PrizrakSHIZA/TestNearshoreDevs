using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInput : MonoBehaviour
{
    public GameObject joystick;
    public GameObject buttons;

    bool useJoystick = true;

    public void Toggle()
    { 
        useJoystick = !useJoystick;
        if (useJoystick)
        {
            joystick.SetActive(true);
            buttons.SetActive(false);
        }
        else
        {
            joystick.SetActive(false);
            buttons.SetActive(true);
        }
    }
}
