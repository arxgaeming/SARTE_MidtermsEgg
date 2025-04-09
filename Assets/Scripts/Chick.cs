using UnityEngine;
using System.Collections;

public class Chick : MonoBehaviour
{
    private float growTime = 10f;
    private float timer = 0f;

    private void Start()
    {
        GameManager.Instance.UpdateCount("chick", 1);
        GameManager.chickSpawnCount++;  // Increment the spawn counter
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= growTime)
        {
            Grow();
        }
    }

    private void Grow()
    {
        GameManager.Instance.UpdateCount("chick", -1);
        Vector3 position = transform.position;
        Destroy(gameObject);

        // First chick always becomes a hen, others are random
        if (GameManager.chickSpawnCount == 1)
        {
            Instantiate(GameManager.Instance.henPrefab, position, Quaternion.identity);
        }
        else
        {
            // Randomly choose between hen and rooster
            if (Random.value < 0.5f)
            {
                Instantiate(GameManager.Instance.henPrefab, position, Quaternion.identity);
            }
            else
            {
                Instantiate(GameManager.Instance.roosterPrefab, position, Quaternion.identity);
            }
        }
    }
} 