using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MonoBehaviour
{
    //when player collides with platform, reduce friction and increase speed for a short time
    string playerTag = "Player";
    float friction = 0.5f;
    float speed = 10.0f;
    float time = 3.0f;
    float resetTime = 5.0f;
    bool canReset = true;
    public AudioClip touchSound;

    void Start()
    {
        //set friction and speed
        GetComponent<Collider>().material.dynamicFriction = friction;
        GetComponent<Collider>().material.staticFriction = friction;
        GetComponent<Collider>().material.frictionCombine = PhysicMaterialCombine.Minimum;
        GetComponent<Collider>().material.bounciness = 0.0f;
        GetComponent<Collider>().material.bounceCombine = PhysicMaterialCombine.Minimum;
        GetComponent<Rigidbody>().drag = 0.0f;
        GetComponent<Rigidbody>().angularDrag = 0.0f;
        GetComponent<Rigidbody>().mass = 1.0f;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            AudioSource.PlayClipAtPoint(touchSound, transform.position);
            StartCoroutine(Ice());
        }
    }

    IEnumerator Ice()
    {
        //reduce friction and increase speed
        GetComponent<Collider>().material.dynamicFriction = 0.0f;
        GetComponent<Collider>().material.staticFriction = 0.0f;
        GetComponent<Rigidbody>().drag = 0.0f;
        GetComponent<Rigidbody>().angularDrag = 0.0f;
        GetComponent<Rigidbody>().mass = 1.0f;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * speed;
        yield return new WaitForSeconds(time);
        //reset friction and speed
        GetComponent<Collider>().material.dynamicFriction = friction;
        GetComponent<Collider>().material.staticFriction = friction;
        GetComponent<Rigidbody>().drag = 0.0f;
        GetComponent<Rigidbody>().angularDrag = 0.0f;
        GetComponent<Rigidbody>().mass = 1.0f;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity / speed;
        if (canReset)
        {
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(resetTime);
        //reset friction and speed
        GetComponent<Collider>().material.dynamicFriction = friction;
        GetComponent<Collider>().material.staticFriction = friction;
        GetComponent<Rigidbody>().drag = 0.0f;
        GetComponent<Rigidbody>().angularDrag = 0.0f;
        GetComponent<Rigidbody>().mass = 1.0f;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity / speed;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            canReset = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            canReset = true;
        }
    }
}