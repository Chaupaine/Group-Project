using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Stopwatch : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI totalTimerText;

    [Header("Timer Settings")]
    private float currentTime;
    public bool countDown;
    public bool total;
    private float totalTime;

    private void Awake()
    {
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    // Start is called before the first frame update
    void Start()
    {
        // if first level, set total time to 0
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetFloat("TotalTime", 0f);
        }

        totalTime = PlayerPrefs.GetFloat("TotalTime", 0f);
        currentTime = PlayerPrefs.GetFloat("TotalTime", 0f);

        // if last level, set total time text
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            totalTimerText.text = "Total Time: " + totalTime.ToString("0.00") + " s";
        }
        // set total time text
        // totalTimerText.text = "Total Time: " + totalTime.ToString("0.00") + " s";
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        // if not last level, update timer text
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SetTimerText();
            timerText.color = Color.red;
            PlayerPrefs.SetFloat("TotalTime", currentTime);
        }
    }

    private void SetTimerText() {
        timerText.text = "Time: " + currentTime.ToString("0.00") + " s";
    }

    private void OnActiveSceneChanged(Scene oldScene, Scene newScene)
    {
        float totalTime = PlayerPrefs.GetFloat("TotalTime");

        
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1) {
            timerText.text = "Total Time: " + totalTime.ToString("0.00") + " s";
        }
    }
}
