using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameControl gC;
    public ItemCollector iC;
    public Animator animator;
    private int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        gC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        Invoke("SetIc", 2.0f);
        //iC = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemCollector>();

        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void OnTriggerEnter(Collider other) 
    {
        //added by me
         //GameControl.control.previousScore = ItemCollector.access.coins;
        gC.previousScore = iC.coins;


        animator.SetTrigger("FadeOut");
        SceneManager.LoadScene(sceneIndex);
    }

    void SetIc()
    {
        iC = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemCollector>();

    }

    
}