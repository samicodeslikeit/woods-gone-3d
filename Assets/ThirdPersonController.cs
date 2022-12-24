using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private float movingSpeed;
    [SerializeField] private Animator playerAnimator;

    [SerializeField] private VariableJoystick joystick;

    void FixedUpdate()
    {
        MoveToForward();

        if(joystick.Direction.magnitude > 0.1f)
        {
            RotateWithJoystickPosition();
        }

        playerAnimator.SetFloat("Blend", joystick.Direction.magnitude) ;
    }

    void MoveToForward()
    {
        transform.position += (
                (transform.forward * joystick.Vertical) +
                (transform.right * joystick.Horizontal)
            ).normalized * joystick.Direction.magnitude * movingSpeed * Time.fixedDeltaTime;
    }

    void RotateWithJoystickPosition()
    {
        print(joystick.Direction);
        transform.GetChild(0).localEulerAngles = new Vector3(transform.GetChild(0).localEulerAngles.x,
            GetYRotationFromJoystick(),
            transform.GetChild(0).localEulerAngles.z);
    }

    float GetYRotationFromJoystick()
    {
        float targetAngle = Mathf.Atan2(joystick.Direction.normalized.x, joystick.Direction.normalized.y) * Mathf.Rad2Deg;
        return targetAngle;
        
    }
}
