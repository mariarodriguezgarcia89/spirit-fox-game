using UnityEngine;

/// <summary>
/// Hace que el enemigo patrullaje entre dos puntos y salte aleatoriamente
/// </summary>
public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Settings")]
    [Tooltip("Velocidad de movimiento")]
    [SerializeField] private float moveSpeed = 2f;
    
    [Tooltip("Distancia que recorre hacia cada lado")]
    [SerializeField] private float patrolDistance = 3f;

    [Header("Jump Settings")]
    [Tooltip("Fuerza del salto")]
    [SerializeField] private float jumpForce = 6f;

    [Tooltip("Tiempo mínimo entre saltos")]
    [SerializeField] private float minJumpInterval = 1.5f;

    [Tooltip("Tiempo máximo entre saltos")]
    [SerializeField] private float maxJumpInterval = 4f;
    
    // Referencias
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    // Estado
    private Vector2 startPosition;
    private bool movingRight = true;
    private float jumpTimer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        
        startPosition = transform.position;
        ResetJumpTimer();
    }
    
    void Update()
    {
        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0f)
        {
            Jump();
            ResetJumpTimer();
        }
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

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void ResetJumpTimer()
    {
        jumpTimer = Random.Range(minJumpInterval, maxJumpInterval);
    }
}