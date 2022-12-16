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
        totalTime = PlayerPrefs.GetFloat("TotalTime", 0f);
        currentTime = PlayerPrefs.GetFloat("TotalTime", 0f);

        // set total time text
        totalTimerText.text = "Total Time: " + totalTime.ToString("0.00") + " s";
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        SetTimerText();
        timerText.color = Color.red;
        PlayerPrefs.SetFloat("TotalTime", currentTime);
    }

    private void SetTimerText() {
        timerText.text = "Time: " + currentTime.ToString("0.00") + " s";
    }

    private void OnActiveSceneChanged(Scene oldScene, Scene newScene)
    {
        float totalTime = PlayerPrefs.GetFloat("TotalTime");
        timerText.text = "Total Time: " + totalTime.ToString("0.00") + " s";
    }
}
