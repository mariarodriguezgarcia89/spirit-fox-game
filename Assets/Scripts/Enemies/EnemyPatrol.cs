using UnityEngine;

/// <summary>
/// Hace que el enemigo patrullaje entre dos puntos
/// </summary>
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
        // Buscar SpriteRenderer en hijos si no está en este objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        
        startPosition = transform.position;
    }
    
    void FixedUpdate()
    {
        Patrol();
    }
    
    private void Patrol()
    {
        float leftLimit = startPosition.x - patrolDistance;
        float rightLimit = startPosition.x + patrolDistance;
        
        if (movingRight)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
            if (spriteRenderer != null) spriteRenderer.flipX = false;
            
            if (transform.position.x >= rightLimit)
                movingRight = false;
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
            if (spriteRenderer != null) spriteRenderer.flipX = true;
            
            if (transform.position.x <= leftLimit)
                movingRight = true;
        }
    }
}