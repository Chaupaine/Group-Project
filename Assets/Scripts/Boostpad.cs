using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boostpad : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        other.collider.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 1000);
    }
}