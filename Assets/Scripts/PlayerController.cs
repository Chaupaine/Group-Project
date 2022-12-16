using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
    public bool isGrounded;
    public Vector3 movementVector;
    private Rigidbody rb;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public ParticleSystem dirtParticles;
    public ParticleSystem explosionParticles;
    public AudioClip jumpSound;
    public float decelerationSpeed = 25.0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
	void Update()
	{
        if (isGrounded)
        {
            //only if you dont want to be able to control the ball while in midair
		    // rb.AddForce(movementVector * speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //play jump sound
                AudioSource.PlayClipAtPoint(jumpSound, transform.position);
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
	}

    // FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
		float movementVertical = Input.GetAxis("Vertical");
		
		movementVector = new Vector3(movementHorizontal, 0.0f, movementVertical);
        movementVector = Camera.main.transform.TransformDirection(movementVector);

        // only if you dont want to be able to control the ball while in midair (still testing out)
        rb.AddForce(new Vector3(movementVector.x, 0.0f, movementVector.z) * speed);
        // rb.AddForce(movementVector * speed * Time.deltaTime);
        // if isGrounded is false and is pushing on vertical movement, then set speed to 0, otherwise keep the speed to what it was
        if (isGrounded == false && movementVertical != 0)
        {
            speed = speed/2;
        }
        else
        {
            speed = 2;
        }

        // Check if the "decelerate" button is pressed
        if (Input.GetKey(KeyCode.M) && isGrounded)
        {
            // Calculate the deceleration force as a vector in the opposite direction of the player's current velocity
            Vector3 decelerationForce = -rb.velocity.normalized * decelerationSpeed;

            // Apply the deceleration force to the player's Rigidbody
            rb.AddForce(decelerationForce);
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