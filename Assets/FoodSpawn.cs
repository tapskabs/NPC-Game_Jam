using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject prefab; // The prefab to spawn
    public BoxCollider2D boxCollider2D; // The Box Collider 2D

    void Start()
    {
        // Call the Spawn function to spawn the prefab
        Spawn();
    }

    void Spawn()
    {
        // Get the bounds of the Box Collider 2D
        Bounds bounds = boxCollider2D.bounds;

        // Generate a random position inside the bounds
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        // Instantiate the prefab at the random position
        Instantiate(prefab, randomPosition, Quaternion.identity);
    }
}
