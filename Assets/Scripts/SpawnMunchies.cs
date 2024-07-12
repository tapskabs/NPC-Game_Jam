using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMunchies : MonoBehaviour
{

    public GameObject prefab; // The prefab to be spawned
    public int numberOfPrefabs = 10; // Number of prefabs to spawn
    public Vector2 spawnAreaMin; // Minimum x and y coordinates for the spawn area
    public Vector2 spawnAreaMax; // Maximum x and y coordinates for the spawn area

    void Start()
    {
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
