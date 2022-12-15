using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour 
{ 
    public float threshold = -50f;
 
	void Update()  
	{ 
        if (transform.position.y < threshold) 
        { 
            Destroy(gameObject);
        } 
	} 
} 
