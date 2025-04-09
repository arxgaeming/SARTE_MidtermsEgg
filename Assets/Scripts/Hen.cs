using UnityEngine;
using System.Collections;

public class Hen : MonoBehaviour
{
    private float layEggTime = 30f;
    private float deathTime = 40f;
    private float timer = 0f;
    private bool hasLaidEggs = false;

    private void Start()
    {
        GameManager.Instance.UpdateCount("hen", 1);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // Lay eggs after 30 seconds
        if (timer >= layEggTime && !hasLaidEggs)
        {
            LayEggs();
            hasLaidEggs = true;
        }

        // Die after 40 seconds
        if (timer >= deathTime)
        {
            Die();
        }
    }

    private void LayEggs()
    {
        int eggCount = Random.Range(2, 11);
        for (int i = 0; i < eggCount; i++)
        {
            GameManager.Instance.SpawnEgg();
        }
    }

    private void Die()
    {
        GameManager.Instance.UpdateCount("hen", -1);
        Destroy(gameObject);
    }
} 