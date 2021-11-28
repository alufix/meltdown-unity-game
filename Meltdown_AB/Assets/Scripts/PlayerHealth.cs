using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBarScript healthBar;

    [Header("Sound")]
    public AudioClip GruntClip;
    public AudioSource Source;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }


    public void InFluid()
    {
        //do the damage: 
        TakeDamage(1);
        Source.PlayOneShot(GruntClip, 0.5f);
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        // End game if health is 0/5 
        if (currentHealth <= 0) {
            //end game 
            FindObjectOfType<GameManagerScript>().EndGame(); 
        } 
    }
}
