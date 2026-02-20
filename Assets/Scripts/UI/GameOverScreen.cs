using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Maneja la pantalla de Game Over
/// </summary>
public class GameOverScreen : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayGameOverMusic();
    }

    /// <summary>
    /// Reinicia el nivel
    /// </summary>
    public void Retry()
    {
        AudioManager.Instance?.PlayButtonClick();
        AudioManager.Instance?.PlayGameMusic();
        Debug.Log("Reintentando nivel...");
        SceneManager.LoadScene("GameLevel");
    }
    
    /// <summary>
    /// Vuelve al menú principal
    /// </summary>
    public void BackToMenu()
    {
        AudioManager.Instance?.PlayButtonClick();
        AudioManager.Instance?.PlayMenuMusic();
        Debug.Log("Volviendo al menú...");
        SceneManager.LoadScene("MainMenu");
    }
}