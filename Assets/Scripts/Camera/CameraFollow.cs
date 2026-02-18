using UnityEngine;

/// <summary>
/// Hace que la cámara siga suavemente al jugador
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    [Tooltip("El jugador que la cámara debe seguir")]
    [SerializeField] private Transform target;
    
    [Header("Follow Settings")]
    [Tooltip("Velocidad de seguimiento (más alto = más rápido)")]
    [SerializeField] private float smoothSpeed = 0.125f;
    
    [Tooltip("Offset de la cámara respecto al jugador")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 2f, -10f);
    
    [Header("Limits (Optional)")]
    [Tooltip("¿Usar límites de cámara?")]
    [SerializeField] private bool useLimits = false;
    
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f;
    
    void Start()
    {
        // Encontrar al jugador automáticamente si no está asignado
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
            else
            {
                Debug.LogError("¡No se encontró al jugador! Asegúrate de que tenga el tag 'Player'");
            }
        }
    }
    
    void LateUpdate()
    {
        if (target == null) return;
        
        Vector3 desiredPosition = target.position + offset;
        
        if (useLimits)
        {
            // Calculamos el tamaño visible de la cámara
            Camera cam = Camera.main;
            float camHalfHeight = cam.orthographicSize;
            float camHalfWidth = cam.orthographicSize * cam.aspect;

            // Ajustamos los límites teniendo en cuenta el tamaño de la cámara
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX + camHalfWidth, maxX - camHalfWidth);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY + camHalfHeight, maxY - camHalfHeight);
        }
        
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position, 
            desiredPosition, 
            smoothSpeed
        );
        
        transform.position = smoothedPosition;
    }
}