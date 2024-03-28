using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    public Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth >= maxHealth) 
        {
            currentHealth = maxHealth;
        }
        healthBar.fillAmount = currentHealth / 100;
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
