using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    // The object's initial position.
    Vector3 startPosition;

    // The distance the object will move up and down.
    public float distance = 2.0f;

    // The speed at which the object will move.
    public float speed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Save the object's initial position.
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new position based on the object's start position,
        // the distance to move, and a sin wave that oscillates over time.
        float newY = startPosition.y + distance * (Mathf.Sin(Time.time * speed) + 1);

        // Update the object's position.
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
