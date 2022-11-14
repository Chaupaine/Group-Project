using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
    //when object collides with the object with this script, push away the object
    private void OnCollisionStay(Collision other)
    {
        other.collider.GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
    }
}