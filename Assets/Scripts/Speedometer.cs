using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public TMPro.TextMeshProUGUI speedText; // The TextMesh Pro Text object to display the speed
    public GameObject player; // The player or other object to measure the speed of
    public float maxSpeed = 100; // The maximum speed that the speedometer can measure

    // Start is called before the first frame update
    void Start()
    {
        // Speed displayed as 0 km/h at the start
        float currentSpeed = 0;
        float speedFactor = currentSpeed / maxSpeed;
        speedText.SetText("Speed: " + currentSpeed.ToString("0.00") + " km/h");
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current speed of the player or other object
        float currentSpeed = player.GetComponent<Rigidbody>().velocity.magnitude;

        // Calculate the current speed as a value between 0 and 1
        float speedFactor = currentSpeed / maxSpeed;

        // Update the speed text to show the current speed
        speedText.SetText("Speed: " + currentSpeed.ToString("0.00") + " km/h");
    }
}

