using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth;
    public float curreHealth;

    public float damage;

    public float expToGive;


    void Start()
    {
        curreHealth = maxHealth;
    }

    
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if(curreHealth <=0)
        { 
            curreHealth=0;
            Destroy(gameObject);
            Experience.instance.expMod(expToGive);
        }
    }
}
