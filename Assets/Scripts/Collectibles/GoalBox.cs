using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBox : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject magicStar;
    [SerializeField] private GameObject victoryCanvas;
    
    [Header("Animation Settings")]
    [SerializeField] private float starPopHeight = 3f;
    [SerializeField] private float starPopDuration = 1f;
    [SerializeField] private float delayBeforeVictory = 1.5f;
    
    [Header("Effects")]
    [SerializeField] private bool rotateStarWhileRising = true;
    [SerializeField] private float rotationSpeed = 360f;
    [SerializeField] private bool hideBoxWhenActivated = true;
    
    private bool hasBeenActivated = false;
    private SpriteRenderer boxRenderer;

    private void Start()
    {
        Time.timeScale = 1;
        boxRenderer = GetComponent<SpriteRenderer>();
        
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasBeenActivated)
        {
            hasBeenActivated = true;
            StartCoroutine(GoalSequence());
        }
    }

    private IEnumerator GoalSequence()
    {
        AudioManager.Instance.PlayChestOpen();
        
        if (hideBoxWhenActivated && boxRenderer != null)
        {
            boxRenderer.enabled = false;
        }
        
        magicStar.SetActive(true);
        Vector3 startPos = magicStar.transform.position;
        Vector3 endPos = startPos + Vector3.up * starPopHeight;
        
        float elapsed = 0f;
        
        while (elapsed < starPopDuration)
        {
            float t = elapsed / starPopDuration;
            float smoothT = 1f - Mathf.Pow(1f - t, 3f);
            
            magicStar.transform.position = Vector3.Lerp(startPos, endPos, smoothT);
            
            if (rotateStarWhileRising)
            {
                magicStar.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            }
            
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        magicStar.transform.position = endPos;
        
        yield return new WaitForSeconds(delayBeforeVictory);
        
        ShowVictory();
    }

    private void ShowVictory()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Victory");
    }
}