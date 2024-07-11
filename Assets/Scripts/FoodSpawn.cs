using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject prefab; 
    public BoxCollider2D boxCollider2D; 

    void Start()
    {
        
        Spawn();
    }

    void Spawn()
    {
        
        Bounds bounds = boxCollider2D.bounds;

        
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        
        Instantiate(prefab, randomPosition, Quaternion.identity);
    }
}
