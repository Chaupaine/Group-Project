using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void OnTriggerEnter(Collider other) 
    {
        SceneManager.LoadScene(sceneIndex);
    }
}