using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
    public AudioClip jumpSound;

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
        }
    }
}