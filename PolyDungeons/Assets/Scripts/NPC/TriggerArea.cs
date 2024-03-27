using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public NPC npc; // NPC scriptine erişmek için referans

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npc.BaşlaTakip(other.transform); // NPC'yi takip etme işlemini başlat
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npc.DurTakip(); // NPC'nin takip etme işlemini durdur
        }
    }
}
