using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float timeLimit = 60f;

    [Header("UI")]
    public TMP_Text timerText;

    [Header("Visual Warning")]
    public Color normalColor = Color.white;
    public Color warningColor = Color.red;
    public float warningThreshold = 15f;

    private float timeRemaining;
    private bool timerRunning = false;

    void Start()
    {
        timeRemaining = timeLimit;
        timerRunning = true;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!timerRunning) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            timerRunning = false;
            UpdateTimerDisplay();
            TimeUp();
            return;
        }

        UpdateTimerDisplay();

        if (timerText != null)
            timerText.color = timeRemaining <= warningThreshold ? warningColor : normalColor;
    }
    void UpdateTimerDisplay()
    {
        if (timerText == null) return;
            int seconds = Mathf.CeilToInt(timeRemaining);
            timerText.text = "Time: " + seconds.ToString("D2") + "s";
    }   

    public void StopTimer()
    {
        timerRunning = false;
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }

    void TimeUp()
    {
        PlayerPrefs.SetFloat("TimeRemaining", 0f);
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameOver");
    }
}