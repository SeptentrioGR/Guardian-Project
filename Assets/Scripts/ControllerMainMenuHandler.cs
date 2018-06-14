using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class ControllerMainMenuHandler : MonoBehaviour
{
    public GameObject[] Buttons;
    public int currentButton;
    public bool Selected;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var selectedObj = EventSystem.current.currentSelectedGameObject;

        float vert = CrossPlatformInputManager.GetAxis("Vertical");
        float horiz = CrossPlatformInputManager.GetAxis("Horizontal");

        if (vert > 0 && !Selected)
        {
            Selected = true;
            currentButton++;
            if (currentButton > Buttons.Length-1)
            {
                currentButton = 0;
            }

        }

        if (vert < 0 && !Selected)
        {
            Selected = true;
            currentButton--;
            if (currentButton < 0)
            {
                currentButton = Buttons.Length-1;
            }
        }

        if (vert == 0)
        {
            Selected = false;
        }

        if (Selected)
        {
            EventSystem.current.SetSelectedGameObject(Buttons[currentButton]);
        }
    }
}
