using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Maneja el menú principal
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    void Start()
    {
        // Asegurarse de que suena la música del menú
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayMenuMusic();
    }

    /// <summary>
    /// Inicia el juego (carga la escena de juego)
    /// </summary>
    public void PlayGame()
    {
        AudioManager.Instance?.PlayButtonClick();
        AudioManager.Instance?.PlayGameMusic();
        Debug.Log("Cargando escena de juego...");
        SceneManager.LoadScene("GameLevel");
    }
    
    /// <summary>
    /// Cierra el juego
    /// </summary>
    public void QuitGame()
    {
        AudioManager.Instance?.PlayButtonClick();
        Debug.Log("Saliendo del juego...");
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}