using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthSlider;
    public Gradient gradient;
    public Image fill;
    public HungryBoii death;
    public GameObject DeathPanel;
    public AudioSource hit;
    public AudioSource heal;
    //public AudioSource died;
    public AudioSource Lvlfailed;
    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;

    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;

    }

    void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
        death = GetComponent<HungryBoii>();
    }



    public void TakeDamage(int damage)
    {
       
        currentHealth -= damage;
        Debug.Log("Player took damage: " + damage + ". Current health: " + currentHealth);

        if (currentHealth < 0)
        {
            currentHealth = 0;
            hit.Play();
        }

        SetHealth(currentHealth);
        Debug.Log("Health bar updated. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

        
    }

    private void SaveHealth()
    {
        PlayerPrefs.SetInt("PlayerHealth", currentHealth);
        PlayerPrefs.Save();
    }

    // Call this method to heal the player
    public void Heal(int amount)
    {
      
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        SaveHealth();
        Debug.Log("Player Health: " + currentHealth);

        SetHealth(currentHealth);
        heal.Play();
    }

    void Die()
    {
       
       
        Debug.Log("Player Died");
        Time.timeScale = 0;
        DeathPanel.SetActive(true);
        Lvlfailed.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boss"))
        {
            Debug.Log("Collision with boss detected.");
            TakeDamage(3);
        }

        if (other.gameObject.CompareTag("HealthPickup"))
        {
            Heal(8); // Adjust healing value as needed
            Destroy(other.gameObject); // Optionally destroy the health pickup
        }

    }
}
