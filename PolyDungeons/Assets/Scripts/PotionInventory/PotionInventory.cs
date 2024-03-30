using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using Unity.Mathematics;

public class PotionInventory : MonoBehaviour
{
    public GameObject[] slots;
    //public GameObject[] backpack;
    bool isInstantiated;

    TextMeshProUGUI amountText;

    public Dictionary<string, int> inventoryItems = new Dictionary<string, int>();
    

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

   

    public void CheckSlotsAvailableity(GameObject itemToAdd, string itemName, int itemAmount)
    {
        isInstantiated = false;

        // �lk d�ng�: Bo� yuvalar� kontrol eder
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount == 0) // Yuva bo�sa
            {
                GameObject item = Instantiate(itemToAdd, slots[i].transform.position, Quaternion.identity);
                item.transform.SetParent(slots[i].transform, false);
                item.transform.localPosition = Vector3.zero; // K�sa yol
                item.name = item.name.Replace("(Clone)", "");
                isInstantiated = true;
                inventoryItems.Add(itemName, itemAmount);

                amountText = slots[i].GetComponentInChildren<TextMeshProUGUI>();
                amountText.text = itemAmount.ToString();
                break; // Bo� yuva bulundu, d�ng�y� sonland�r
            }
        }

        // E�er hi� bo� yuva bulunamad�ysa ve envanterde item yoksa
        if (!isInstantiated && !inventoryItems.ContainsKey(itemName))
        {
            Debug.Log("Envanterde bu e�ya yok ve bo� yuva da bulunamad�.");
            return;
        }

        // E�er envanterde item varsa ve daha �nce eklenmi�se
        if (inventoryItems.ContainsKey(itemName))
        {
            // �lgili item'�n say�s�n� art�r
            inventoryItems[itemName] += itemAmount;
            amountText.text = inventoryItems[itemName].ToString();
        }
    }

    public void UsePotionInventoryItems(string itemName)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            GameObject itemInSlot = slots[i].transform.GetChild(0).gameObject;

            if (itemInSlot.name == itemName)
            {
                inventoryItems[itemName]--;
                amountText = slots[i].GetComponentInChildren<TextMeshProUGUI>();
                amountText.text = inventoryItems[itemName].ToString();

                if (inventoryItems[itemName] <= 0)
                {
                    Destroy(itemInSlot);
                    slots[i].GetComponent<PotionSlots>().isUsed = false;
                    inventoryItems.Remove(itemName);
                }
                break;
            }
        }
    }
    
    
    //public void CheckSlotsAvailableity(GameObject itemToAdd,string itemName,int itemAmount)
    //{
    //    isInstantiated = false;
    //   for (int i = 0; i < slots.Length; i++)
    //    {
    //       if (slots[i].transform.childCount>0)
    //       {
    //           slots[i].GetComponent<PotionSlots>().isUsed=true;
    //       }
    //       else if(!isInstantiated && !slots[i].GetComponent<PotionSlots>().isUsed)
    //      {
    //          if (!inventoryItems.ContainsKey(itemName))
    //          {
    //              GameObject item = Instantiate(itemToAdd, slots[i].transform.position, Quaternion.identity);
    //              item.transform.SetParent(slots[i].transform, false);
    //              item.transform.localPosition = new Vector3(0, 0, 0);
    //              item.name = item.name.Replace("(Clone)", "");
    //              isInstantiated = true;
    //              inventoryItems.Add(itemName,itemAmount);
    //              
    //              amountText = slots[i].GetComponentInChildren<TextMeshProUGUI>();
    //              amountText.text=itemAmount.ToString();
    //             break;
    //         }
    //         else
    //         {
    //            for (int j = 0; j < slots.Length; j++)
    //            {
    //                if (slots[j].transform.GetChild(0).gameObject.name == itemName)
    //                {
    //                    inventoryItems[itemName] += itemAmount;
    //                    amountText.text = inventoryItems[itemName].ToString();
    //                    break;
    //                }
    //           }
    //            break;
    //        }
    //    }
    //  }
    // }



    //public void UsePotionInventoryItems(string itemName)
    //{


    //   for (int i = 0; i < slots.Length; i++)
    //   {
    //       if (!slots[i].GetComponent<PotionSlots>().isUsed)
    //       {

    //           continue;

    //       }

    //     if (slots[i].transform.GetChild(0).gameObject.name == itemName)
    //     {
    //         inventoryItems[itemName]--;
    //         amountText = slots[i].GetComponentInChildren<TextMeshProUGUI>();
    //         amountText.text = inventoryItems[itemName].ToString();



    //         if (inventoryItems[itemName] <= 0)
    //         {
    //            Destroy(slots[i].transform.GetChild(0).gameObject);
    //             slots[i].GetComponent<PotionSlots>().isUsed = false;
    //             inventoryItems.Remove(itemName);

    //         }
    //          break;
    //      }
    //  }
    // }
}