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
        
        if (collision.CompareTag("Player") && !hasBeenOpened)
        {
            hasBeenOpened = true;
            Debug.Log("¡Caja tocada! Abriendo...");
            StartCoroutine(OpenBoxSequence());
        }
    }
    
    private IEnumerator OpenBoxSequence()
    {
        if (openBoxSprite != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = openBoxSprite;
            Debug.Log("¡Caja abierta!");
        }
        
        yield return new WaitForSeconds(delayBeforeVictory);
        
        Debug.Log("Cargando pantalla de victoria...");
        
        float timeLeft = FindObjectOfType<GameTimer>().GetTimeRemaining();
        PlayerPrefs.SetFloat("TimeRemaining", timeLeft);
        
        UIManager uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
            uiManager.SaveScore();
        
        PlayerPrefs.Save();
        SceneManager.LoadScene(victorySceneName);
    }
}