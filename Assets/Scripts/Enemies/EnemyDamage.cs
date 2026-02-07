using UnityEngine;

/// <summary>
/// Hace daño al jugador cuando lo toca
/// </summary>
public class EnemyDamage : MonoBehaviour
{
    [Header("Damage Settings")]
    [Tooltip("Cuánto daño hace al jugador")]
    [SerializeField] private int damageAmount = 1;
    
    [Tooltip("Tiempo de invulnerabilidad del jugador después de recibir daño")]
    [SerializeField] private float invulnerabilityTime = 1f;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si tocó al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("¡Enemigo tocó al jugador!");
            
            // Intentar obtener el componente de salud del jugador
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