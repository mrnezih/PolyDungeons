using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCam : MonoBehaviour
{
    private ObjectFader _fader;

    
    void Update()
    {

       
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            Vector3 dir = player.transform.position - transform.position;
            Ray ray = new Ray(transform.position, dir);
            RaycastHit hit;

            //raycast g�r�n�rl�k
            Vector3 rayOrigin = transform.position;
            Vector3 rayDirection = transform.forward;
            float rayDistance = 20f;
            if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayDistance))
            {
                // �arp��ma oldu�unda �izgiyi �iz
                Debug.DrawLine(rayOrigin, hit.point, Color.red);
            }
            else
            {
                // �arp��ma yoksa �izgiyi sona kadar �iz
                Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.green);
            }
            //


            if (Physics.Raycast(ray,out hit))
            {
                if (hit.collider == null)
                    return;

                if (hit.collider.gameObject == player)
                {
                    if(_fader!=null)
                    {
                        _fader.DoFade = false;
                    }
                }
                else
                {
                    _fader = hit.collider.gameObject.GetComponent<ObjectFader>();
                    if (_fader != null )
                    {
                        _fader.DoFade = true;
                    }
                }
            }

        }

       


    }
}
