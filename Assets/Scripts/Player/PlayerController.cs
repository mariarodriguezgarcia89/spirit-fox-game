using UnityEngine;

/// <summary>
/// Controla el movimiento del zorro espiritual con Doble Salto incluido.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Velocidad de movimiento horizontal")]
    [SerializeField] private float moveSpeed = 5f;
    
    [Tooltip("Fuerza del salto")]
    [SerializeField] private float jumpForce = 12f;

    [Tooltip("Cantidad de saltos extra permitidos (1 = Doble Salto)")]
    [SerializeField] private int extraJumpsValue = 1;
    private int extraJumps;
    
    [Header("Ground Check")]
    [Tooltip("Punto desde donde se detecta el suelo")]
    [SerializeField] private Transform groundCheck;
    
    [Tooltip("Radio de detección del suelo")]
    [SerializeField] private float groundCheckRadius = 0.3f; // Un poco más grande para evitar fallos
    
    [Tooltip("Capa que representa el suelo")]
    [SerializeField] private LayerMask groundLayer;
    
    // Referencias de componentes
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    // Estado del jugador
    private float moveInput;
    private bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        // Inicializamos los saltos extra
        extraJumps = extraJumpsValue;

        if (rb == null) Debug.LogError("¡Falta Rigidbody2D!");
        if (groundCheck == null) Debug.LogWarning("¡Falta asignar el objeto Ground Check!");
    }
    
    void Update()
    {
        ReadInput();
        FlipSprite();
        CheckGround();
        UpdateAnimations();

        // Lógica de Salto en Update para respuesta instantánea
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                ApplyJump();
            }
            else if (extraJumps > 0)
            {
                ApplyJump();
                extraJumps--; // Gastamos un salto extra en el aire
            }
        }

        // Resetear saltos al tocar el suelo
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }
    }
    
    void FixedUpdate()
    {
        Move();
    }

    private void ReadInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    private void Move()
    {
        // Aplicamos velocidad horizontal manteniendo la vertical del Rigidbody
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void ApplyJump()
    {
        // Reseteamos la velocidad vertical antes de saltar para que el impulso sea siempre igual
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        
        if (AudioManager.Instance != null) 
            AudioManager.Instance.PlayJump();
    }
    
    private void CheckGround()
    {
        if (groundCheck == null) return;

        // Detectamos si el círculo de los pies toca la capa de suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        // Debug para ver el estado en la consola (puedes borrarlo luego)
        // Debug.Log("En suelo: " + isGrounded);
    }
    
    private void UpdateAnimations()
    {
        if (animator == null) return;
        
        bool isRunning = Mathf.Abs(moveInput) > 0.01f;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isJumping", !isGrounded);
    }
    
    private void FlipSprite()
    {
        if (moveInput > 0) spriteRenderer.flipX = false;
        else if (moveInput < 0) spriteRenderer.flipX = true;
    }
    
    private void OnDrawGizmosSelected()
    {
        // Dibuja el círculo en la ventana de escena para ajustar el sensor
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}