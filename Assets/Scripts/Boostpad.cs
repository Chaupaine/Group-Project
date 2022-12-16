using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boostpad : MonoBehaviour
{
    public AudioClip boostSound;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(boostSound, transform.position);
            other.gameObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 1000);
        }
    }
}