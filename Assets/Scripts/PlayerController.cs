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

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the rigidbody to player
        //theRB = GetComponent<Rigidbody>();  // Vanha Rigidbody liikkumistapa

        // Initialize the controller to player
        controller = GetComponent<CharacterController>();
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

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            // Jumping when Jump-button is pressed. Jump default button is spacebar.
            moveDirection.y = jumpForce;
        }//if

        // Add gravity to jumps
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
