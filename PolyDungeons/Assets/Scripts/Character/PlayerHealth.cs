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


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
          
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth >= maxHealth) 
        {
            currentHealth = maxHealth;
        }
        healthBar.fillAmount = currentHealth / 100;

        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
        manaBar.fillAmount = currentMana / 100;
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



    //s�rekli hasar alma

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
