using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sphere;
    private float delay = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", delay, delay);
    }
    void Spawn()
    {
        //spawn a sphere at the position of the spawner
        Instantiate(sphere, transform.position, Quaternion.identity);
        // Instantiate(sphere, new Vector3(9, 13, 0), Quaternion.identity);
        // Instantiate(sphere, new Vector3(Random.Range(-6, 6), 10, Random.Range(-6, 6)), Quaternion.identity);
    }
}
