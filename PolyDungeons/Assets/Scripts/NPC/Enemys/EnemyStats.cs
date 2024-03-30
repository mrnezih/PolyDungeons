using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float damage;
    public float expToGive;
    public float deathTime;
    Animator anim;
    public Image healthBar;

    Rigidbody rb;
    public float knockBackForceX, knockBackForceY;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.fillAmount = currentHealth / 100;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hit");
        rb.AddForce(new Vector2(knockBackForceX, knockBackForceY), ForceMode.Force);
        if (currentHealth <= 0) 
        {
            currentHealth = 0;
            anim.SetTrigger("Death");
            Destroy(gameObject, deathTime);
            Experience.instance.expMod(expToGive);
           
        }
       
    }
}
