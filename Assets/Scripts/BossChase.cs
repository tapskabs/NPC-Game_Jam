using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform player;
    public float bossSpeed = 3f;

    private List<GameObject> bosses = new List<GameObject>(); // List to store multiple boss instances
    private int currentLevel = 0;

    void Start()
    {
        // Spawn the initial boss
        SpawnBoss();
    }

    void Update()
    {
        int level = LevelSystem.instance.currentLevel;

        if (level != currentLevel)
        {
            currentLevel = level;
            SpawnBoss();
        }

        foreach (GameObject boss in bosses)
        {
            if (boss != null)
            {
                Vector2 direction = (player.position - boss.transform.position).normalized;
                boss.transform.position = Vector2.MoveTowards(boss.transform.position, player.position, bossSpeed * Time.deltaTime);
            }
        }
    }

    void SpawnBoss()
    {
        Vector2 spawnPosition = new Vector2(0, 0); // Define your spawn position
        GameObject newBoss = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
        newBoss.tag = "Boss";
        newBoss.AddComponent<BoxCollider2D>().isTrigger = true;
        bosses.Add(newBoss);
    }
}
