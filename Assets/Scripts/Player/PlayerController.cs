using UnityEngine;

/// <summary>
/// Controla el movimiento del zorro espiritual
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Velocidad de movimiento horizontal")]
    [SerializeField] private float moveSpeed = 5f;
    
    [Tooltip("Fuerza del salto")]
    [SerializeField] private float jumpForce = 12f;
    
    [Header("Ground Check")]
    [Tooltip("Punto desde donde se detecta el suelo")]
    [SerializeField] private Transform groundCheck;
    
    [Tooltip("Radio de detección del suelo")]
    [SerializeField] private float groundCheckRadius = 0.2f;
    
    [Tooltip("Capa que representa el suelo")]
    [SerializeField] private LayerMask groundLayer;
    
    // Referencias de componentes
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    // Estado del jugador
    private float moveInput;
    private bool isGrounded;
    private bool jumpPressed;
    
    void Start()
    {
        // Obtener referencias a componentes
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        // Verificar que tenemos todas las referencias necesarias
        if (rb == null)
        {
            Debug.LogError("¡Falta Rigidbody2D en el jugador!");
        }
        
        if (animator == null)
        {
            Debug.LogError("¡Falta Animator en el jugador!");
        }
        
        if (groundCheck == null)
        {
            Debug.LogWarning("¡Falta asignar Ground Check! El salto no funcionará correctamente.");
        }
    }
    
    void Update()
    {
        // Leer input del jugador
        ReadInput();
        
        // Voltear sprite según dirección
        FlipSprite();
        
        // Detectar si está en el suelo
        CheckGround();
        
        // Actualizar animaciones
        UpdateAnimations();
    }
    
    void FixedUpdate()
    {
        // Aplicar movimiento (usamos FixedUpdate para físicas)
        Move();
        
        // Aplicar salto
        Jump();
    }
    
    /// <summary>
    /// Lee el input del jugador (teclas)
    /// </summary>
    private void ReadInput()
    {
        // Movimiento horizontal (A/D o Flechas)
        moveInput = Input.GetAxisRaw("Horizontal");
        
        // Salto (Espacio o W)
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }
    
    /// <summary>
    /// Mueve al jugador horizontalmente
    /// </summary>
    private void Move()
    {
        // Calcular nueva velocidad
        float targetVelocityX = moveInput * moveSpeed;
        
        // Aplicar velocidad manteniendo la velocidad vertical
        rb.linearVelocity = new Vector2(targetVelocityX, rb.linearVelocity.y);
    }
    
    /// <summary>
    /// Hace que el jugador salte si está en el suelo
    /// </summary>
    private void Jump()
    {
        if (jumpPressed && isGrounded)
        {
            // Aplicar fuerza de salto
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            
            // Reproducir sonido de salto
            AudioManager.Instance.PlayJump();
            
            jumpPressed = false;
        }
    }
    
    /// <summary>
    /// Detecta si el jugador está tocando el suelo
    /// </summary>
    private void CheckGround()
    {
        if (groundCheck == null)
        {
            Debug.LogWarning("GroundCheck is NULL!");
            isGrounded = true; // Fallback temporal
            return;
        }
        
        // Detectar colisión con el suelo usando un círculo
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position, 
            groundCheckRadius, 
            groundLayer
        );
    }
    
    /// <summary>
    /// Actualiza los parámetros del Animator según el estado del jugador
    /// </summary>
    private void UpdateAnimations()
    {
        if (animator == null) 
        {
            Debug.LogError("Animator is NULL!");
            return;
        }
        
        // Actualizar parámetro isRunning
        bool isRunning = Mathf.Abs(moveInput) > 0.01f;
        Debug.Log("Setting isRunning to: " + isRunning + " | moveInput: " + moveInput);
        animator.SetBool("isRunning", isRunning);
        
        // Actualizar parámetro isGrounded
        animator.SetBool("isGrounded", isGrounded);
        
        // Actualizar parámetro isJumping
        bool isJumping = !isGrounded;
        animator.SetBool("isJumping", isJumping);
    }
    
    /// <summary>
    /// Voltea el sprite según la dirección de movimiento
    /// </summary>
    private void FlipSprite()
    {
        if (moveInput > 0)
        {
            // Moviendo a la derecha
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            // Moviendo a la izquierda
            spriteRenderer.flipX = true;
        }
    }
    
    // Dibujar el círculo de detección en el editor (debug visual)
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}