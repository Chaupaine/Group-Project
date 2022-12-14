using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 10;
    public float xSpeed = 25;
    public float ySpeed = 25;
    public float yMinLimit = -40;
    public float yMaxLimit = 80;
    private float x;
    private float y;
    public bool invert;

    public PauseMenu pauseMenu;
    
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        x += Input.GetAxis("Mouse X") * xSpeed;
        y -= Input.GetAxis("Mouse Y") * ySpeed;
        y = ClampAngle(y, yMinLimit, yMaxLimit);
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = rotation * new Vector3(0.0f, 4.0f, -distance) + target.position;
        transform.rotation = rotation;
        transform.position = position;
    }

    static float ClampAngle(float angle, float min, float max) {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
    void Update() 
    {
        //if pausemenu isPaused is true, then set xSpeed and ySpeed to 0, otherwise keep the speeds to what they were
        if (pauseMenu.isPaused == true)
        {
            xSpeed = 0;
            ySpeed = 0;
        }
        else
        {
            xSpeed = 25;
            ySpeed = 25;
        }
    }
}