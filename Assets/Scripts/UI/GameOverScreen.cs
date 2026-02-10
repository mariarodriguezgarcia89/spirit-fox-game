using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Maneja la pantalla de Game Over
/// </summary>
public class GameOverScreen : MonoBehaviour
{
    /// <summary>
    /// Reinicia el nivel
    /// </summary>
    public void Retry()
    {
        Debug.Log("Reintentando nivel...");
        SceneManager.LoadScene("GameLevel");
    }
    
    /// <summary>
    /// Vuelve al menú principal
    /// </summary>
    public void BackToMenu()
    {
        Debug.Log("Volviendo al menú...");
        SceneManager.LoadScene("MainMenu");
    }
}