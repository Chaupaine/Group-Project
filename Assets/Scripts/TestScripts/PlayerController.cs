using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public float moveSpeed;
//     public float jumpForce;
//     public float drag;
//     public bool isGrounded;

//     // Update is called once per frame
//     void Update()
//     {
//         Vector3 direction = new Vector3(0,0,0);

//         Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
//         forward.y = 0;

//         Vector3 forwardForce = forward * Input.GetAxis("Vertical") * drag;

//         Vector3 right = Camera.main.transform.TransformDirection(Vector3.right);

//         Vector3 rightForce = right * Input.GetAxis("Horizontal") * drag;
//         if (isGrounded) 
//         {
//             direction += forwardForce;
//             direction += rightForce;            
//             if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
//                 isGrounded = false;
//             }
//         }
//         GetComponent<Rigidbody>().AddForce(direction.normalized * moveSpeed * drag);
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

public class PlayerController : MonoBehaviour {

	public float speed;
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
        movementVector = Camera.main.transform.TransformDirection(movementVector);

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