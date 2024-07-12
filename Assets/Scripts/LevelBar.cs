using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{

    public Slider LevelBarFill; // Reference to the health bar fill image
   
    public int maxLevel = 5;
    private int currentLevel;

    void Start()
    {
        currentLevel = 0; ;
        UpdateLevelUI();
    }
 

    // Call this function to increase health
    public void Increaselevel()
    {
        Debug.Log("Time added, player Chowed");
        currentLevel ++;
        if (currentLevel > maxLevel) currentLevel = maxLevel;
        UpdateLevelUI();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Edible")) 
        {
            Increaselevel();
        }
    }

    void UpdateLevelUI()
    {
        LevelBarFill.value = currentLevel; // Update the fill amount of the health bar
        Debug.Log("Level:" + Mathf.Ceil(currentLevel).ToString());
    }
    private void Update()
    {
        Debug.Log("Level:" + currentLevel.ToString());
        UpdateLevelUI();
       
    }

}
