using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;

public class LevelSystem : MonoBehaviour
{

    public Slider LevelBarFill; // Reference to the level bar fill image
    public int maxLevel = 5; // Maximum number of levels
    public int initialRequirement = 15; // Initial requirement for the first level
    public TextMeshProUGUI LevelCount;
    public GameObject BossPrefab;
    public int numberOfBosses;
    public int currentLevel;
    public int currentProgress;
    public int currentRequirement;
    public Vector2 spawnAreaMin; // Minimum x and y coordinates for the spawn area
    public Vector2 spawnAreaMax;
    public PlayerMovement makeEmSmaller;
    public GameObject LvlClearPanel;
    public AudioSource LvlClear;
    public AudioSource eat;
    

    void Start()
    {
        currentLevel = 1;
        currentProgress = 0;
        currentRequirement = initialRequirement;
        UpdateLevelUI();
        makeEmSmaller = GetComponent<PlayerMovement>();
        LvlClearPanel.SetActive(false);
        Time.timeScale = 1.0f;  
    }

    // Call this function to increase progress
    public void IncreaseProgress()
    {
        Debug.Log("One step closer..");
        currentProgress++;

        if (currentProgress >= currentRequirement)
        {
            for (int i = 0; i < numberOfBosses; i++)
            {
                float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
                float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
                Vector2 spawnPosition = new Vector2(randomX, randomY);

                Instantiate(BossPrefab, spawnPosition, Quaternion.identity);
            }

            currentProgress = 0;
            
            currentLevel++;
            currentRequirement += 15;
            initialRequirement = currentRequirement;
            LevelPassed();
            NextLevel();


            if (currentLevel > maxLevel)
            {
                currentLevel = maxLevel;
                Debug.Log("Max level reached");
            }
            LvlClear.Play();
        }
        UpdateLevelUI();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Edible"))
        {
           
            IncreaseProgress();
            Destroy(other.gameObject); // Optionally destroy the edible object
            eat.Play();
        }
    }

    public void LevelPassed() 
    {
        
        Time.timeScale = 0;
        LvlClearPanel.SetActive(true);
        LvlClear.Play();
    }

    public void ClearScreen()
    {
        Time.timeScale = 1;
        LvlClearPanel.SetActive(false);
    }

    public void NextLevel()
    {
     
        PlayerPrefs.SetInt("Current Progress", currentProgress);
        PlayerPrefs.Save();
        Debug.Log("Player Progress saved");
    }

    void UpdateLevelUI()
    {
        LevelBarFill.value = (int)currentProgress; // Update the fill amount of the level bar
        Debug.Log("Level: " + currentLevel + " Progress: " + currentProgress + "/" + currentRequirement);
    }

    private void Update()
    {
        UpdateLevelUI();
    }
}




