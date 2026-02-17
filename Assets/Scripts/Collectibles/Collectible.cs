using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Collectible Settings")]
    [SerializeField] private int pointValue = 10;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("¡Coleccionable recogido! +" + pointValue + " puntos");
            
            // Buscar el UIManager y añadir puntos
            UIManager uiManager = FindObjectOfType<UIManager>();
            if (uiManager != null)
            {
                uiManager.AddScore(pointValue);
            }
            
            // Reproducir sonido de recolección
            AudioManager.Instance.PlayCollectGem();
            
            // Destruir el objeto
            Destroy(gameObject);
        }
    }
}