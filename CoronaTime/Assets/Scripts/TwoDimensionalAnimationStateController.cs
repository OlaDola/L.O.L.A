using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TwoDimensionalAnimationStateController : MonoBehaviour
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

        /*if (vertical < 0.0f && velocityX > -maxWalkVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }

        //RIGHT START
        if (vertical > 0.0f && velocityX < maxWalkVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        //BACKWARD START
        if (horizontal < 0.0f && velocityZ > -0.5f)
        {
            velocityZ -= Time.deltaTime * acceleration;
        }

        //STOP MOVING

        //FORWARD STOP
        if (!ForwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }

        //LEFT STOP
        if (!LeftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }

        //RIGHT STOP
        if (!RightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }

        //BACKWARD STOP
        if (!BackwardPressed && velocityZ < 0.0f)
        {
            velocityZ += Time.deltaTime * deceleration;
        }

        //RESET MOVING

        //FORWARD BACKWARD RESET
        if (!ForwardPressed && !BackwardPressed && velocityZ != 0.0f && (velocityZ > -0.05f && velocityZ < 0.05f))
        {
            velocityZ = 0.0f;
        }

        //STRAFE RESET
        if(!LeftPressed && !RightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }

        //LOCK MOVING

        //RUNNING FORWARD LOCK
        if(ForwardPressed && RunPressed && velocityZ > maxWalkVelocity)
        {
            velocityZ = maxWalkVelocity;
        }
        else if(ForwardPressed && velocityZ > maxWalkVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            if(velocityZ > maxWalkVelocity && velocityZ < (maxWalkVelocity + 0.05f))
            {
                velocityZ = maxWalkVelocity;
            }
        }
        else if(ForwardPressed && velocityZ < maxWalkVelocity && velocityZ > (maxWalkVelocity - 0.05f))
        {
            velocityZ = maxWalkVelocity;
        }

        //RUNNING LEFT LOCK
        if (LeftPressed && RunPressed && velocityX < -maxWalkVelocity)
        {
            velocityX = -maxWalkVelocity;
        }
        else if (LeftPressed && velocityX < -maxWalkVelocity)
        {
            velocityX += Time.deltaTime * deceleration;
            if (velocityX < -maxWalkVelocity && velocityX > (-maxWalkVelocity - 0.05f))
            {
                velocityX = -maxWalkVelocity;
            }
        }
        else if (LeftPressed && velocityX > maxWalkVelocity && velocityX < (-maxWalkVelocity + 0.05f))
        {
            velocityX = maxWalkVelocity;
        }

        //RUNNING RIGHT LOCK
        if (RightPressed && RunPressed && velocityX > maxWalkVelocity)
        {
            velocityZ = maxWalkVelocity;
        }
        else if (RightPressed && velocityX > maxWalkVelocity)
        {
            velocityX -= Time.deltaTime * deceleration;
            if (velocityX > maxWalkVelocity && velocityX < (maxWalkVelocity + 0.05f))
            {
                velocityX = maxWalkVelocity;
            }
        }
        else if (RightPressed && velocityX < maxWalkVelocity && velocityX > (maxWalkVelocity - 0.05f))
        {
            velocityX = maxWalkVelocity;
        }
        */

        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);
    }
}
