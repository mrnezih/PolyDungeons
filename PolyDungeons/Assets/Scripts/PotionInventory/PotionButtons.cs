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

        if (gameObject.name == "HealthPotion") // E�er e�yan�n ad� "HealthPotion" ise
        {
            PlayerHealth.instance.currentHealth += HealthPotion.instance.healthToGive;
        }

        if (gameObject.name == "ManaPotion") // E�er e�yan�n ad� "HealthPotion" ise
        {
            PlayerHealth.instance.currentMana += ManaPotion.instance.manaToGive;
        }


        inventory.UsePotionInventoryItems(gameObject.name);
        
    }
}
