using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionButtons : MonoBehaviour
{
    GameManagerTwo gameManager;
    PotionInventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManagerTwo.instance;
        inventory = gameManager.GetComponent<PotionInventory>();
    }

    public void UseItem()
    {

        if (gameObject.name == "HealthPotion") // Eðer eþyanýn adý "HealthPotion" ise
        {
            PlayerHealth.instance.currentHealth += HealthPotion.instance.healthToGive;
        }

        if (gameObject.name == "ManaPotion") // Eðer eþyanýn adý "HealthPotion" ise
        {
            PlayerHealth.instance.currentMana += ManaPotion.instance.manaToGive;
        }


        inventory.UsePotionInventoryItems(gameObject.name);
        
    }
}
