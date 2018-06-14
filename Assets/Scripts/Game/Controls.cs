using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Controls {

    public static float GetHorizontalAxis()
    {
        return CrossPlatformInputManager.GetAxis(Constants.m_HorizontalAxisString);
    }

    public static float GetVerticalAxis()
    {
        return CrossPlatformInputManager.GetAxis(Constants.m_VerticalAxisString);
    }


    public static bool FireButtonPressed()
    {
        if (CrossPlatformInputManager.GetButton(Constants.m_FireButtonString))
        {
            return true;
        }
        return false;
    }
}
