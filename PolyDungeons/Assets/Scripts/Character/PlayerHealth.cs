using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Image healthBar;



    public float maxMana;
    public float currentMana;
    public Image manaBar;


    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
          
    }

    void Update()
    {
        if (currentHealth >= maxHealth) 
        {
            currentHealth = maxHealth;
        }
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
        manaBar.fillAmount = currentMana / maxMana;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Traps"))
        {
            currentHealth -= other.GetComponent<ThornTrap>().damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Destroy(gameObject);
            }

        }
    }



    //sürekli hasar alma

    // private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Traps"))
    //    {
    //       currentHealth -= other.GetComponent<ThornTrap>().damage;
    //       if (currentHealth <= 0)
    //        {
    //            currentHealth = 0;
    //            Destroy(gameObject);
    //       }
    //   }
    // }
}
