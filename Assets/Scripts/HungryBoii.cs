using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HungryBoii : MonoBehaviour
{

    public Slider hungerBarFill; // Reference to the health bar fill image
    public TextMeshProUGUI hungerText; // Reference to the TextMeshPro health text
    public PlayerHealth PlayerHealth;
    public float maxHunger = 100f;
    public float currentHunger;
    public bool dying;

    void Start()
    {
        currentHunger = maxHunger; ;
        UpdateHungerUI();
        dying = false;
        PlayerHealth = GetComponent<PlayerHealth>();
    }

    // Call this function to decrease health
    public void GettingHungry()
    {

        currentHunger -= 2f * Time.deltaTime;
        UpdateHungerUI();

        if (currentHunger <= 0f)
        {
            dying = true;
            PlayerHealth.TakeDamage(1);
            currentHunger = 0f;
            // Handle what happens when the timer reaches 0
           // Debug.Log("Time's up!");

            
        }

    }

    // Call this function to increase health
    public void Eat()
    {
       // Debug.Log("Time added, player Chowed");
        currentHunger += 100f * Time.deltaTime;
        if (currentHunger > maxHunger) currentHunger = maxHunger;
        UpdateHungerUI();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HealthPickup")) 
        {
            Eat();
        }
    }

    void UpdateHungerUI()
    {

        hungerBarFill.value = currentHunger; // Update the fill amount of the health bar
        //Debug.Log("Hunger:" + Mathf.Ceil(currentHunger).ToString());
    }
    private void Update()
    {
        GettingHungry();
        // Debug.Log("Hunger:" + Mathf.Ceil(currentHunger).ToString());
     ///   Debug.Log("Hunger:" + currentHunger.ToString());
       // UpdateHungerUI();
        
       
    }

}
