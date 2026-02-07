using UnityEngine;

/// <summary>
/// Hace que el enemigo patrullaje entre dos puntos
public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Settings")]
    [Tooltip("Velocidad de movimiento")]
    [SerializeField] private float moveSpeed = 2f;
    
    [Tooltip("Distancia que recorre hacia cada lado")]
    [SerializeField] private float patrolDistance = 3f;
    
    // Referencias
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    // Estado
    private Vector2 startPosition;
    private bool movingRight = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Guardar posición inicial
        startPosition = transform.position;
    }
    
    void FixedUpdate()
    {
        Patrol();
    }
    
    /// <summary>
    /// Patrulla entre dos puntos
    /// </summary>
    private void Patrol()
    {
        // Calcular límites de patrullaje
        float leftLimit = startPosition.x - patrolDistance;
        float rightLimit = startPosition.x + patrolDistance;
        
        // Movimiento
        if (movingRight)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
            spriteRenderer.flipX = false;
            
            // Cambiar dirección si llegó al límite derecho
            if (transform.position.x >= rightLimit)
            {
                movingRight = false;
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
            spriteRenderer.flipX = true;
            
            // Cambiar dirección si llegó al límite izquierdo
            if (transform.position.x <= leftLimit)
            {
                movingRight = true;
            }
        }
    }
}