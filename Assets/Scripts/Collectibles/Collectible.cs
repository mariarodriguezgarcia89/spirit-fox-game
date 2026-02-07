using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Collectible Settings")]
    [SerializeField] private int pointValue = 10;
    [SerializeField] private AudioClip collectSound;
    
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
            
            // Destruir el objeto
            Destroy(gameObject);
        }
    }
}