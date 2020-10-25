using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalAnimationStateController : MonoBehaviour
{

    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    float acceleration = 2f;
    float deceleration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool FowardPressed = Input.GetKey("w");
        bool LeftPressed = Input.GetKey("a");
        bool RightPressed = Input.GetKey("d");
        bool RunPressed = Input.GetKey("left shift");

        if (FowardPressed && velocityZ < 0.5f && !RunPressed)
        {
            velocityZ += Time.deltaTime * acceleration;
        }

        if (RightPressed && velocityX < 0.5f && !RunPressed)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        if (LeftPressed && velocityX > -0.5f && !RunPressed)
        {
            velocityX -= Time.deltaTime * acceleration;
        }

        if (!FowardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }

        if (!FowardPressed && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }

        if (!LeftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }

        if (!RightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }

        if(!LeftPressed && !RightPressed && velocityX!=0.0f && (velocityX > -0.5f && velocityX < 0.5f))
        {
            velocityX = 0.0f;
        }

        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);
    }
}
