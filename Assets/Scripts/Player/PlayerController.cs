using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("Fall Death")]
    [SerializeField] private float fallThreshold = -10f;
    private int extraJumps;
    
    [Header("Ground Check")]
    [Tooltip("Punto desde donde se detecta el suelo")]
    [SerializeField] private Transform groundCheck;
    
    [Tooltip("Radio de detección del suelo")]
    [SerializeField] private float groundCheckRadius = 0.3f;
    
    [Tooltip("Capa que representa el suelo")]
    [SerializeField] private LayerMask groundLayer;

    [Header("Jump Feel")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    
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

        // Lógica de Salto
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                ApplyJump();
            }
            else if (extraJumps > 0)
            {
                ApplyJump();
                extraJumps--;
            }
        }

        // Resetear saltos al tocar el suelo
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        // Fall multiplier para caída más natural
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        CheckFallDeath();
    }

    private void Die()
    {
        enabled = false; // Desactiva el input del jugador
        SceneManager.LoadScene("GameOver");
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
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void ApplyJump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        
        if (AudioManager.Instance != null) 
            AudioManager.Instance.PlayJump();
    }
    
    private void CheckGround()
    {
        if (groundCheck == null) return;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
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
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    private float deathDelay = 3f; // 3 segundos antes de empezar a comprobar
    private float timer = 0f;

    private void CheckFallDeath()
    {
        timer += Time.deltaTime;
        if (timer < deathDelay) return; // Espera 3 segundos antes de comprobar
    
        Debug.Log("Posición Y actual: " + transform.position.y);
    
        if (transform.position.y < fallThreshold)
        {
            Debug.Log("¡MUERTE! Y: " + transform.position.y);
            Die();
        }
    }
}