using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{

    private Vector3 PlayerKeyInput;
    private Vector2 MouseMovement;
    [SerializeField] private Transform Camera2;
    [SerializeField]  private Rigidbody Player;
    [SerializeField]  private float speed;
    [SerializeField]  private float sensitivity;
    [SerializeField]  private float Jump;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        PlayerKeyInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        RigidMove();
        MoveCamera();
    }


    private void RigidMove()
    {
        Vector3 movevector = transform.TransformDirection(PlayerKeyInput) * speed;
        Player.velocity = new Vector3(movevector.x, Player.velocity.y, movevector.z);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Player.AddForce(Vector3.up * Jump, ForceMode.Impulse);
        }
    }

    private void MoveCamera()
    {

    }
}
