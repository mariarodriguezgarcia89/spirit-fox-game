using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Detecta cuando el jugador alcanza la meta y gana el juego
/// </summary>
public class GoalTrigger : MonoBehaviour
{
    [Header("Victory Settings")]
    [Tooltip("Escena de victoria a cargar")]
    [SerializeField] private string victorySceneName = "Victory";
    
    [Header("Box Sprites")]
    [Tooltip("Sprite de la caja cerrada")]
    [SerializeField] private Sprite closedBoxSprite;
    
    [Tooltip("Sprite de la caja abierta/rota")]
    [SerializeField] private Sprite openBoxSprite;
    
    [Tooltip("Tiempo antes de ir a Victoria (segundos)")]
    [SerializeField] private float delayBeforeVictory = 1f;
    
    private SpriteRenderer spriteRenderer;
    private bool hasBeenOpened = false;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("¡Algo tocó el Goal! Objeto: " + collision.gameObject.name + " | Tag: " + collision.tag);
    
    // Verificar si es el jugador y no ha sido abierta aún
    if (collision.CompareTag("Player") && !hasBeenOpened)
    {
        hasBeenOpened = true;
        Debug.Log("¡Caja tocada! Abriendo...");
        
        // Iniciar la secuencia de apertura
        StartCoroutine(OpenBoxSequence());
    }
}
    
    /// <summary>
    /// Secuencia de abrir la caja y luego ir a victoria
    /// </summary>
    private IEnumerator OpenBoxSequence()
    {
        // Cambiar a sprite de caja abierta
        if (openBoxSprite != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = openBoxSprite;
            Debug.Log("¡Caja abierta!");
        }
        
        // Esperar un momento para que el jugador vea la caja abierta
        yield return new WaitForSeconds(delayBeforeVictory);
        
        // Cargar pantalla de victoria
        Debug.Log("Cargando pantalla de victoria...");
        // Guardar tiempo restante para la pantalla de victoria
        float timeLeft = FindObjectOfType<GameTimer>().GetTimeRemaining();
        PlayerPrefs.SetFloat("TimeRemaining", timeLeft);
        PlayerPrefs.Save();
        SceneManager.LoadScene(victorySceneName);
    }

    
}