using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public Animator animator;
    private int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void OnTriggerEnter(Collider other) 
    {
        animator.SetTrigger("FadeOut");
        SceneManager.LoadScene(sceneIndex);
    }

    
}