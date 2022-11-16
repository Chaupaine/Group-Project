using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
    private void OnCollisionStay(Collision other)
    {
        other.collider.GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
    }
}