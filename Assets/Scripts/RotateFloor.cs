using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFloor : MonoBehaviour
{
    // The amount of degrees to rotate the cube per second
    public float rotationSpeed = 45f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the cube around its local y-axis
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
