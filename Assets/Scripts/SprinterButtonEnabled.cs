using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class SprinterButtonEnabled : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public SprintButton sprintButton;
    public bool isJoystickPressing;
    public bool shouldContinueToSprint;

    public void OnPointerDown(PointerEventData eventData)
    {
        isJoystickPressing = true;
        shouldContinueToSprint = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (sprintButton.isSprinting)
        {
            shouldContinueToSprint = true;
        }
        isJoystickPressing = false;
    }

    private void Update()
    {
        function();
    }

    void function()
    {
        if (shouldContinueToSprint)
        {
            Sprint();
            return;
        }
        
        if (isJoystickPressing && sprintButton.isSprinting)
        {
            Sprint();
        }
        else if(isJoystickPressing)
        {
            Walk();
        }
        else
        {
            Idle();
        }
    }

    void Sprint()
    {
        //sprinting code
        print("sprinting");
    }

    void Walk()
    {
        //walking code
        print("walking");
    }

    void Idle()
    {
        //idling code
        print("idling");
    }

    
}
