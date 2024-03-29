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
        inventory.UsePotionInventoryItems(gameObject.name);
        
    }
}
