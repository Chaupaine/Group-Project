using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeChecker : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity)) 
        { 
            transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.TransformDirection(Vector3.right), hit.normal));
            // transform.position = target.transform.position = target.transform.position + new Vector3(0, 0.2f, 0);
        }
    }
}
