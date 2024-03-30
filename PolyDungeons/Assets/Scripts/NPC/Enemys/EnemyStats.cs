using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float damage;
    public float expToGive;


    void Start()
    {
        currentHealth = maxHealth;
    }

    
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) 
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
       
    }
}
