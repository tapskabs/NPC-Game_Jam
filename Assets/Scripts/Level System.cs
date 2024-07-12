using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{

    public Slider LevelBarFill; // Reference to the level bar fill image
    public int maxLevel = 5; // Maximum number of levels
    public int initialRequirement = 5; // Initial requirement for the first level
    public TextMeshPro LevelCount;

    public int currentLevel;
    public int currentProgress;
    public int currentRequirement;

    public PlayerMovement makeEmSmaller;

    void Start()
    {
        currentLevel = 1;
        currentProgress = 0;
        currentRequirement = initialRequirement;
        UpdateLevelUI();
        makeEmSmaller = GetComponent<PlayerMovement>();
    }

    // Call this function to increase progress
    public void IncreaseProgress()
    {
        Debug.Log("One step closer..");
        currentProgress++;

        if (currentProgress >= currentRequirement)
        {
            currentProgress = 0;
            currentLevel++;
            currentRequirement += 8;
            if (currentLevel > maxLevel)
            {
                currentLevel = maxLevel;
                Debug.Log("Max level reached");
            }
        }
        UpdateLevelUI();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Edible"))
        {
            IncreaseProgress();
            Destroy(other.gameObject); // Optionally destroy the edible object
        }
    }

    void UpdateLevelUI()
    {
        LevelBarFill.value = (int)currentProgress; // Update the fill amount of the level bar
        LevelCount.text = "Level:" + currentLevel.ToString();
        Debug.Log("Level: " + currentLevel + " Progress: " + currentProgress + "/" + currentRequirement);
    }

    private void Update()
    {
        UpdateLevelUI();
    }
}




