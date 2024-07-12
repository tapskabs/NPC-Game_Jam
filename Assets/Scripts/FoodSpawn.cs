using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] spawnPoints; // Array of empty game objects
    public int numberOfPrefabsToSpawn = 1; // Number of prefabs to spawn

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned.");
            return;
        }

        if (numberOfPrefabsToSpawn > spawnPoints.Length)
        {
            Debug.LogError("Number of prefabs to spawn is greater than the number of spawn points available.");
            return;
        }

        // Shuffle the spawn points array to ensure random selection without duplicates
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject temp = spawnPoints[i];
            int randomIndex = Random.Range(i, spawnPoints.Length);
            spawnPoints[i] = spawnPoints[randomIndex];
            spawnPoints[randomIndex] = temp;
        }

        // Spawn the prefabs at the shuffled spawn points
        for (int i = 0; i < numberOfPrefabsToSpawn; i++)
        {
            Instantiate(prefab, spawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}
