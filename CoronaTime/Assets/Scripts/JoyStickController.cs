using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class JoyStickController : MonoBehaviour
{

    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    float acceleration = 2f;
    float deceleration = 2f;
    float maxWalkVelocity = 0.5f;
    float maxRunVelocity = 2f;

    public Joystick joystick;
    //public Button run;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * bool ForwardPressed = Input.GetKey(KeyCode.W);
        bool LeftPressed = Input.GetKey(KeyCode.A);
        bool RightPressed = Input.GetKey(KeyCode.D);
        bool BackwardPressed = Input.GetKey(KeyCode.S);
        bool RunPressed = Input.GetKey(KeyCode.LeftShift);
        */



        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        //SET VELOCITY

        //float maxWalkVelocity = RunPressed ? maxRunVelocity : maxWalkVelocity;

        //START MOVING

        //VERTICAL START
        velocityZ = vertical * acceleration;

        //HORIZONTAL START
        velocityX = horizontal * acceleration;

        

        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);
    }
}
