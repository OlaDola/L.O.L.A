using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class TwoDimensionalAnimationStateController : MonoBehaviour
{

    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    float acceleration = 2f;
    float deceleration = 2f;
    float maxWalkVelocity = 0.5f;
    float maxRunVelocity = 2f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool ForwardPressed = Input.GetKey(KeyCode.W);
        bool LeftPressed = Input.GetKey(KeyCode.A);
        bool RightPressed = Input.GetKey(KeyCode.D);
        bool BackwardPressed = Input.GetKey(KeyCode.S);
        bool RunPressed = Input.GetKey(KeyCode.LeftShift);

        //SET VELOCITY

        float currentMaxVelocity = RunPressed ? maxRunVelocity : maxWalkVelocity;

        //START MOVING

        //FORWARD START
        if (ForwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }

        //LEFT START
        if (LeftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }

        //RIGHT START
        if (RightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        //BACKWARD START
        if (BackwardPressed && velocityZ > -0.5f)
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
        if(ForwardPressed && RunPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        else if(ForwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            if(velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        else if(ForwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }

        //RUNNING LEFT LOCK
        if (LeftPressed && RunPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }
        else if (LeftPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * deceleration;
            if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f))
            {
                velocityX = -currentMaxVelocity;
            }
        }
        else if (LeftPressed && velocityX > currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f))
        {
            velocityX = currentMaxVelocity;
        }

        //RUNNING RIGHT LOCK
        if (RightPressed && RunPressed && velocityX > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        else if (RightPressed && velocityX > currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * deceleration;
            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05f))
            {
                velocityX = currentMaxVelocity;
            }
        }
        else if (RightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f))
        {
            velocityX = currentMaxVelocity;
        }

        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);
    }
}
