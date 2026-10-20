using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControllerX : MonoBehaviour
{
    //controls plane speed while in forward motion & while tilting up/down
    public float speed;
    public float rotationSpeed;

    //read & use input values from keyboard or controller
    public float verticalInput;
    public float horizontalInput;
    public InputAction moveAction;
    private Vector2 moveInput;

    //controller settings
    //accommodate for variable speed with a multiplier of original speed
    private float acceleration = 10f; 
    //read how far outside of "resting" or dead zone the analog stick is pushed
    public float deadzone = 0.1f; 


    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = -Input.GetAxis("Vertical"); //inverted direction so controls aren't opposite of vertical direction

        // keyboard controls
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // tilt the plane up/down based on S/D keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);

        //analog stick controls
        //check if controller is being used
        if (Gamepad.current != null) 
        {
            //if so, assign analog stick = vector object (2D)
            Vector2 stick = Gamepad.current.leftStick.ReadValue();

            //if the joystick moves outside of the resting deadzone (in Y direction), read input and assign to verticalInput variable
            if (Mathf.Abs(stick.y) > deadzone)
            {
                //again, I chose to invert the value 
                verticalInput = -stick.y;
            }

            //check for joystick movement (in X direction)
            if(Mathf.Abs(stick.x) > deadzone)
            {
                horizontalInput = stick.x;
            }
        }

        //move the plane forward at a variable rate based on controller
        speed += horizontalInput * acceleration * Time.deltaTime;
    }
}
