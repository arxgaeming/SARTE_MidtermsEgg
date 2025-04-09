using UnityEngine;
using System.Collections;

public class Rooster : MonoBehaviour
{
    private float deathTime = 40f;
    private float timer = 0f;

    private void Start()
    {
        GameManager.Instance.UpdateCount("rooster", 1);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= deathTime)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.UpdateCount("rooster", -1);
        Destroy(gameObject);
    }
} 