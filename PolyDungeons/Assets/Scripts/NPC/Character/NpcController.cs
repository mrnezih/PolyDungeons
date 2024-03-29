using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public string[] dialogue;

    public string nameOfNpc;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            DialogueSystem.instance.AddDialogue(dialogue, nameOfNpc);
        }
    }
}
