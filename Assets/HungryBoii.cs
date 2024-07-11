using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HungryBoii : MonoBehaviour
{

    public Slider hungerBarFill; // Reference to the health bar fill image
    public TextMeshProUGUI hungerText; // Reference to the TextMeshPro health text

    public float maxHunger = 100f;
    private float currentHunger;

    void Start()
    {
        currentHunger = maxHunger; ;
        UpdateHungerUI();
    }

    // Call this function to decrease health
    public void GettingHungry()
    {

        currentHunger -= 3f * Time.deltaTime;
        UpdateHungerUI();

        if (currentHunger <= 0f)
        {
            currentHunger = 0f;
            // Handle what happens when the timer reaches 0
            Debug.Log("Time's up!");
        }

    }

    // Call this function to increase health
    public void Eat()
    {
        Debug.Log("Time added, player Chowed");
        currentHunger += 100f * Time.deltaTime;
        if (currentHunger > maxHunger) currentHunger = maxHunger;
        UpdateHungerUI();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Edible")) 
        {
            Eat();
            Destroy(other.gameObject);
        }
    }

    void UpdateHungerUI()
    {

        hungerBarFill.value = currentHunger; // Update the fill amount of the health bar
        Debug.Log("Hunger:" + Mathf.Ceil(currentHunger).ToString());
    }
    private void Update()
    {
        Debug.Log("Hunger:" + currentHunger.ToString());
        UpdateHungerUI();
        GettingHungry();
       
    }

}
