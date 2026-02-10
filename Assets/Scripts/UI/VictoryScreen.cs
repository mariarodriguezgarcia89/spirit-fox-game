using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Maneja la pantalla de victoria
/// </summary>
public class VictoryScreen : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Text finalScoreText;
    
    void Start()
    {
        // TODO: Obtener puntuación real del juego
        // Por ahora mostramos un valor de ejemplo
        if (finalScoreText != null)
        {
            finalScoreText.text = "Puntuación: 0";
        }
    }
    
    /// <summary>
    /// Reinicia el nivel
    /// </summary>
    public void PlayAgain()
    {
        SceneManager.LoadScene("GameLevel");
    }
    
    /// <summary>
    /// Vuelve al menú principal
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}