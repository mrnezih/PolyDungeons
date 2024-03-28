using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Karakterin collider'� kap�ya �arparsa
        if (other.CompareTag("Player"))
        {
            // Sahneyi de�i�tir
            SceneManager.LoadScene("Level 1");
        }
    }
}
