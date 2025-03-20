using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
   // public Rigidbody theRB;   // Vanha Rigidbody liikkumistapa
    public float jumpForce;
    public CharacterController controller;
    public float gravityScale;

    private Vector3 moveDirection;

    //Animations for playercharacter (AC_Player)
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the rigidbody to player
        //theRB = GetComponent<Rigidbody>();  // Vanha Rigidbody liikkumistapa

        // Initialize the controller to player
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        /*      // Vanha Rigidbody liikkumistapa
        // Basic player controls WASD
        // Z and X -axis take whatever input you press. Y-axis is set up to stay as it is.
        theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            // Jumping when Jump-button is pressed. Jump default button is spacebar.
            theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
        }//if
        */

        // Old movedirection
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        //Store the current y-direction
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;
        animator.SetBool("IsWalking", true);


        if (controller.isGrounded)
        {
            // Player is on the ground
            animator.SetBool("IsJumping", false);

            if (moveDirection.x != 0 || moveDirection.z != 0)
            {
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsIdle", false);
            }
            else
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsIdle", true);
            }

            if (Input.GetButtonDown("Jump"))
            {
                // Jump logic
                moveDirection.y = jumpForce;
                animator.SetBool("IsJumping", true);
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsIdle", false);
            }
        }
        else
        {
            // Player is in the air
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsIdle", false);
        }

        // Add gravity to jumps
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);


    }


}
