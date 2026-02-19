using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Maneja la pantalla de victoria
/// </summary>
public class VictoryScreen : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text finalTimeText;
    
    void Start()
    {
        Cursor.visible = true;
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayVictoryMusic();

        if (finalScoreText != null){
            int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
            finalScoreText.text = "Puntuación: " + finalScore;
        }

        if (finalTimeText != null)
        {
            float timeLeft = PlayerPrefs.GetFloat("TimeRemaining", 0f);
            int seconds = Mathf.RoundToInt(timeLeft);
            finalTimeText.text = "Tiempo restante: " + seconds + "s";
        }
    }
    
    public void PlayAgain()
    {
        AudioManager.Instance?.PlayButtonClick();
        AudioManager.Instance?.PlayGameMusic();
        SceneManager.LoadScene("GameLevel");
    }
    
    public void BackToMenu()
    {
        AudioManager.Instance?.PlayButtonClick();
        AudioManager.Instance?.PlayMenuMusic();
        SceneManager.LoadScene("MainMenu");
    }
}