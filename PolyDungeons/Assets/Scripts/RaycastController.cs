using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    [SerializeField] private LayerMask hitLayer;
    private RaycastHit hit;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity,hitLayer))
            {
                print(hit.collider.name);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
