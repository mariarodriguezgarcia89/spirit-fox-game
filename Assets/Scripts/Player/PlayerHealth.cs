using UnityEngine;


/// <summary>
/// Maneja la vida del jugador
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [Tooltip("Vida máxima del jugador")]
    [SerializeField] private int maxHealth = 3;
    
    private int currentHealth;
    private bool isInvulnerable = false;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        Debug.Log("PlayerHealth: Vida inicial = " + currentHealth);
    }
    
    /// <summary>
    /// El jugador recibe daño
    /// </summary>
    /// <summary>
/// El jugador recibe daño
/// </summary>
public void TakeDamage(int damage)
{
    if (isInvulnerable) return;
    
    currentHealth -= damage;
    Debug.Log("¡Daño recibido! Vida actual: " + currentHealth);
    
    // Reproducir sonido de daño
    AudioManager.Instance.PlayDamage();
    
    // Efecto visual de daño (parpadeo)
    StartCoroutine(InvulnerabilityFlash());
    
    // Verificar si murió
    if (currentHealth <= 0)
    {
        Die();
    }
}
    
    /// <summary>
    /// Parpadeo de invulnerabilidad
    /// </summary>
    private System.Collections.IEnumerator InvulnerabilityFlash()
    {
        isInvulnerable = true;
        
        // Parpadear 3 veces
        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f); // Semi-transparente
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.color = Color.white; // Normal
            yield return new WaitForSeconds(0.15f);
        }
        
        isInvulnerable = false;
    }
    
    /// <summary>
/// El jugador muere
/// </summary>
    private void Die()
    {
        Debug.Log("¡El jugador ha muerto!");
    
    // Cargar pantalla de Game Over
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
    
    /// <summary>
    /// Obtener vida actual (para el HUD)
    /// </summary>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    
    /// <summary>
    /// Obtener vida máxima (para el HUD)
    /// </summary>
    public int GetMaxHealth()
    {
        return maxHealth;
    }
}