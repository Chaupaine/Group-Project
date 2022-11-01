using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = 0.5f;
    void Update()
    {

        turn.x = Input.GetAxis("Mouse X") * sensitivity;
        turn.y = Input.GetAxis("Mouse Y") * sensitivity;

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
