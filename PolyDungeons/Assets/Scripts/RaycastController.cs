using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    [SerializeField] private LayerMask hitLayer;
    private RaycastHit hit;
    public Transform raycastOrigin; // The origin point of the raycast
    public float raycastDistance = 10f; // The distance the raycast should travel
    public Color rayColor = Color.red; // The color of the ray
    void Update()
    {
        // Cast a ray from the specified origin point
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, raycastDistance))
        {
            // If the ray hits something, draw a line from the origin to the point of collision
            Debug.DrawLine(raycastOrigin.position, hit.point, rayColor);
        }
        else
        {
            // If the ray doesn't hit anything, draw a line extending out to the maximum distance
            Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * raycastDistance, rayColor);
        
        }
           
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("týklanýyor");
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity,hitLayer))
            {
                print(hit.collider.name);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
