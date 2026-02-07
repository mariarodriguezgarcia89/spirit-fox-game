using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Maneja la interfaz de usuario (HUD)
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("Texto que muestra la puntuación")]
    [SerializeField] private Text scoreText;
    
    [Tooltip("Imágenes de los corazones de vida")]
    [SerializeField] private Image[] heartImages;
    
    [Header("Player Reference")]
    [Tooltip("Referencia al jugador")]
    [SerializeField] private PlayerHealth playerHealth;
    
    private int currentScore = 0;
    
    void Start()
    {
        UpdateScoreDisplay();
        UpdateHealthDisplay();
    }
    
    void Update()
    {
        // Actualizar vida cada frame
        UpdateHealthDisplay();
    }
    
    /// <summary>
    /// Añade puntos al marcador
    /// </summary>
    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreDisplay();
        Debug.Log("Puntuación actual: " + currentScore);
    }
    
    /// <summary>
    /// Actualiza el texto de puntuación
    /// </summary>
    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }
    
    /// <summary>
    /// Actualiza los corazones según la vida del jugador
    /// </summary>
    private void UpdateHealthDisplay()
    {
        if (playerHealth == null) return;
        
        int currentHealth = playerHealth.GetCurrentHealth();
        
        // Mostrar/ocultar corazones según vida actual
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHealth)
            {
                heartImages[i].enabled = true; // Mostrar corazón
            }
            else
            {
                heartImages[i].enabled = false; // Ocultar corazón
            }
        }
    }
}