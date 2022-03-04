using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMovement : MonoBehaviour
{
    public Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
     

    }


    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        ///rb.AddForce(movement * speed);
        if (movementY > 0)
        {
            Vector3 Rotate = new Vector3(0, movementX * 90, 0 );
            transform.eulerAngles = Rotate;
            print("up");
        }
        else if (movementY < 0)
        {
            Vector3 Rotate = new Vector3(0, movementX * - 90, 0);
            transform.eulerAngles = Rotate;
            print("down");
        }
        

    }
    
}
