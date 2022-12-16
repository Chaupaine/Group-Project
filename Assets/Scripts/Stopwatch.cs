using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    private float currentTime;
    public bool countDown;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = PlayerPrefs.GetFloat("TotalTime", 0f);
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
}
