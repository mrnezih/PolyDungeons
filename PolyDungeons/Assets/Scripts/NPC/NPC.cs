using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform hedefNesne; // Karakterin Transform bileşeni
    public float hareketHizi = 3f; // NPC'nin hareket hızı

    private Animator _anim;

    // 1,5 f yürümehızı  


    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        // NPC'nin ve karakterin konumunu al
        Vector3 npcKonumu = transform.position;
        Vector3 hedefKonum = hedefNesne.position;

        // NPC'nin karakterin konumuna doğru ilerlemesini sağla
        transform.position = Vector3.MoveTowards(npcKonumu, hedefKonum, hareketHizi * Time.deltaTime);

        Anim();
    }

    private void Anim()
    {
        if (hareketHizi==3f) 
        {
            _anim.SetBool("Run", true);
            Debug.Log("Koşuyorrrrrrrrr");
        }
    }
}
