using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public float threshold = -50f;
    public GameObject player;
    public GameObject explosionParticles;
    public Animator animator;
    // Script for when ball falls out the map, basically resets the scene if ball falls past the threshold (Y position)
    void Update()
    {
        if (transform.position.y < threshold)
        {
            animator.SetTrigger("FadeOut");
            //play the explosion particles and make player null
            DoDelayAction(5f);
        }
    }
    //Write a function that resets the scene
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void DoDelayAction(float delayTime)
    {
        StartCoroutine(DelayAction(delayTime));
    }
 
    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
 
        //Do the action after the delay time has finished.
        ResetScene();
    }
}
