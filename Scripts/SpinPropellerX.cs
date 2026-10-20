using UnityEngine;
using UnityEngine.InputSystem;

public class SpinPropellerX : MonoBehaviour
{
    public float turnSpeed = 50.0f;   
    public float verticalInput;
    public float deadzone = 0.1f; 

    void Update()
    {
        //this section is just for fun; i wanted the propeller to decelerate with the plane, but i can't get it quite right
        if (Gamepad.current != null) 
        {
            //assign analog stick = vector object (2D)
            Vector2 stick = Gamepad.current.leftStick.ReadValue();

            if (Mathf.Abs(stick.x) > deadzone)
            {
                turnSpeed += stick.x * 200f * Time.deltaTime;
                transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
            }
        }
        transform.Rotate(Vector3.forward * turnSpeed);
    }
}
