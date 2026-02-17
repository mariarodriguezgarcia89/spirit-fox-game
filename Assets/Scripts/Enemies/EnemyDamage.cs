using UnityEngine;

/// <summary>
/// Hace daño al jugador cuando lo toca, o muere si el jugador salta encima
/// </summary>
public class EnemyDamage : MonoBehaviour
{
    [Header("Damage Settings")]
    [Tooltip("Cuánto daño hace al jugador")]
    [SerializeField] private int damageAmount = 1;
    
    [Tooltip("Tiempo de invulnerabilidad del jugador después de recibir daño")]
    [SerializeField] private float invulnerabilityTime = 1f;
    
    [Header("Stomp Settings")]
    [Tooltip("Puntos que da el enemigo al ser eliminado")]
    [SerializeField] private int pointsForKill = 10;
    
    [Tooltip("Impulso hacia arriba cuando el jugador salta encima")]
    [SerializeField] private float bounceForce = 10f;
    
    [Tooltip("Offset para detectar si el jugador está encima (ajustar según tamaño del enemigo)")]
    [SerializeField] private float stompOffset = 0.3f;

    [Header("Effects")]
    [Tooltip("Efecto de partículas cuando muere el enemigo")]
    [SerializeField] private GameObject deathEffect;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si tocó al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtener la posición del jugador y del enemigo
            float playerY = collision.transform.position.y;
            float enemyY = transform.position.y;
            
            // Verificar si el jugador está cayendo (velocidad Y negativa)
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            bool isFalling = playerRb != null && playerRb.linearVelocity.y < 0;
            
            // Si el jugador está encima Y está cayendo
            if (playerY > enemyY + stompOffset && isFalling)
            {
                // El jugador saltó encima - eliminar enemigo
                Debug.Log("¡Jugador saltó encima del enemigo!");
                DestroyEnemy();
                
                // Hacer que el jugador rebote hacia arriba
                if (playerRb != null)
                {
                    playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceForce);
                }
            }
            else
            {
                // Contacto lateral/inferior - hacer daño al jugador
                Debug.Log("¡Enemigo tocó al jugador!");
                
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                }
                else
                {
                    Debug.LogWarning("¡El jugador no tiene componente PlayerHealth!");
                }
            }
        }
    }
    
    private void DestroyEnemy()
    {
        // Sumar puntos al marcador
        UIManager uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
        {
            uiManager.AddScore(pointsForKill);
            Debug.Log("¡+" + pointsForKill + " puntos!");
        }
        else
        {
            Debug.LogWarning("No se encontró UIManager en la escena");
        }
        
        // Reproducir sonido de enemigo destruido
        AudioManager.Instance.PlayEnemyDeath();
        
        // Crear efecto de partículas en la posición del enemigo
        if (deathEffect != null)
        {
            Vector3 particlePos = new Vector3(transform.position.x, transform.position.y, -2f);
            GameObject particles = Instantiate(deathEffect, particlePos, Quaternion.identity);
            Debug.Log("Partículas creadas en posición: " + particlePos);
        }
        else
        {
            Debug.LogWarning("deathEffect es null - no hay prefab asignado!");
        }
        
        // Destruir el enemigo
        Destroy(gameObject);
    }
}