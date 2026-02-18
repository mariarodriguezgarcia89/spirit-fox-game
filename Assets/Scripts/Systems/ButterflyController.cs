using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float startX = -25f;
    [SerializeField] private float endX = 25f;

    [Header("Spawn Range")]
    [SerializeField] private float minY = 5f;
    [SerializeField] private float maxY = 15f;

    void Start()
    {
        ResetPosition();
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x > endX)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        float randomY = Random.Range(minY, maxY);
        transform.position = new Vector3(startX, randomY, 0f);
    }
}