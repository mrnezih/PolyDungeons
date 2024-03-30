using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{

    public float healthToGive;

    GameManagerTwo gameManager;
    PotionInventory inventory;

    public GameObject itemToAdd;
    public int itemAmount;


    public static HealthPotion instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        gameManager = GameManagerTwo.instance;
        inventory = gameManager.GetComponent<PotionInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.CheckSlotsAvailableity(itemToAdd, itemToAdd.name, itemAmount);
            //other.GetComponent<PlayerHealth>().currentHealth += healthToGive;
            Destroy(gameObject);
        }
    }

    
}
