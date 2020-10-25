using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AnimationStateControler : MonoBehaviour
{

    Animator animator;
    float velocity = 0.0f;
    float acceleration = 0.4f;
    float deceleration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool FowardPressed = Input.GetKey("w");
        bool RunPressed = Input.GetKey("left shift");

        if(FowardPressed && velocity < 1.0f)
        {
            velocity += Time.deltaTime * acceleration;
        }

        if(!FowardPressed && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
        }

        if (!FowardPressed && velocity < 0.0f)
        {
            velocity = 0.0f;
        }
        animator.SetFloat("Velocity", velocity);
    }
}
