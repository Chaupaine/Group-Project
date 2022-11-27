using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int sceneIndex;
    void Start()
    {
        Time.timeScale = 1f;
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void PlayGame()
    {
        Debug.Log("Play Game");
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
