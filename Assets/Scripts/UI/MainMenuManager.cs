using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Maneja el menú principal
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    /// <summary>
    /// Inicia el juego (carga la escena de juego)
    /// </summary>
    public void PlayGame()
    {
        Debug.Log("Cargando escena de juego...");
        SceneManager.LoadScene("GameLevel");
    }
    
    /// <summary>
    /// Cierra el juego
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
        
        // En el editor de Unity, esto detiene el juego
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}