using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraTransform;

    
    public Joystick movementJoystick; 
    public Joystick rotationJoystick; 

    void Update()
    {
        
        float moveHorizontal = movementJoystick.Horizontal;
        float moveVertical = movementJoystick.Vertical;

       
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);

        
        float rotationX = rotationJoystick.Horizontal;
        float rotationY = rotationJoystick.Vertical;

        
        if (rotationX != 0 || rotationY != 0)
        {
            cameraTransform.Rotate(-rotationY * 0.3f, rotationX * 0.3f, 0);
        }
    }
}
