using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : MonoBehaviour
{
    public GameObject bossPrefab; 
    public Transform player; 
    public float bossSpeed = 3f; 

    private static GameObject bossInstance;

    void Start()
    {
        if (bossInstance == null)
        {
            SpawnBoss();
        }
    }

    void Update()
    {
        if (bossInstance != null)
        {
            
            Vector2 direction = (player.position - bossInstance.transform.position).normalized;
            bossInstance.transform.position = Vector2.MoveTowards(bossInstance.transform.position, player.position, bossSpeed * Time.deltaTime);
        }
    }

    void SpawnBoss()
    {
        if (bossInstance == null)
        {
            
            Vector2 spawnPosition = new Vector2(0, 0);
            bossInstance = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
            bossInstance.tag = "Boss"; 
            bossInstance.AddComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
