using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdController : MonoBehaviour
{
    public CharacterController player;
    public Transform camera;
    public float speed;
    private float movementX;
    private float movementY;
    Vector3 direction;
    public float smooth;
    float turnsmoothvelocity;
    private float Gravity;
    private Animator animator;
    public float jumpspeed;
    Vector3 velocity;
    Vector3 movedirection;
    private float directionY;
    public float gravity = 9.81f;
    private int jumps = 0;
    private bool speedboost = false;
    private bool jumpboost = false;
    private int maxjumps = 1;
    private float speedtimer = 5;
    private float jumptimer = 5;
    public GameObject jumpparticle;
    public TrailRenderer trail2;
    public bool cutscene = false;
    private bool inbutton = false;
    public bool move = false;
    public GameObject test;
    private string buttondirection;
    public float smooth2;
    private float movetimer = 1;
    public bool push = false;
    public Quaternion yes;
    public Transform target2;
    private bool lockon;
    public GameObject thirdperson;
    public GameObject lockoncam;
   

   


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }



    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();



        movementX = movementVector.x;
        movementY = movementVector.y;
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Speed"))
        {
            speedboost = true;
            print("speed");
        }
        else if (other.CompareTag("Jump"))
        {
            jumpboost = true;
            print("jump");
        }

        if(other.CompareTag("Button"))
        {
            inbutton = true;
            buttondirection = other.gameObject.GetComponent<Button>().direction;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button"))
        {
          
            inbutton = false;
        }

    }

  





    // Update is called once per frame
    void Update() 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(movementX, 0f, movementY);
        animator.SetBool("Attack", false);
        animator.SetBool("Attack2", false);
        Vector3 target = test.transform.position;


        if (speedboost)
        {
            speed = 20;
            speedtimer -= Time.deltaTime;
            trail2.emitting = true;
            
            if (speedtimer <= 0)
            {
                speed = 10;
                speedboost = false;
                speedtimer = 5;
                trail2.emitting = false;
            }
        }

        if (jumpboost)
        {
            maxjumps = 2;
            jumpparticle.SetActive(true);
            jumptimer -= Time.deltaTime;
            if (jumptimer <= 0)
            {
                jumpparticle.SetActive(false);
                maxjumps = 1;
                jumptimer = 5;
                jumpboost = false;
            }
                
        }


        if (Input.GetButtonDown("Jump"))
        {
            lockon = !lockon;
        }
            

            

        

        if (lockon)
        {
            thirdperson.SetActive(false);
            lockoncam.SetActive(true);
            Vector3 dir = target2.position - transform.position;
            dir.Normalize();
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir);
        }
        else
        {
            thirdperson.SetActive(true);
            lockoncam.SetActive(false);

        }
        
        






        if (player.isGrounded)
        {
            directionY = 0f;
            jumps = 0;
            animator.SetBool("Grounded", true);
            animator.SetBool("Jumping", false);

        }

        if (direction.magnitude >=0.1f && cutscene == false)
        {
            float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvelocity, smooth);
            if (lockon == false)
            {
                 transform.rotation = Quaternion.Euler(0f, angle, 0f);

            }
            
            animator.SetBool("Moving", true);

            
  

             movedirection = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            velocity = movedirection.normalized * speed * Time.deltaTime;
           
        }
        else
        {
            movedirection = new Vector3(0f, 0f, 0f);
            velocity = movedirection.normalized * speed * Time.deltaTime;
            animator.SetBool("Moving", false);

        }

        if (Input.GetButtonDown("AttackL") && jumps < maxjumps)
        {

            if (jumps == 1)
            {
                jumpspeed = 0.07f;

            }
            if (jumps == 0)
            {
                jumpspeed = 0.05f;
            }

            directionY = jumpspeed;
            jumps += 1;
            animator.SetBool("Jumping", true);
            animator.SetBool("Grounded", false);
        }

       
        if (Input.GetButtonDown("AttackR"))
        {
            if (inbutton == false)
            {
                print("attack");
                animator.SetBool("Attack", true);
                
            }
            if (inbutton)
            {
               
                print("press");
                move = true;
                 yes = transform.rotation;
                animator.SetBool("Attack2", true);
                push = true;





            }
           
     

        }

        if (move == true)
        {

            print("moving");
           
            
            
            if (buttondirection == "North")
            {
                
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 0f, ref turnsmoothvelocity, smooth2);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
            else if (buttondirection == "South")
            {
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 180f, ref turnsmoothvelocity, smooth2);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

            }
            else if (buttondirection == "East")
            {
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 90f, ref turnsmoothvelocity, smooth2);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

            }
            else if (buttondirection == "West")
            {
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 270f, ref turnsmoothvelocity, smooth2);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

            }
           
            


        }

        directionY -= gravity * Time.deltaTime;

        velocity.y = directionY;



        player.Move(velocity);
        
        







    }

}
