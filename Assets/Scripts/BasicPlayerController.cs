using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour {

	public float speed;
    public GameObject PlayerCamera;
    public bool isGrounded;
    public Vector3 movementVector;
    private Rigidbody rb;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
	void Update()
	{
		float movementHorizontal = Input.GetAxis("Horizontal");
		float movementVertical = Input.GetAxis("Vertical");
		
		movementVector = new Vector3(movementHorizontal, 0.0f, movementVertical);
        movementVector = PlayerCamera.transform.TransformDirection(movementVector);

        if (isGrounded)
        {
		    rb.AddForce(movementVector * speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
	}

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }
}


// public class BasicPlayerController : MonoBehaviour
// {
//     /* 
//     Create a variable called 'rb' that will represent the 
//     rigid body of this object.
//     */
//     private Rigidbody rb;

//     // Create a public variable for the cameraTarget object
//     public GameObject cameraTarget;
//     /* 
//     You will need to set the cameraTarget object in Unity. 
//     The direction this object is facing will be used to determine
//     the direction of forces we will apply to our player.
//     */
//     public float movementIntensity;
//     /* 
//     Creates a public variable that will be used to set 
//     the movement intensity (from within Unity)
//     */

//     // Variables for jump
//     public Vector3 jump;
//     public float jumpForce = 2.0f;
//     public bool isGrounded;

//     void Start()
//     {
//         // make our rb variable equal the rigid body component
//         rb = GetComponent<Rigidbody>();
//     }

//     void Update()
//     {
//         /* 
//     	Establish some directions 
//     	based on the cameraTarget object's orientation 
//     	*/
//         var ForwardDirection = cameraTarget.transform.forward;
//         var RightDirection = cameraTarget.transform.right;

//         if (isGrounded)
//         {
//             // Move Forwards
//             if (Input.GetKey(KeyCode.W))
//             {
//                 rb.AddForce(ForwardDirection * movementIntensity);
//                 /* You may want to try using velocity rather than force.
//                 This allows for a more responsive control of the movement
//                 possibly better suited to first person controls, eg: */
//                 //rb.velocity = ForwardDirection * movementIntensity;
//             }
//             // Move Backwards
//             if (Input.GetKey(KeyCode.S))
//             {
//                 // Adding a negative to the direction reverses it
//                 rb.AddForce(-ForwardDirection * movementIntensity);
//             }
//             // Move Rightwards (eg Strafe. *We are using A & D to swivel)
//             if (Input.GetKey(KeyCode.D))
//             {
//                 rb.AddForce(RightDirection * movementIntensity);
//             }
//             // Move Leftwards
//             if (Input.GetKey(KeyCode.A))
//             {
//                 rb.AddForce(-RightDirection * movementIntensity);
//             }
//             // jump
//             if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 rb.AddForce(jump * jumpForce, ForceMode.Impulse);
//                 isGrounded = false;
//             }
//         }
//     }

//     void OnCollisionStay()
//     {
//         isGrounded = true;
//     }

//     void OnCollisionExit()
//     {
//         isGrounded = false;
//     }
// }