using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour
{
    private float hatchTime = 10f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= hatchTime)
        {
            Hatch();
        }
    }

    private void Hatch()
    {
        GameManager.Instance.UpdateCount("egg", -1);
        Vector3 position = transform.position;
        Destroy(gameObject);
        Instantiate(GameManager.Instance.chickPrefab, position, Quaternion.identity);
    }
} 