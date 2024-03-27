using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform hedefNesne; // Karakterin Transform bileşeni
    public float hareketHizi = 3f; // NPC'nin hareket hızı
    private bool takipDurum = false; // Takip durumu

    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (takipDurum && hedefNesne != null)
        {
            // NPC'nin ve hedefin konumunu al
            Vector3 npcKonumu = transform.position;
            Vector3 hedefKonum = hedefNesne.position;

            // NPC'nin karakterin konumuna doğru ilerlemesini sağla
            transform.position = Vector3.MoveTowards(npcKonumu, hedefKonum, hareketHizi * Time.deltaTime);

            // NPC'nin hedef nesneye doğru bakmasını sağla
            transform.LookAt(hedefKonum);

            Anim();
        }
    }

    private void Anim()
    {
        if (hareketHizi == 3f) 
        {
            _anim.SetBool("Run", true);
            Debug.Log("Koşuyorrrrrrrrr");
        }
    }

    // Tetikleyici alana girildiğinde çalışacak metod
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            takipDurum = true;
            hedefNesne = other.transform; // Oyuncunun pozisyonunu hedef olarak ayarla
        }
    }

    // Tetikleyici alandan çıkıldığında çalışacak metod
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            takipDurum = false;
            hedefNesne = null; // Hedefi boşalt
        }
    }
    
    #region EnemyTigger
    public void BaşlaTakip(Transform hedef)
    {
        takipDurum = true;
        hedefNesne = hedef;
    }

    public void DurTakip()
    {
        takipDurum = false;
        hedefNesne = null;
    }
    #endregion

}
