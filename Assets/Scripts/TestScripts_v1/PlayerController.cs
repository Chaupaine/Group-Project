using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 1000f;
    public bool isGrounded;
    public Vector3 movementVector;
    private Rigidbody rb;
    public Vector3 jump = new Vector3(0,4,0);
    public float jumpForce = 2.0f;
    public AudioClip jumpSound;
    // public ParticleSystem dirtParticles;
    // public ParticleSystem explosionParticles;
    
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

        // only if you dont want to be able to control the ball while in midair (still testing out)
        // rb.AddForce(movementVector * speed * Time.deltaTime);

        if (isGrounded)
        {
            //only if you dont want to be able to control the ball while in midair
		    rb.AddForce(movementVector * speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //play jump sound
                AudioSource.PlayClipAtPoint(jumpSound, transform.position);
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