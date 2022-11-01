using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

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
// public class PlayerController : MonoBehaviour {

// 	public float speed;
//     public GameObject PlayerCamera;

// 	void FixedUpdate()
// 	{
// 		float movementHorizontal = Input.GetAxis("Horizontal");
// 		float movementVertical = Input.GetAxis("Vertical");
		
// 		Vector3 movementVector = new Vector3(movementHorizontal, 0.0f, movementVertical);
//             movementVector = PlayerCamera.transform.TransformDirection(movementVector);

// 		GetComponent<Rigidbody>().AddForce(movementVector * speed * Time.deltaTime);
// 	}
// }