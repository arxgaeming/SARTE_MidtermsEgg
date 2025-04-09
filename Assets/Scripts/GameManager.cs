using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static int chickSpawnCount = 0;

    // Prefabs
    public GameObject eggPrefab;
    public GameObject chickPrefab;
    public GameObject henPrefab;
    public GameObject roosterPrefab;

    // UI Text components
    public TMP_Text eggCountText;
    public TMP_Text chickCountText;
    public TMP_Text henCountText;
    public TMP_Text roosterCountText;

    // Counters
    private int eggCount = 0;
    private int chickCount = 0;
    private int henCount = 0;
    private int roosterCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            chickSpawnCount = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Spawn initial egg
        SpawnEgg();
    }

    public void SpawnEgg()
    {
        // Increment counter before spawning
        UpdateCount("egg", 1);

        Vector3 randomPosition = new Vector3(
            Random.Range(-5f, 5f),
            2f, // Spawn slightly above ground
            Random.Range(-5f, 5f)
        );
        GameObject egg = Instantiate(eggPrefab, randomPosition, Quaternion.identity);
        
        // Add random force
        Rigidbody rb = egg.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 randomForce = new Vector3(
                Random.Range(-2f, 2f),
                0,
                Random.Range(-2f, 2f)
            );
            rb.AddForce(randomForce, ForceMode.Impulse);
        }
    }

    public void UpdateCount(string type, int change)
    {
        switch (type.ToLower())
        {
            case "egg":
                eggCount += change;
                eggCountText.text = "Eggs: " + eggCount;
                break;
            case "chick":
                chickCount += change;
                chickCountText.text = "Chicks: " + chickCount;
                break;
            case "hen":
                henCount += change;
                henCountText.text = "Hens: " + henCount;
                break;
            case "rooster":
                roosterCount += change;
                roosterCountText.text = "Roosters: " + roosterCount;
                break;
        }
    }
} 