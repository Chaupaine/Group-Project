using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    public GameObject player;
    public GameObject cameraTarget;

    [SerializeField]
    private float mouseSensitivity = 5.0f;

    private float rotationY;
    private float rotationX;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float distanceFromTarget = 20.0f;

    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    [SerializeField]
    private float smoothTime = 0.2f;

    [SerializeField]
    private Vector2 rotationXMinMax = new Vector2(-40, 40);

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX += mouseY;

        // Apply clamping for x rotation 
        rotationX = Mathf.Clamp(rotationX, rotationXMinMax.x, rotationXMinMax.y);

        Vector3 nextRotation = new Vector3(rotationX, rotationY);

        // Apply damping between rotation changes
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;

        // Substract forward vector of the GameObject to point its forward vector to the target
        transform.position = target.position - transform.forward * distanceFromTarget;
        transform.position = player.transform.position;
        if (mouseX > 0) 
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * 100, Space.World);
        }
        if (mouseX < 0) 
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 100, Space.World);
        }
    }
}
// public class CameraController : MonoBehaviour
// {
//     public GameObject player;
//     public GameObject cameraTarget;

//     /* 
//     You will need to set the player object in Unity. 
//     The object that has this script attached to it, ie the 'Camera Target' object
//     will then align itself with whatever object is set as the 'Player'
//     */
//     void Update()
//     {

//         // Align to player position
//         transform.position = player.transform.position;
//         // Rotate Up
//         // if (Input.GetKey(KeyCode.I))
//         // {
//         //     transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * 100, Space.World);
//         // }
//         // // Rotate Down
//         // if (Input.GetKey(KeyCode.K))
//         // {
//         //     transform.Rotate(new Vector3(-1, 0, 0) * Time.deltaTime * 100, Space.World);
//         // }
//         // Rotate left
//         if (Input.GetKey(KeyCode.A))
//         {
//             transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * 100, Space.World);
//         }

//         // Rotate right
//         if (Input.GetKey(KeyCode.D))
//         {
//             transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 100, Space.World);
//         }
//     }
// }