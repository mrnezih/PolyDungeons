using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Karakterin collider'ý kapýya çarparsa
        if (other.CompareTag("Player"))
        {
            // Sahneyi deðiþtir
            SceneManager.LoadScene("Level 1");
        }
    }
}
